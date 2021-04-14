# AndcultureCode.CSharp.Conductors [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Conductors.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Conductors) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Conductors/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Conductors)
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-5-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
Commonly used interfaces, patterns and utilities for writing conductors by andculture engineering

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Conductors
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Conductors/AndcultureCode.CSharp.Conductors.md)


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
    and-cli dotnet-test --coverage
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
    <td align="center"><a href="http://resume.dylanjustice.com"><img src="https://avatars.githubusercontent.com/u/22502365?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Dylan Justice</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dylanjustice" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dylanjustice" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dylanjustice" title="Documentation">📖</a></td>
    <td align="center"><a href="http://www.winton.me/"><img src="https://avatars.githubusercontent.com/u/48424?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Winton DeShong</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/pulls?q=is%3Apr+reviewed-by%3Awintondeshong" title="Reviewed Pull Requests">👀</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=wintondeshong" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/jhugs"><img src="https://avatars.githubusercontent.com/u/14300627?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Joshua Hughes</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=jhugs" title="Code">💻</a></td>
    <td align="center"><a href="https://www.saidshah.com"><img src="https://avatars.githubusercontent.com/u/19719299?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Said B Shah</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=SaidShah" title="Documentation">📖</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=SaidShah" title="Code">💻</a></td>
    <td align="center"><a href="https://www.davidezoccarato.cloud/"><img src="https://avatars.githubusercontent.com/u/9533250?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Davide Zoccarato</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dzoccarato" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dzoccarato" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Conductors/commits?author=dzoccarato" title="Documentation">📖</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!