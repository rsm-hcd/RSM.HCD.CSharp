# AndcultureCode.CSharp.Extensions [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions) [![code style: prettier](https://img.shields.io/badge/code_style-prettier-ff69b4.svg?style=flat-square)](https://github.com/prettier/prettier)
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-7-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->

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

# Contributing

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/brandongregoryscott"><img src="https://avatars.githubusercontent.com/u/11774799?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Brandon Scott</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=brandongregoryscott" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=brandongregoryscott" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/pulls?q=is%3Apr+reviewed-by%3Abrandongregoryscott" title="Reviewed Pull Requests">👀</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=brandongregoryscott" title="Documentation">📖</a></td>
    <td align="center"><a href="http://www.winton.me/"><img src="https://avatars.githubusercontent.com/u/48424?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Winton DeShong</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=wintondeshong" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=wintondeshong" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/pulls?q=is%3Apr+reviewed-by%3Awintondeshong" title="Reviewed Pull Requests">👀</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=wintondeshong" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/HeyKos"><img src="https://avatars.githubusercontent.com/u/5178698?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Mike Koser</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=HeyKos" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=HeyKos" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/pulls?q=is%3Apr+reviewed-by%3AHeyKos" title="Reviewed Pull Requests">👀</a></td>
    <td align="center"><a href="https://github.com/joshuapeters"><img src="https://avatars.githubusercontent.com/u/9259962?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Joshua Peters</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=joshuapeters" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=joshuapeters" title="Tests">⚠️</a></td>
    <td align="center"><a href="http://jebediahelliott.com"><img src="https://avatars.githubusercontent.com/u/26680652?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Jeb</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=jebediahelliott" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=jebediahelliott" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/ghost"><img src="https://avatars.githubusercontent.com/u/10137?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Deleted user</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=ghost" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=ghost" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://mjones.network"><img src="https://avatars.githubusercontent.com/u/8648891?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Mat Jones</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=mrjones2014" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/commits?author=mrjones2014" title="Tests">⚠️</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
