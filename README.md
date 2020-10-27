# AndcultureCode.CSharp.Extensions [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions) [![code style: prettier](https://img.shields.io/badge/code_style-prettier-ff69b4.svg?style=flat-square)](https://github.com/prettier/prettier)

Commonly used CSharp extension methods used at andculture.

## Getting Started

This package is installed via NuGet

```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Extensions
```

After installation, simply import the extensions namespace to gain access
to all of the available extension methods

```csharp
using System;
using System.Collection.Generic;
using AndcultureCode.CSharp.Extensions;

public class Program
{
    public static int Main(string[] args)
    {
        new List<string>().IsEmpty(); // returns true
    }
}
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Extensions/AndcultureCode.CSharp.Extensions.md)

## Development Setup

-   Install Dotnet Core 2.x
-   Install the `and-cli` tooling found at [AndcultureCode.Cli](https://github.com/AndcultureCode/AndcultureCode.Cli)

Below are a few basics to get you started, but there are many more commands and options for managing this and other projects found in the `and-cli`.

### Building project

-   Run the build command
    ```
    and-cli dotnet --build
    ```

### Running tests along with code coverage

-   Run the test command
    ```
    and-cli dotnet-test --coverage
    ```
-   Open the `coverage.opencover.xml` file in your browser

### Publishing a new version

-   Run the publish command with the next version number ([See semver package versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning))
    ```
    and-cli nuget --publish <version>
    ```

# Community

[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/0)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/0)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/1)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/1)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/2)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/2)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/3)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/3)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/4)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/4)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/5)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/5)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/6)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/6)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/images/7)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.Cli/links/7)

# Contributing

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)
