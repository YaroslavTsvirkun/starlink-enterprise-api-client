# Code signing policy

Free code signing provided by SignPath.io, certificate by SignPath Foundation.

This policy applies to the following deliverables:

- Repository: `YaroslavTsvirkun/starlink-enterprise-api-client`
- Package: `StarlinkEnterprise.ApiClient`
- Release tags: `v*`
- Distribution channel: `NuGet.org`

## Project roles

Current single-maintainer role mapping:

- Committer and reviewer: [YaroslavTsvirkun](https://github.com/YaroslavTsvirkun)
- Approver: [YaroslavTsvirkun](https://github.com/YaroslavTsvirkun)

If the maintainer set changes, this document must be updated before a new signing-enabled release is published.

## Source control and review policy

- Production releases are created from `main`.
- Changes proposed by non-committers must be merged only through reviewed pull requests.
- Changes to build scripts, GitHub Actions workflows, package metadata, signing configuration, and release automation are subject to the same review standard as source code.
- Release tags must point to commits that passed the repository verification steps defined in the release pipeline.
- Artifacts submitted for signing must be built from this repository and from build configuration stored under source control.
- This project certificate must not be used to re-sign third-party binaries or artifacts that are not built from this repository.

## Signing approval policy

- Every release signing request requires explicit manual approval by an approver.
- Only release artifacts for `StarlinkEnterprise.ApiClient` may be signed under this policy.
- Published package versions are immutable. If an artifact must be rebuilt or re-signed, a new package version is required.
- Release signing must use origin verification through a trusted build system once the SignPath integration is enabled.

## Allowed artifacts

The following artifacts are in scope for release signing:

- `.nupkg` files produced from `src/StarlinkEnterprise.ApiClient/StarlinkEnterprise.ApiClient.csproj`

The following are out of scope:

- upstream binaries signed by other publishers
- proprietary, closed-source, or unrelated artifacts
- malware, potentially unwanted software, or security exploitation tools

## Privacy policy

Privacy policy: [PRIVACY.md](./PRIVACY.md)

This program will not transfer any information to other networked systems unless specifically requested by the user or the person installing or operating it.

For clarity:

- this package is a developer library and not an end-user installer
- it does not start background services or scheduled tasks
- it communicates over the network only when the consuming application explicitly invokes the Starlink Enterprise API client
- the destination endpoint, authentication token, and transmitted payload are controlled by the consuming application and its operator

## Security expectations

- All maintainers participating in release signing must use multi-factor authentication for GitHub and SignPath.
- Branch protection for `main` should require pull request review before signing-enabled releases are published.
- Source code review for release branches must include build scripts, workflow files, package metadata, and release automation.

## Related documents

- [README.md](./README.md)
- [CONTRIBUTING.md](./CONTRIBUTING.md)
- [docs/SIGNPATH_FOUNDATION_READINESS.md](./docs/SIGNPATH_FOUNDATION_READINESS.md)
