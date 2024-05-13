# RSM.HCD.CSharp

![build status](https://github.com/rsm-hcd/RSM.HCD.CSharp/actions/workflows/build.yaml/badge.svg)
[![codecov](https://codecov.io/gh/rsm-hcd/RSM.HCD.CSharp/branch/main/graph/badge.svg)](https://codecov.io/gh/rsm-hcd/RSM.HCD.CSharp)

<!--ts-->

- [Deploying Supplemental Documentation](#deploying-supplemental-documentation)
- [Packages](#packages)
  - [RSM.HCD.CSharp.Core](#rsmhcdcsharpcore)
    - [Getting Started (RSM.HCD.CSharp.Core)](#getting-started-rsmhcdcsharpcore)
  - [RSM.HCD.CSharp.Extensions](#rsmhcdcsharpextensions)
    - [Getting Started (RSM.HCD.CSharp.Extensions)](#getting-started-rsmhcdcsharpextensions)
  - [RSM.HCD.CSharp.Testing](#rsmhcdcsharptesting)
    - [Getting Started (RSM.HCD.CSharp.Testing)](#getting-started-rsmhcdcsharptesting)
  - [RSM.HCD.CSharp.Conductors](#rsmhcdcsharpconductors)
    - [Getting Started (RSM.HCD.CSharp.Conductors)](#getting-started-rsmhcdcsharpconductors)
    - [Features](#features)
      - [Factories](#factories)
      - [Configuration](#configuration)
      - [Debug (default: false)](#debug-default-false)
- [Development Setup](#development-setup)
  - [Building project](#building-project)
  - [Running tests](#running-tests)
  - [Running tests along with code coverage](#running-tests-along-with-code-coverage)
  - [Publishing a new version](#publishing-a-new-version)
- [Contributing](#contributing)

[Supplemental Documentation](https://rsm-hcd.github.io/RSM.HCD.CSharp)

## Deploying Supplemental Documentation

```shell
$: cd documentation
$: npx cross-env CURRENT_BRANCH=main USE_SSH=true GIT_USER={GITHUB_USERNAME} GIT_PASS={GITHUB_PASSWORD} docusaurus deploy
```

## Packages

### RSM.HCD.CSharp.Core

Commonly used interfaces, patterns and utilities by the HCD engineering team at RSM

#### Getting Started (RSM.HCD.CSharp.Core)

This package is installed via NuGet

```shell
dotnet add [<PROJECT>] package RSM.HCD.CSharp.Core
```

### RSM.HCD.CSharp.Extensions

Commonly used CSharp extension methods used by the HCD engineering team at RSM.

#### Getting Started (RSM.HCD.CSharp.Extensions)

This package is installed via NuGet

```shell
dotnet add [<PROJECT>] package RSM.HCD.CSharp.Extensions
```

After installation, simply import the extensions namespace to gain access
to all of the available extension methods

```csharp
using System;
using System.Collection.Generic;
using RSM.HCD.CSharp.Extensions;

public class Program
{
    public static int Main(string[] args)
    {
        new List<string>().IsEmpty(); // returns true
    }
}
```

### RSM.HCD.CSharp.Testing

Commonly used CSharp testing code used by the HCD engineering team at RSM.

#### Getting Started (RSM.HCD.CSharp.Testing)

This package is installed via NuGet

```shell
dotnet add [<PROJECT>] package RSM.HCD.CSharp.Testing
```

### RSM.HCD.CSharp.Conductors

Commonly used interfaces, patterns and utilities for writing conductors by the HCD engineering team at RSM.

#### Getting Started (RSM.HCD.CSharp.Conductors)

This package is installed via NuGet

```shell
dotnet add [<PROJECT>] package RSM.HCD.CSharp.Conductors
```

#### Features

##### Factories

TODO: In-depth documentation on test factories

##### Configuration

Using the `FactorySettings` singleton class you can configure test factories. To access properties use the singleton instance `FactorySettings.Instance.{property|method};`

##### Debug (default: false)

To enable debug output set the `Debug` setting to `true`. Now warnings will be output via standard out for troubleshooting purposes. By default, only exceptional cases will be output.

## Development Setup

- Install Dotnet Core 6
- Install pnpm and run `pnpm install`

### Building project

- Run the build command

  ```shell
  pnpm build
  ```

### Running tests

- Run the test command

  ```shell
  pnpm test
  ```

### Running tests along with code coverage

- Run the test command

  ```shell
  pnpm test:coverage
  ```

- Open the `coverage.opencover.xml` file in your browser

### Publishing a new version

- Run the publish command with the next version number ([See semver package versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning))

  ```shell
  pnpm nuget:publish <version>
  ```

## Contributing

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)
