# AndcultureCode.CSharp.Core [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core)
Commonly used interfaces, patterns and utilities by andculture engineering

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Core
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Core/AndcultureCode.CSharp.Core.md)


## Development Setup

* Install Dotnet Core 2.x
* Install the `and-cli` tooling found at [AndcultureCode.Cli](https://github.com/AndcultureCode/AndcultureCode.Cli)

Below are a few basics to get you started, but there are many more commands and options for managing this and other projects found in the `and-cli`.

### Building project
* Run the build command
    ```
    and-cli dotnet --build
    ```

    ### Running tests
* Run the test command
    ```
    and-cli dotnet-test
    ```

### Running tests along with code coverage
* Run the test command
    ```
    and-cli dotnet-test --coverage
    ```
* Open the `coverage.opencover.xml` file in your browser

### Publishing a new version
* Run the publish command with the next version number ([See semver package versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning))
    ```
    and-cli nuget --publish <version>
    ```

# Community

[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/0)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/0)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/1)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/1)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/2)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/2)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/3)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/3)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/4)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/4)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/5)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/5)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/6)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/6)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/images/7)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Core/links/7)

Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)
