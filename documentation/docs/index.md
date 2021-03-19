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


### Try


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
