# AndcultureCode.CSharp.Core 
[![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Core) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Core) <!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-5-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
Commonly used interfaces, patterns and utilities by andculture engineering

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Core
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Core/AndcultureCode.CSharp.Core.md)

[Supplemental Documentation](https://andculturecode.github.io/AndcultureCode.CSharp.Core)


### Deploying Supplemental Documentation

```shell
$: cd documentation
$: npx cross-env CURRENT_BRANCH=main USE_SSH=true GIT_USER={GITHUB_USERNAME} GIT_PASS={GITHUB_PASSWORD} docusaurus deploy
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
    <td align="center"><a href="http://www.winton.me/"><img src="https://avatars.githubusercontent.com/u/48424?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Winton DeShong</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=wintondeshong" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=wintondeshong" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=wintondeshong" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/brandongregoryscott"><img src="https://avatars.githubusercontent.com/u/11774799?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Brandon Scott</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=brandongregoryscott" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=brandongregoryscott" title="Tests">⚠️</a> <a href="#maintenance-brandongregoryscott" title="Maintenance">🚧</a></td>
    <td align="center"><a href="https://github.com/Stefanie899"><img src="https://avatars.githubusercontent.com/u/37462028?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Stefanie Leitch</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=Stefanie899" title="Code">💻</a></td>
    <td align="center"><a href="http://jebediahelliott.com"><img src="https://avatars.githubusercontent.com/u/26680652?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Jeb</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=jebediahelliott" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/jhugs"><img src="https://avatars.githubusercontent.com/u/14300627?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Joshua Hughes</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Core/commits?author=jhugs" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
