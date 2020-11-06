# AndcultureCode.CSharp.Testing [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing)
Commonly used CSharp testing code used at andculture.

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Testing
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Testing/AndcultureCode.CSharp.Testing.md)



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


## Features

### Factories

TODO: In-depth documentation on test factories

#### Configuration
Using the `FactorySettings` singleton class you can configure test factories. To access properties use the singleton instance `FactorySettings.Instance.{property|method};`

##### Debug (default: false)
To enable debug output set the `Debug` setting to `true`. Now warnings will be output via standard out for troubleshooting purposes. By default, only exceptional cases will be output.

# Community

[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/0)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/0)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/1)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/1)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/2)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/2)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/3)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/3)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/4)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/4)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/5)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/5)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/6)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/6)[![](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/images/7)](https://sourcerer.io/fame/andCulture/AndcultureCode/AndcultureCode.CSharp.Testing/links/7)

Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)
