[CmdletBinding()]
param(
    [string]$ProjectPath = "src/StarlinkEnterprise.ApiClient/StarlinkEnterprise.ApiClient.csproj",
    [string]$SolutionPath = "StarlinkEnterprise.ApiClient.slnx",
    [string]$Configuration = "Release",
    [string]$OutputDirectory = "artifacts/packages",
    [string]$ApiSource = "https://api.nuget.org/v3/index.json",
    [string]$Version,
    [string]$ApiKey = $env:NUGET_API_KEY,
    [string]$CertificatePath = $env:NUGET_SIGN_CERT_PATH,
    [string]$CertificatePassword = $env:NUGET_SIGN_CERT_PASSWORD,
    [string]$CertificateFingerprint = $env:NUGET_SIGN_CERT_FINGERPRINT,
    [string]$CertificateSubjectName = $env:NUGET_SIGN_CERT_SUBJECT_NAME,
    [string]$CertificateStoreLocation = $(if ($env:NUGET_SIGN_CERT_STORE_LOCATION) { $env:NUGET_SIGN_CERT_STORE_LOCATION } else { "CurrentUser" }),
    [string]$CertificateStoreName = $(if ($env:NUGET_SIGN_CERT_STORE_NAME) { $env:NUGET_SIGN_CERT_STORE_NAME } else { "My" }),
    [string]$TimestampUrl = $env:NUGET_SIGN_TIMESTAMP_URL,
    [switch]$SkipTests,
    [switch]$SkipPush
)

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

function Invoke-ExternalCommand {
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath,

        [Parameter(Mandatory = $true)]
        [string[]]$Arguments
    )

    Write-Host "==> $FilePath $($Arguments -join ' ')"
    & $FilePath @Arguments

    if ($LASTEXITCODE -ne 0) {
        throw "Command failed with exit code ${LASTEXITCODE}: $FilePath $($Arguments -join ' ')"
    }
}

function Normalize-Secret {
    param([string]$Value)

    if ([string]::IsNullOrWhiteSpace($Value)) {
        return $null
    }

    return $Value.Trim().Trim('"').Trim("'")
}

if (-not (Test-Path $ProjectPath)) {
    throw "Project file not found: $ProjectPath"
}

if (-not (Test-Path $SolutionPath)) {
    throw "Solution file not found: $SolutionPath"
}

$ApiKey = Normalize-Secret -Value $ApiKey
$CertificatePassword = Normalize-Secret -Value $CertificatePassword
$CertificateFingerprint = Normalize-Secret -Value $CertificateFingerprint
$CertificateSubjectName = Normalize-Secret -Value $CertificateSubjectName
$TimestampUrl = Normalize-Secret -Value $TimestampUrl

New-Item -ItemType Directory -Force -Path $OutputDirectory | Out-Null

Invoke-ExternalCommand -FilePath "dotnet" -Arguments @("build", $SolutionPath, "--configuration", $Configuration, "--nologo")

if (-not $SkipTests) {
    Invoke-ExternalCommand -FilePath "dotnet" -Arguments @("test", $SolutionPath, "--configuration", $Configuration, "--no-build", "--nologo")
}

$packArguments = @(
    "pack",
    $ProjectPath,
    "--configuration", $Configuration,
    "--nologo",
    "--output", $OutputDirectory
)

if (-not [string]::IsNullOrWhiteSpace($Version)) {
    $packArguments += "-p:PackageVersion=$Version"
}

Invoke-ExternalCommand -FilePath "dotnet" -Arguments $packArguments

$package = Get-ChildItem -Path $OutputDirectory -Filter "*.nupkg" -File |
    Where-Object { $_.Name -notlike "*.symbols.nupkg" } |
    Sort-Object LastWriteTimeUtc -Descending |
    Select-Object -First 1

if ($null -eq $package) {
    throw "No .nupkg file was produced in $OutputDirectory"
}

if ([string]::IsNullOrWhiteSpace($TimestampUrl)) {
    throw "Timestamp URL is required. Set NUGET_SIGN_TIMESTAMP_URL or pass -TimestampUrl."
}

$signArguments = @(
    "nuget",
    "sign",
    $package.FullName,
    "--timestamper", $TimestampUrl,
    "--overwrite"
)

if (-not [string]::IsNullOrWhiteSpace($CertificatePath)) {
    if (-not (Test-Path $CertificatePath)) {
        throw "Certificate file not found: $CertificatePath"
    }

    $resolvedCertificatePath = (Resolve-Path $CertificatePath).Path
    $signArguments += @("--certificate-path", $resolvedCertificatePath)

    if (-not [string]::IsNullOrWhiteSpace($CertificatePassword)) {
        $signArguments += @("--certificate-password", $CertificatePassword)
    }
}
elseif (-not [string]::IsNullOrWhiteSpace($CertificateFingerprint)) {
    $signArguments += @(
        "--certificate-fingerprint", $CertificateFingerprint,
        "--certificate-store-location", $CertificateStoreLocation,
        "--certificate-store-name", $CertificateStoreName
    )

    if (-not [string]::IsNullOrWhiteSpace($CertificatePassword)) {
        $signArguments += @("--certificate-password", $CertificatePassword)
    }
}
elseif (-not [string]::IsNullOrWhiteSpace($CertificateSubjectName)) {
    $signArguments += @(
        "--certificate-subject-name", $CertificateSubjectName,
        "--certificate-store-location", $CertificateStoreLocation,
        "--certificate-store-name", $CertificateStoreName
    )

    if (-not [string]::IsNullOrWhiteSpace($CertificatePassword)) {
        $signArguments += @("--certificate-password", $CertificatePassword)
    }
}
else {
    throw "Signing certificate is not configured. Provide NUGET_SIGN_CERT_PATH, NUGET_SIGN_CERT_FINGERPRINT, or NUGET_SIGN_CERT_SUBJECT_NAME."
}

Invoke-ExternalCommand -FilePath "dotnet" -Arguments $signArguments
Invoke-ExternalCommand -FilePath "dotnet" -Arguments @("nuget", "verify", $package.FullName, "--all")

if (-not $SkipPush) {
    if ([string]::IsNullOrWhiteSpace($ApiKey)) {
        throw "NuGet API key is required. Set NUGET_API_KEY or pass -ApiKey."
    }

    Invoke-ExternalCommand -FilePath "dotnet" -Arguments @(
        "nuget",
        "push",
        $package.FullName,
        "--source", $ApiSource,
        "--api-key", $ApiKey,
        "--skip-duplicate"
    )
}

Write-Host "==> Signed package: $($package.FullName)"
