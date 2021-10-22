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

The `Do` class is accompanied by a series of static and extension methods to essentially manage
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

```csharp
/// <summary>
/// Attempts to run the provided delegate function
/// </summary>
/// <param name="workload">Single unit of work to attempt</param>
public static Do<T> Try(Func<IResult<T>, T> workload);
public static Do<T> Try(ILogger logger, Func<IResult<T>, T> workload);
public static Do<T> Try(ILogger logger, uint retry, Func<IResult<T>, T> workload);
```

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

```csharp
/// <summary>
/// Chainable method to perform additional pieces of work beyond an initial try
/// </summary>
/// <param name="workload">Single unit of work to attempt</param>
/// <param name="skipIfErrors">Provided work will be ignored if errors exist</param>
public Do<T> Then(Func<IResult<T>, T> workload, bool skipIfErrors = true);
```

There are scenarios, such as; argument validation, preloading data, etc... where preliminary work
needs to be done before getting to the concern of your method. Naturally, we turn to writing small
bite sized functions to handle each of these concerns. The path forward with `Do<T>.Try` alone tends
to lead to a series of somewhat boilerplate error handling.

#### Common boilerplate without `Then`

```csharp
public IResult<bool> Validate(long id) => Do<bool>.Try((r) =>
{
    // Example of common result handling boilerplate
    var argumentResult = ValidateArguments(id);
    if (argumentResult.HasErrors)
    {
        r.AddErrors(argumentResult);
        return false;
    }

    // Additional method calls and/ or validation logic

    return true;
}).Result;

private IResult<bool> ValidateArguments(long id) => Do<bool>.Try((r) =>
{
    if (id <= 0)
    {
        r.AddError(Errors.InvalidArgument(nameof(id)), "must be greater than zero");
    }

    return !r.HasErrors;
}).Result;
```

#### Chaining with and without arguments using `Then`

While there are situationally clever ways to cut down on this boilerplate, there is no clear path
forward with `Try` alone.

This is where the chainable `Then` method comes into play. Levering `Do.Try.Then` you can fluently
compose your IResult handling methods without the common boilerplate.

```csharp
public IResult<bool> Validate(long id) => Do<bool>
  .Try(ValidationMethodWithoutArguments)
  .Then((r) => ValidateArguments(r, id))
  .Then((r) =>
{
    // additonal validation logic

    return true;
}).Result;

private bool ValidationMethodWithoutArguments(IResult<bool> r)
{
    if (!_isMyFeatureEnabled)
    {
        r.AddError(Errors.FeaturedDisabled(nameof(_isMyFeatureEnabled), "is disabled"));
    }

    return !r.HasErrors;
}

// Notice the method signature simplification
private bool ValidateArguments(IResult<bool> r, long id)
{
    if (id <= 0)
    {
        r.AddError(Errors.InvalidArgument(nameof(id)), "must be greater than zero");
    }

    return !r.HasErrors;
}
```

Following this approach, in our contrived example where our concern is validation, there
may very well likely be entirely composite methods/functions.

```csharp
public IResult<bool> Validate(long id, string name) => Do<bool>
  .Try(ValidationMethodWithoutArguments)
  .Then((r) => ValidateId(r, id))
  .Then((r) => ValidateName(r, name))
  .Result;
```

#### Short-circuiting the chain with `skipIfErrors`

By default, delegate functions provided to `Then` will _NOT_ be executed if the associated `IResult`
has errors. In some scenarios, you may desire to call a series of functions before determing the
result.

```csharp
public IResult<bool> Validate(long id, string name) => Do<bool>
  .Try((r) => ValidateId(r, id))
  .Then((r) => ValidateName(r, name), skipIfErrors: false)
  .Then((r) => !r.HasErrors, skipIfErrors: false) // <-- Falls through allowing our last `then` to determine the result
  .Result;
```
