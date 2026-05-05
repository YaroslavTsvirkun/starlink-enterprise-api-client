# Contributing

## Scope

This repository contains the source code for `StarlinkEnterprise.ApiClient`.

## Contribution flow

- Use feature branches or forks for changes.
- Open a pull request for review before merging non-trivial changes.
- Changes from non-committers must be reviewed before merge.
- Changes to build scripts, workflow files, package metadata, and release automation must be reviewed with the same care as source code changes.

## Verification

Before merge, contributors should run:

```powershell
dotnet build StarlinkEnterprise.ApiClient.slnx
dotnet test StarlinkEnterprise.ApiClient.slnx
```

## Release rules

- Production releases are cut from `main`.
- Release tags must point to commits that passed the repository verification pipeline.
- Signing-enabled releases must follow [CODE_SIGNING_POLICY.md](./CODE_SIGNING_POLICY.md).
