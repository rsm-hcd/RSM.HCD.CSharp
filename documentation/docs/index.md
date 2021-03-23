---
id: index
title: Core
sidebar_label: Core
slug: /
---

## Do.Try

[Exceptions should be exceptional](https://mattwarren.org/2016/12/20/Why-Exceptions-should-be-Exceptional/).
Normal flow control should leverage error handling and exceptions remain rare. This library provides syntactic sugar
to employ the .NET Framework `TryXXX()` pattern by way of a class called `Do`.

The `Do` class is accompanied by a series of static and extension methods to essentially management
standard C# try/catch boilerplate and provide a safe guard against an unhandled exceptions
that otherwise end the normal flow of execution.

Below is documentation on the various methods available.

### Do
All of the methods to follow stem from `Do`. While you can instantiate your own instance with the
`new` keyword `new Do(delegateFunction)`, the preferred method to interact with this pattern
is through the available static methods and extensions methods of `Do`.

```csharp
public IResult<bool> Validate() => Do<bool>.Try((r) =>
{
    // Validation logic
    return true;
}).Result;
```

At the end of the day, `Do.Try` is simplifying the use of `try/catch`. Through the use of expression
bodies and the `IResult`, exceptions are handled more gracefully and their result standardized.

The `Do` object contains information about the work being attempted (`Workload`) and its results
(`Result`, `Exception`).

### Try
The most commonly used method of `Do` is the `Try` static method. This method and its various
overloads provide a simplified entry point into the pattern.

Married with the use of C# expression bodies, the `Do<T>.Try` call can be written in a way that
maintains the profile of standard method bodies.

#### Without Expression Bodies
```csharp
// Long hand
public IResult<bool> Validate()
{
    var result = Do<bool>.Try((r) =>
    {
        // Validation logic
        return true;
    });

    return result;
}

// Single line return
public IResult<bool> Validate()
{
    return Do<bool>.Try((r) =>
    {
        // Validation logic
        return true;
    }).Result;
}
```

#### C# Expression Bodies
```csharp
public IResult<bool> Validate() => Do<bool>.Try((r) =>
{
    // Validation logic
    return true;
}).Result;
```

### Then


### Catch


### Finally

<!-- ## Code

```javascript
var s = 'JavaScript syntax highlighting';
alert(s);
```

```python
s = "Python syntax highlighting"
print(s)
```

```
No language indicated, so no syntax highlighting.
But let's throw in a <b>tag</b>.
```

```js {2}
function highlightMe() {
  console.log('This line can be highlighted!');
}
``` -->
