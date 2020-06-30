<a name='assembly'></a>
# AndcultureCode.CSharp.Testing

## Contents

- [BaseIntegrationTest](#T-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest')
  - [Create\`\`1(context,item)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-AndcultureCode-CSharp-Core-Interfaces-IContext,``0- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(AndcultureCode.CSharp.Core.Interfaces.IContext,``0)')
  - [GetRepositoryConductorDeps\`\`1(repository)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-GetRepositoryConductorDeps``1-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.GetRepositoryConductorDeps``1(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{``0})')
- [BaseTest](#T-AndcultureCode-CSharp-Testing-Tests-BaseTest 'AndcultureCode.CSharp.Testing.Tests.BaseTest')
  - [#ctor(output)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#ctor-Xunit-Abstractions-ITestOutputHelper- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.#ctor(Xunit.Abstractions.ITestOutputHelper)')
  - [#cctor()](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#cctor 'AndcultureCode.CSharp.Testing.Tests.BaseTest.#cctor')
  - [BuildResult\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildResult``1-System-Action{AndcultureCode-CSharp-Core-Models-Result{``0}}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.BuildResult``1(System.Action{AndcultureCode.CSharp.Core.Models.Result{``0}}[])')
- [Factory](#T-AndcultureCode-CSharp-Testing-Factories-Factory 'AndcultureCode.CSharp.Testing.Factories.Factory')
  - [Milliseconds](#P-AndcultureCode-CSharp-Testing-Factories-Factory-Milliseconds 'AndcultureCode.CSharp.Testing.Factories.Factory.Milliseconds')
  - [Random](#P-AndcultureCode-CSharp-Testing-Factories-Factory-Random 'AndcultureCode.CSharp.Testing.Factories.Factory.Random')
  - [UniqueNumber](#P-AndcultureCode-CSharp-Testing-Factories-Factory-UniqueNumber 'AndcultureCode.CSharp.Testing.Factories.Factory.UniqueNumber')
  - [Define()](#M-AndcultureCode-CSharp-Testing-Factories-Factory-Define 'AndcultureCode.CSharp.Testing.Factories.Factory.Define')
- [FactorySettings](#T-AndcultureCode-CSharp-Testing-Factories-FactorySettings 'AndcultureCode.CSharp.Testing.Factories.FactorySettings')
  - [Debug](#P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Debug 'AndcultureCode.CSharp.Testing.Factories.FactorySettings.Debug')
  - [Instance](#P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Instance 'AndcultureCode.CSharp.Testing.Factories.FactorySettings.Instance')
- [HttpResponseMessageExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageExtensions 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageExtensions')
  - [FromJson\`\`1(response)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageExtensions-FromJson``1-System-Net-Http-HttpResponseMessage- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageExtensions.FromJson``1(System.Net.Http.HttpResponseMessage)')
- [HttpResponseMessageMatcherExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions')
  - [ShouldBe(response,statusCode,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBe-System-Net-Http-HttpResponseMessage,System-Net-HttpStatusCode,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBe(System.Net.Http.HttpResponseMessage,System.Net.HttpStatusCode,System.Boolean)')
  - [ShouldBeABadRequest(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeABadRequest-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeABadRequest(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeAConflict(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeAConflict-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeAConflict(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeCreated(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeCreated-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeCreated(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeForbidden(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeForbidden-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeForbidden(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeInternalServerError(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeInternalServerError-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeInternalServerError(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeNoContent(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeNoContent-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeNoContent(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeOk(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeOk-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeOk(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldBeUnauthorized(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeUnauthorized-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldBeUnauthorized(System.Net.Http.HttpResponseMessage,System.Boolean)')
  - [ShouldNotBeFound(response,withContent)](#M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldNotBeFound-System-Net-Http-HttpResponseMessage,System-Boolean- 'AndcultureCode.CSharp.Testing.Extensions.HttpResponseMessageMatcherExtensions.ShouldNotBeFound(System.Net.Http.HttpResponseMessage,System.Boolean)')
- [IRepositoryConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors.IRepositoryConductorMockExtensions')
  - [SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors.IRepositoryConductorMockExtensions.SetupFindAll``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Nullable{System.Boolean})')
- [IRepositoryReadConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors.IRepositoryReadConductorMockExtensions')
  - [SetupFindAllCommitted\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions-SetupFindAllCommitted``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors.IRepositoryReadConductorMockExtensions.SetupFindAllCommitted``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean})')
  - [SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors.IRepositoryReadConductorMockExtensions.SetupFindAll``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Nullable{System.Boolean})')
- [IResultMatcherExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions')
  - [ERROR_ERRORS_LIST_IS_NULL_MESSAGE](#F-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ERROR_ERRORS_LIST_IS_NULL_MESSAGE 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE')
  - [ShouldHaveBasicError\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveBasicError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveBasicError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldHaveErrors(result,exactCount)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Boolean},System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrors(AndcultureCode.CSharp.Core.Interfaces.IResult{System.Boolean},System.Nullable{System.Int32})')
  - [ShouldHaveErrorsFor\`\`1(result,property,exactCount,containedInMessage)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String,System-Nullable{System-Int32},System-String- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrorsFor``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String,System.Nullable{System.Int32},System.String)')
  - [ShouldHaveErrors\`\`1(result,exactCount)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrors``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.Nullable{System.Int32})')
  - [ShouldNotHaveErrorsFor\`\`1(result,property)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldNotHaveErrorsFor``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String)')
  - [ShouldNotHaveErrors\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldNotHaveErrors``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')

<a name='T-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest'></a>
## BaseIntegrationTest `type`

##### Namespace

AndcultureCode.CSharp.Testing.Tests

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-AndcultureCode-CSharp-Core-Interfaces-IContext,``0-'></a>
### Create\`\`1(context,item) `method`

##### Summary

Defines generic creation of T Entity using repository conductors. Must be overridden by inheriting classes.

##### Returns

NotImplementedException when not overridden

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [AndcultureCode.CSharp.Core.Interfaces.IContext](#T-AndcultureCode-CSharp-Core-Interfaces-IContext 'AndcultureCode.CSharp.Core.Interfaces.IContext') |  |
| item | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-GetRepositoryConductorDeps``1-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{``0}-'></a>
### GetRepositoryConductorDeps\`\`1(repository) `method`

##### Summary

Sets up an object containing conductor dependencies for a given Entity T returned as a composed model.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{``0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Testing-Tests-BaseTest'></a>
## BaseTest `type`

##### Namespace

AndcultureCode.CSharp.Testing.Tests

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#ctor-Xunit-Abstractions-ITestOutputHelper-'></a>
### #ctor(output) `constructor`

##### Summary

Instance constructor to set up common test-level actors

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| output | [Xunit.Abstractions.ITestOutputHelper](#T-Xunit-Abstractions-ITestOutputHelper 'Xunit.Abstractions.ITestOutputHelper') |  |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#cctor'></a>
### #cctor() `method`

##### Summary

Static constructor to set up suite-level actors

 Most recent performance test: .04 milliseconds / ~47 microseconds

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildResult``1-System-Action{AndcultureCode-CSharp-Core-Models-Result{``0}}[]-'></a>
### BuildResult\`\`1(properties) `method`

##### Summary

Factory method for setting properties directly on a new Result. Sets the \`ResultObject\`
to the default value of T, but can be nested with other factory methods if a specific
configuration of \`T\` is required.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{AndcultureCode.CSharp.Core.Models.Result{\`\`0}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{AndcultureCode.CSharp.Core.Models.Result{``0}}[]') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Testing-Factories-Factory'></a>
## Factory `type`

##### Namespace

AndcultureCode.CSharp.Testing.Factories

<a name='P-AndcultureCode-CSharp-Testing-Factories-Factory-Milliseconds'></a>
### Milliseconds `property`

##### Summary

Returns the current time in unix milliseconds.

 NOTE: Not guaranteed to be unique. If you require a unique value for a factory value,
 use \`UniqueNumber\` instead.

##### Returns



<a name='P-AndcultureCode-CSharp-Testing-Factories-Factory-Random'></a>
### Random `property`

##### Summary

Returns a new \`Randomizer\` instance for generating random data as factory values.

##### Returns



<a name='P-AndcultureCode-CSharp-Testing-Factories-Factory-UniqueNumber'></a>
### UniqueNumber `property`

##### Summary

Returns a unique number for use in factory values.

<a name='M-AndcultureCode-CSharp-Testing-Factories-Factory-Define'></a>
### Define() `method`

##### Summary

Define your factory

##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Testing-Factories-FactorySettings'></a>
## FactorySettings `type`

##### Namespace

AndcultureCode.CSharp.Testing.Factories

##### Summary

Singleton test-suite wide for configuring test factory related settings

<a name='P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Debug'></a>
### Debug `property`

##### Summary

When enabled, factory related debug output will be written to standard out
for troubleshooting purposes. Otherwise, by default it will only output
for actual exceptional cases.

<a name='P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Instance'></a>
### Instance `property`

##### Summary

Lazy-loaded singleton instance used to alter factory settings
Ie. FactorySettings.Instance.Debug = true;

<a name='T-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageExtensions'></a>
## HttpResponseMessageExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageExtensions-FromJson``1-System-Net-Http-HttpResponseMessage-'></a>
### FromJson\`\`1(response) `method`

##### Summary

Deserializes http response into supplied object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions'></a>
## HttpResponseMessageMatcherExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Testing assertion extension methods related to HttpResponseMessage objects.
Try your best to follow the 'Shouldly' API to maintain a common language in assertions.

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBe-System-Net-Http-HttpResponseMessage,System-Net-HttpStatusCode,System-Boolean-'></a>
### ShouldBe(response,statusCode,withContent) `method`

##### Summary

General purpose extension to shouldly's ShouldBe around status code assertion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| statusCode | [System.Net.HttpStatusCode](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.HttpStatusCode 'System.Net.HttpStatusCode') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeABadRequest-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeABadRequest(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 400 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeAConflict-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeAConflict(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 409 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeCreated-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeCreated(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 201 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeForbidden-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeForbidden(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 403 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeInternalServerError-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeInternalServerError(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 500 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeNoContent-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeNoContent(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 204 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeOk-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeOk(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 200 (with or without content)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldBeUnauthorized-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldBeUnauthorized(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 401

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-HttpResponseMessageMatcherExtensions-ShouldNotBeFound-System-Net-Http-HttpResponseMessage,System-Boolean-'></a>
### ShouldNotBeFound(response,withContent) `method`

##### Summary

Simplified approach to asserting if the HTTP status code was 404

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Net.Http.HttpResponseMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpResponseMessage 'System.Net.Http.HttpResponseMessage') |  |
| withContent | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should we also assert that a content body was supplied |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryConductorMockExtensions'></a>
## IRepositoryConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors

<a name='M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}-'></a>
### SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Sets up the FindAll method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions". See
https://andculture.atlassian.net/browse/CCALMS2-599

##### Returns

A setup FindAll method on the supplied mocked conductor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mock | [Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor{\`\`0}}](#T-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor{``0}} 'Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor{``0}}') | The read repository conductor being mocked. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value for includeProperties to be setup (optional) |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for skip to be setup (optional) |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for take to be setup (optional) |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | The value for ignoreQueryFilters to be setup (optional) |
| asNoTracking | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | The value for asNoTracking to be setup (optional) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The model type applied to the repository read conductor. |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions'></a>
## IRepositoryReadConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors

<a name='M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions-SetupFindAllCommitted``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}-'></a>
### SetupFindAllCommitted\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters) `method`

##### Summary

Sets up the FindAllCommitted method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions". See
https://andculture.atlassian.net/browse/CCALMS2-599

##### Returns

A setup FindAllCommitted method on the supplied mocked conductor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mock | [Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{\`\`0}}](#T-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}} 'Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}}') | The read repository conductor being mocked. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value for includeProperties to be setup (optional) |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for skip to be setup (optional) |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for take to be setup (optional) |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | The value for ignoreQueryFilters to be setup (optional) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The model type applied to the repository read conductor. |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-Mocks-Conductors-IRepositoryReadConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}-'></a>
### SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Sets up the FindAll method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions". See
https://andculture.atlassian.net/browse/CCALMS2-599

##### Returns

A setup FindAll method on the supplied mocked conductor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mock | [Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{\`\`0}}](#T-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}} 'Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}}') | The read repository conductor being mocked. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value for includeProperties to be setup (optional) |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for skip to be setup (optional) |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The value for take to be setup (optional) |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | The value for ignoreQueryFilters to be setup (optional) |
| asNoTracking | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | The value for asNoTracking to be setup (optional) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The model type applied to the repository read conductor. |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions'></a>
## IResultMatcherExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for asserting expected states of the \`IResult\` interface

<a name='F-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ERROR_ERRORS_LIST_IS_NULL_MESSAGE'></a>
### ERROR_ERRORS_LIST_IS_NULL_MESSAGE `constants`

##### Summary

Detailed output message to display when expecting errors on a result that has a null \`Errors\` property

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveBasicError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldHaveBasicError\`\`1(result) `method`

##### Summary

Assert result has error for \`BASIC_ERROR_KEY\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Boolean},System-Nullable{System-Int32}-'></a>
### ShouldHaveErrors(result,exactCount) `method`

##### Summary

Assert that the result has at least one error

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{System.Boolean}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Boolean} 'AndcultureCode.CSharp.Core.Interfaces.IResult{System.Boolean}') | Result under test |
| exactCount | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | When supplied, asserts the result has this exact number of errors |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String,System-Nullable{System-Int32},System-String-'></a>
### ShouldHaveErrorsFor\`\`1(result,property,exactCount,containedInMessage) `method`

##### Summary

Assert that there are errors for the supplied property

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| property | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the error to be asserted against |
| exactCount | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | When supplied, asserts the exact number of errors with the property. NOT total number of errors |
| containedInMessage | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | When supplied, asserts that the property's error message contains this string |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Nullable{System-Int32}-'></a>
### ShouldHaveErrors\`\`1(result,exactCount) `method`

##### Summary

Assert that the result has at least one error

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| exactCount | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | When supplied, asserts the result has this exact number of errors |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String-'></a>
### ShouldNotHaveErrorsFor\`\`1(result,property) `method`

##### Summary

Assert that there weren't any errors for the supplied property

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| property | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the error to be asserted against |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldNotHaveErrors\`\`1(result) `method`

##### Summary

Assert that there are no errors for the given result

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
