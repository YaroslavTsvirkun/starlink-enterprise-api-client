# SignPath Foundation readiness

This document tracks repository-side readiness for an application to `SignPath Foundation`.

## Current status

- [x] Public source repository
- [x] OSI-approved open-source license (`MIT`)
- [x] Published release (`v0.1.0`)
- [x] Published NuGet package (`StarlinkEnterprise.ApiClient`)
- [x] Repository home page documentation
- [x] Formal [Code signing policy](../CODE_SIGNING_POLICY.md)
- [x] Formal [Privacy policy](../PRIVACY.md)
- [x] Contribution and review guidance in [CONTRIBUTING.md](../CONTRIBUTING.md)
- [x] `CODEOWNERS` file prepared
- [x] Branch protection enabled on `main`
- [x] Pull request CI workflow for build and test
- [ ] Required status checks enforced on `main`
- [ ] Required pull request reviews enforced on `main`
- [ ] MFA confirmed for every maintainer involved in releases
- [ ] SignPath Foundation application submitted
- [ ] SignPath project configured with GitHub trusted build system
- [ ] SignPath origin verification enabled
- [ ] SignPath manual approval flow configured for release signing
- [ ] Release workflow migrated from direct certificate push to SignPath signing request flow

## Manual actions still required outside the repository

1. Mark the `CI / build-and-test` GitHub Actions check as required for `main`.
2. Require pull request reviews for changes merged into `main`.
3. Confirm MFA on GitHub for every maintainer who can approve or publish releases.
4. Apply to SignPath Foundation and provide the repository URL, package URL, and release history.
5. Configure SignPath to use GitHub as the trusted build system with origin verification.
6. Replace direct signing secrets with the SignPath submission and approval flow once the SignPath project is approved.

## Notes

- The current repository already contains a direct `NuGet` signing workflow for bring-your-own certificate scenarios.
- `SignPath Foundation` for OSS projects requires origin verification and manual approval for release signing.
- Branch protection and SignPath account configuration cannot be completed from the repository alone.
