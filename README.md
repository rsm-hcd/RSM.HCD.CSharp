# AndcultureCode.CSharp.Testing [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing)
Commonly used CSharp testing code used at andculture.

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Testing
```


## Development Setup

* Install Dotnet Core 2.x
* Install the `and-cli` tooling found at [AndcultureCode.Cli](https://github.com/AndcultureCode/AndcultureCode.Cli)

Below are a few basics to get you started, but there are many more commands and options for managing this and other projects found in the `and-cli`.

### Building project
* Run the build command
    ```
    and-cli dotnet --build
    ```

### Running tests along with code coverage
* Run the test command
    ```
    and-cli dotnet-test
    ```
* Open the `coverage/index.htm` file in your browser

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


Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)