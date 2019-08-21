# AndcultureCode.CSharp.Core [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core)
Commonly used interfaces, patterns and utilities by andculture engineering

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Core
```


## Development Setup

* Install Dotnet Core 2.x
* Install NodeJS
* Run `npm install` to ensure proper tooling is installed for the project
* Run `./sdk` and if all is right, you'll see the help output

### Building project
* Run the build command
    ```
    ./sdk -b
    ./sdk --build
    ```

### Running tests along with code coverage
* Run the test command
    ```
    ./sdk -t
    ./sdk --test
    ```
* Open the `coverage/index.htm` file in your browser

### Publishing a new version
* Run the publish command with the next version number ([See semver package versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning))
    ```
    ./sdk -p [version]
    ./sdk --publish [version]
    ```


Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)