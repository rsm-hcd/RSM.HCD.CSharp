# AndcultureCode.CSharp.Testing [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Testing) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Testing)
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-3-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
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

Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="http://resume.dylanjustice.com"><img src="https://avatars.githubusercontent.com/u/22502365?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Dylan Justice</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=dylanjustice" title="Code">💻</a></td>
    <td align="center"><a href="http://www.winton.me/"><img src="https://avatars.githubusercontent.com/u/48424?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Winton DeShong</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=wintondeshong" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=wintondeshong" title="Documentation">📖</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=wintondeshong" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/pulls?q=is%3Apr+reviewed-by%3Awintondeshong" title="Reviewed Pull Requests">👀</a></td>
    <td align="center"><a href="https://github.com/brandongregoryscott"><img src="https://avatars.githubusercontent.com/u/11774799?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Brandon Scott</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=brandongregoryscott" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/commits?author=brandongregoryscott" title="Tests">⚠️</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!