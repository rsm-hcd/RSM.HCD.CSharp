# AndcultureCode.CSharp.Extensions [![Build Status](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions.svg?branch=master)](https://travis-ci.org/AndcultureCode/AndcultureCode.CSharp.Extensions) [![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions/branch/master/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Extensions)
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

## Development Setup

* Install Dotnet Core 2.x
* Install NodeJS
* Run `npm install` to ensure proper tooling is installed for the project
* Run `./sdk` and if all is right, you'll see the help output

### Building project

```
./sdk -b
./sdk --build
```

### Running tests along with code coverage
```
./sdk -t
./sdk --test
```
Then open the `coverage/index.htm` file in your browser to see the results

Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)