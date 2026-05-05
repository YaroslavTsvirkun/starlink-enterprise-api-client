# Privacy policy

This package is a developer library for the Starlink Enterprise API.

This program will not transfer any information to other networked systems unless specifically requested by the user or the person installing or operating it.

## Data handling

- The package does not include telemetry, analytics, crash reporting, advertising, or automatic update behavior.
- The package does not start any background process, scheduled task, or Windows service.
- The package does not persist user data outside of normal application-controlled runtime behavior.

## Network behavior

- Network communication occurs only when the consuming application explicitly calls the client methods exposed by this package.
- The consuming application is responsible for configuring the destination endpoint, access token provider, request payloads, logging, and storage behavior.
- The package does not contact third-party services on its own.

## Authentication material

- Access tokens are supplied by the consuming application through `IStarlinkAccessTokenProvider`.
- This package does not fetch, mint, or rotate tokens on its own.

## Scope

This policy applies to the package `StarlinkEnterprise.ApiClient` and to release artifacts produced from this repository.
