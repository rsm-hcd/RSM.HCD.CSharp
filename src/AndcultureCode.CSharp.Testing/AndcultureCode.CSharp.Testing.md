<a name='assembly'></a>
# AndcultureCode.CSharp.Testing

## Contents

- [BaseIntegrationTest](#T-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest')
  - [BuildTo\`\`2()](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2')
  - [BuildTo\`\`2(name)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.String)')
  - [BuildTo\`\`2(property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.Action{``0})')
  - [BuildTo\`\`2(name,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.String,System.Action{``0})')
  - [BuildTo\`\`2(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.Collections.Generic.List{System.Action{``0}})')
  - [BuildTo\`\`2(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.Action{``0}[])')
  - [BuildTo\`\`2(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.BuildTo``2(System.String,System.Collections.Generic.List{System.Action{``0}})')
  - [CreateList\`\`1(count)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32)')
  - [CreateList\`\`1(count,name)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.String)')
  - [CreateList\`\`1(count,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.Action{``0})')
  - [CreateList\`\`1(count,name,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.String,System.Action{``0})')
  - [CreateList\`\`1(count,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.Collections.Generic.List{System.Action{``0}})')
  - [CreateList\`\`1(count,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.Action{``0}[])')
  - [CreateList\`\`1(count,name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.String,System.Collections.Generic.List{System.Action{``0}})')
  - [CreateList\`\`1(count,name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.String,System.Action{``0}[])')
  - [CreateList\`\`1(count,builderFunc)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Func{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateList``1(System.Int32,System.Func{``0})')
  - [CreateTo\`\`2()](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2')
  - [CreateTo\`\`2(name)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.String)')
  - [CreateTo\`\`2(property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.Action{``0})')
  - [CreateTo\`\`2(name,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.String,System.Action{``0})')
  - [CreateTo\`\`2(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.Collections.Generic.List{System.Action{``0}})')
  - [CreateTo\`\`2(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.Action{``0}[])')
  - [CreateTo\`\`2(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.CreateTo``2(System.String,System.Collections.Generic.List{System.Action{``0}})')
  - [Create\`\`1()](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1')
  - [Create\`\`1(name)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.String)')
  - [Create\`\`1(property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.Action{``0})')
  - [Create\`\`1(name,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.String,System.Action{``0})')
  - [Create\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.Collections.Generic.List{System.Action{``0}})')
  - [Create\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.Action{``0}[])')
  - [Create\`\`1(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.String,System.Collections.Generic.List{System.Action{``0}})')
  - [Create\`\`1(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(System.String,System.Action{``0}[])')
  - [Create\`\`1(context,item)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-AndcultureCode-CSharp-Core-Interfaces-IContext,``0- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Create``1(AndcultureCode.CSharp.Core.Interfaces.IContext,``0)')
  - [GetRepositoryConductorDeps\`\`1(repository)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-GetRepositoryConductorDeps``1-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.GetRepositoryConductorDeps``1(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{``0})')
  - [Map\`\`2(entity)](#M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Map``2-``0- 'AndcultureCode.CSharp.Testing.Tests.BaseIntegrationTest.Map``2(``0)')
- [BaseTest](#T-AndcultureCode-CSharp-Testing-Tests-BaseTest 'AndcultureCode.CSharp.Testing.Tests.BaseTest')
  - [#ctor(output)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#ctor-Xunit-Abstractions-ITestOutputHelper- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.#ctor(Xunit.Abstractions.ITestOutputHelper)')
  - [Faker](#P-AndcultureCode-CSharp-Testing-Tests-BaseTest-Faker 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Faker')
  - [Random](#P-AndcultureCode-CSharp-Testing-Tests-BaseTest-Random 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Random')
  - [#cctor()](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#cctor 'AndcultureCode.CSharp.Testing.Tests.BaseTest.#cctor')
  - [BuildList\`\`1(count)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildList``1-System-Int32- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.BuildList``1(System.Int32)')
  - [BuildResult\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildResult``1-System-Action{AndcultureCode-CSharp-Core-Models-Errors-Result{``0}}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.BuildResult``1(System.Action{AndcultureCode.CSharp.Core.Models.Errors.Result{``0}}[])')
  - [Build\`\`1()](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1')
  - [Build\`\`1(name)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.String)')
  - [Build\`\`1(property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.Action{``0})')
  - [Build\`\`1(name,property)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Action{``0}- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.String,System.Action{``0})')
  - [Build\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.Collections.Generic.List{System.Action{``0}})')
  - [Build\`\`1(properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.Action{``0}[])')
  - [Build\`\`1(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Collections-Generic-List{System-Action{``0}}- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.String,System.Collections.Generic.List{System.Action{``0}})')
  - [Build\`\`1(name,properties)](#M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Action{``0}[]- 'AndcultureCode.CSharp.Testing.Tests.BaseTest.Build``1(System.String,System.Action{``0}[])')
- [ErrorFactory](#T-AndcultureCode-CSharp-Testing-Factories-ErrorFactory 'AndcultureCode.CSharp.Testing.Factories.ErrorFactory')
  - [BASIC_ERROR](#F-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-BASIC_ERROR 'AndcultureCode.CSharp.Testing.Factories.ErrorFactory.BASIC_ERROR')
  - [RESOURCE_NOT_FOUND_ERROR](#F-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-RESOURCE_NOT_FOUND_ERROR 'AndcultureCode.CSharp.Testing.Factories.ErrorFactory.RESOURCE_NOT_FOUND_ERROR')
  - [Define()](#M-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-Define 'AndcultureCode.CSharp.Testing.Factories.ErrorFactory.Define')
- [Factory](#T-AndcultureCode-CSharp-Testing-Factories-Factory 'AndcultureCode.CSharp.Testing.Factories.Factory')
  - [Faker](#P-AndcultureCode-CSharp-Testing-Factories-Factory-Faker 'AndcultureCode.CSharp.Testing.Factories.Factory.Faker')
  - [Milliseconds](#P-AndcultureCode-CSharp-Testing-Factories-Factory-Milliseconds 'AndcultureCode.CSharp.Testing.Factories.Factory.Milliseconds')
  - [Random](#P-AndcultureCode-CSharp-Testing-Factories-Factory-Random 'AndcultureCode.CSharp.Testing.Factories.Factory.Random')
  - [UniqueNumber](#P-AndcultureCode-CSharp-Testing-Factories-Factory-UniqueNumber 'AndcultureCode.CSharp.Testing.Factories.Factory.UniqueNumber')
  - [Define()](#M-AndcultureCode-CSharp-Testing-Factories-Factory-Define 'AndcultureCode.CSharp.Testing.Factories.Factory.Define')
- [FactorySettings](#T-AndcultureCode-CSharp-Testing-Factories-FactorySettings 'AndcultureCode.CSharp.Testing.Factories.FactorySettings')
  - [Debug](#P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Debug 'AndcultureCode.CSharp.Testing.Factories.FactorySettings.Debug')
  - [Instance](#P-AndcultureCode-CSharp-Testing-Factories-FactorySettings-Instance 'AndcultureCode.CSharp.Testing.Factories.FactorySettings.Instance')
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
- [IActionResultMatcherExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions')
  - [AsAccepted\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsAccepted``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsAccepted``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsBadRequest\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsBadRequest``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsBadRequest``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsBadRequest\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsBadRequest``1-System-Threading-Tasks-Task{Microsoft-AspNetCore-Mvc-IActionResult}- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsBadRequest``1(System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult})')
  - [AsConflict\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsConflict``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsConflict``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsCreated\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsCreated``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsCreated``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsFile()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsFile-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsFile(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsForbidden\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsForbidden``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsForbidden``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsHttpResult\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsHttpResult``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsHttpResult``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsHttpResult\`\`2(action,statusCode)](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsHttpResult``2-Microsoft-AspNetCore-Mvc-IActionResult,System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsHttpResult``2(Microsoft.AspNetCore.Mvc.IActionResult,System.Nullable{System.Int32})')
  - [AsInternalError\`\`1(action,shouldValidateType)](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsInternalError``1-Microsoft-AspNetCore-Mvc-IActionResult,System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsInternalError``1(Microsoft.AspNetCore.Mvc.IActionResult,System.Nullable{System.Boolean})')
  - [AsNoContent()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsNoContent-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsNoContent(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsNotFound\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsNotFound``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsNotFound``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsOk\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsOk``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsOk``1(Microsoft.AspNetCore.Mvc.IActionResult)')
  - [AsUnauthorized\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsUnauthorized``1-Microsoft-AspNetCore-Mvc-IActionResult- 'AndcultureCode.CSharp.Testing.Extensions.IActionResultMatcherExtensions.AsUnauthorized``1(Microsoft.AspNetCore.Mvc.IActionResult)')
- [IEnumerableMatcherExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions 'AndcultureCode.CSharp.Testing.Extensions.IEnumerableMatcherExtensions')
  - [ShouldBeOfSize\`\`1(items,expectedSize)](#M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOfSize``1-System-Collections-Generic-IEnumerable{``0},System-Int32- 'AndcultureCode.CSharp.Testing.Extensions.IEnumerableMatcherExtensions.ShouldBeOfSize``1(System.Collections.Generic.IEnumerable{``0},System.Int32)')
  - [ShouldBeOrderedByDescending\`\`2(items,keySelector)](#M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOrderedByDescending``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}- 'AndcultureCode.CSharp.Testing.Extensions.IEnumerableMatcherExtensions.ShouldBeOrderedByDescending``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})')
  - [ShouldBeOrderedBy\`\`2(items,keySelector)](#M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOrderedBy``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}- 'AndcultureCode.CSharp.Testing.Extensions.IEnumerableMatcherExtensions.ShouldBeOrderedBy``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})')
  - [ShouldContain\`\`1(actual,expected)](#M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldContain``1-System-Collections-Generic-IEnumerable{``0},System-Collections-Generic-IEnumerable{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IEnumerableMatcherExtensions.ShouldContain``1(System.Collections.Generic.IEnumerable{``0},System.Collections.Generic.IEnumerable{``0})')
- [IRepositoryConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryConductorMockExtensions')
  - [SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryConductorMockExtensions.SetupFindAll``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Nullable{System.Boolean})')
- [IRepositoryCreateConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryCreateConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryCreateConductorMockExtensions')
- [IRepositoryDeleteConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryDeleteConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryDeleteConductorMockExtensions')
- [IRepositoryReadConductorMockExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryReadConductorMockExtensions')
  - [SetupFindAllCommitted\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions-SetupFindAllCommitted``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryReadConductorMockExtensions.SetupFindAllCommitted``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean})')
  - [SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Testing.Extensions.IRepositoryReadConductorMockExtensions.SetupFindAll``1(Moq.Mock{AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{``0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Nullable{System.Boolean})')
- [IResultMatcherExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions')
  - [ERROR_ERRORS_LIST_IS_NULL_MESSAGE](#F-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ERROR_ERRORS_LIST_IS_NULL_MESSAGE 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE')
  - [ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE](#F-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE')
  - [ShouldBeCreatedBy\`\`1(result,createdById)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeCreatedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.Int64)')
  - [ShouldBeCreatedBy\`\`1(result,createdBy)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeCreatedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity)')
  - [ShouldBeCreated\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreated``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeCreated``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldBeDeletedBy\`\`1(result,deletedById)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeletedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeDeletedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.Int64)')
  - [ShouldBeDeletedBy\`\`1(result,deletedBy)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeletedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeDeletedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity)')
  - [ShouldBeDeleted\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeleted``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeDeleted``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldBeUpdatedBy\`\`1(result,updatedById)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeUpdatedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.Int64)')
  - [ShouldBeUpdatedBy\`\`1(result,updatedBy)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeUpdatedBy``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity)')
  - [ShouldBeUpdated\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdated``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldBeUpdated``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldHaveBasicError\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveBasicError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveBasicError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldHaveErrors(result,exactCount)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Boolean},System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrors(AndcultureCode.CSharp.Core.Interfaces.IResult{System.Boolean},System.Nullable{System.Int32})')
  - [ShouldHaveErrorsFor\`\`1(result,property,exactCount,containedInMessage)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String,System-Nullable{System-Int32},System-String- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrorsFor``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String,System.Nullable{System.Int32},System.String)')
  - [ShouldHaveErrors\`\`1(result,exactCount)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveErrors``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.Nullable{System.Int32})')
  - [ShouldHaveResourceNotFoundError\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResourceNotFoundError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveResourceNotFoundError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldHaveResultObject\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResultObject``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveResultObject``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [ShouldHaveResultObjects\`\`1(result,exactCount)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResultObjects``1-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Collections-Generic-IEnumerable{``0}},System-Nullable{System-Int32}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldHaveResultObjects``1(AndcultureCode.CSharp.Core.Interfaces.IResult{System.Collections.Generic.IEnumerable{``0}},System.Nullable{System.Int32})')
  - [ShouldNotHaveErrorsFor\`\`1(result,property)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldNotHaveErrorsFor``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String)')
  - [ShouldNotHaveErrors\`\`1(result)](#M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Testing.Extensions.IResultMatcherExtensions.ShouldNotHaveErrors``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
- [ISetupExtensions](#T-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions 'AndcultureCode.CSharp.Testing.Extensions.ISetupExtensions')
  - [ReturnsBasicErrorResult\`\`2()](#M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsBasicErrorResult``2-Moq-Language-Flow-ISetup{``0,AndcultureCode-CSharp-Core-Interfaces-IResult{``1}},``1- 'AndcultureCode.CSharp.Testing.Extensions.ISetupExtensions.ReturnsBasicErrorResult``2(Moq.Language.Flow.ISetup{``0,AndcultureCode.CSharp.Core.Interfaces.IResult{``1}},``1)')
  - [ReturnsBasicErrorSequentialResult\`\`1()](#M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsBasicErrorSequentialResult``1-Moq-Language-ISetupSequentialResult{AndcultureCode-CSharp-Core-Interfaces-IResult{``0}},``0- 'AndcultureCode.CSharp.Testing.Extensions.ISetupExtensions.ReturnsBasicErrorSequentialResult``1(Moq.Language.ISetupSequentialResult{AndcultureCode.CSharp.Core.Interfaces.IResult{``0}},``0)')
  - [ReturnsGivenResult\`\`2()](#M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsGivenResult``2-Moq-Language-Flow-ISetup{``0,AndcultureCode-CSharp-Core-Interfaces-IResult{``1}},``1- 'AndcultureCode.CSharp.Testing.Extensions.ISetupExtensions.ReturnsGivenResult``2(Moq.Language.Flow.ISetup{``0,AndcultureCode.CSharp.Core.Interfaces.IResult{``1}},``1)')
  - [ReturnsGivenSequentialResult\`\`1(setup,resultObject)](#M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsGivenSequentialResult``1-Moq-Language-ISetupSequentialResult{AndcultureCode-CSharp-Core-Interfaces-IResult{``0}},``0- 'AndcultureCode.CSharp.Testing.Extensions.ISetupExtensions.ReturnsGivenSequentialResult``1(Moq.Language.ISetupSequentialResult{AndcultureCode.CSharp.Core.Interfaces.IResult{``0}},``0)')
- [UserStub](#T-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub')
  - [EmailAddress](#P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-EmailAddress 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub.EmailAddress')
  - [FirstName](#P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-FirstName 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub.FirstName')
  - [LastName](#P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-LastName 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub.LastName')
  - [RelatedUserStub](#P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-RelatedUserStub 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub.RelatedUserStub')
  - [RelatedUserStubId](#P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-RelatedUserStubId 'AndcultureCode.CSharp.Testing.Models.Stubs.UserStub.RelatedUserStubId')
- [UserStubFactory](#T-AndcultureCode-CSharp-Testing-Factories-UserStubFactory 'AndcultureCode.CSharp.Testing.Factories.UserStubFactory')
  - [WITH_GMAIL_EMAIL](#F-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-WITH_GMAIL_EMAIL 'AndcultureCode.CSharp.Testing.Factories.UserStubFactory.WITH_GMAIL_EMAIL')
  - [WITH_YAHOO_EMAIL](#F-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-WITH_YAHOO_EMAIL 'AndcultureCode.CSharp.Testing.Factories.UserStubFactory.WITH_YAHOO_EMAIL')
  - [Define()](#M-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-Define 'AndcultureCode.CSharp.Testing.Factories.UserStubFactory.Define')

<a name='T-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest'></a>
## BaseIntegrationTest `type`

##### Namespace

AndcultureCode.CSharp.Testing.Tests

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2'></a>
### BuildTo\`\`2() `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String-'></a>
### BuildTo\`\`2(name) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Action{``0}-'></a>
### BuildTo\`\`2(property) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String,System-Action{``0}-'></a>
### BuildTo\`\`2(name,property) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Collections-Generic-List{System-Action{``0}}-'></a>
### BuildTo\`\`2(properties) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-Action{``0}[]-'></a>
### BuildTo\`\`2(properties) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-BuildTo``2-System-String,System-Collections-Generic-List{System-Action{``0}}-'></a>
### BuildTo\`\`2(name,properties) `method`

##### Summary

Builds and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32-'></a>
### CreateList\`\`1(count) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String-'></a>
### CreateList\`\`1(count,name) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Action{``0}-'></a>
### CreateList\`\`1(count,property) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Action{``0}-'></a>
### CreateList\`\`1(count,name,property) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Collections-Generic-List{System-Action{``0}}-'></a>
### CreateList\`\`1(count,properties) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Action{``0}[]-'></a>
### CreateList\`\`1(count,properties) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Collections-Generic-List{System-Action{``0}}-'></a>
### CreateList\`\`1(count,name,properties) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-String,System-Action{``0}[]-'></a>
### CreateList\`\`1(count,name,properties) `method`

##### Summary

Creates a list of entities of type T.

##### Returns

List of created entities

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of entities to be created |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateList``1-System-Int32,System-Func{``0}-'></a>
### CreateList\`\`1(count,builderFunc) `method`

##### Summary

Helper function for the various CreateList method overloads

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| builderFunc | [System.Func{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2'></a>
### CreateTo\`\`2() `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String-'></a>
### CreateTo\`\`2(name) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Action{``0}-'></a>
### CreateTo\`\`2(property) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String,System-Action{``0}-'></a>
### CreateTo\`\`2(name,property) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Collections-Generic-List{System-Action{``0}}-'></a>
### CreateTo\`\`2(properties) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-Action{``0}[]-'></a>
### CreateTo\`\`2(properties) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-CreateTo``2-System-String,System-Collections-Generic-List{System-Action{``0}}-'></a>
### CreateTo\`\`2(name,properties) `method`

##### Summary

Creates and maps an entity to the target type.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |
| TTarget | Type to map entity to |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1'></a>
### Create\`\`1() `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String-'></a>
### Create\`\`1(name) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Action{``0}-'></a>
### Create\`\`1(property) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Action{``0}-'></a>
### Create\`\`1(name,property) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Collections-Generic-List{System-Action{``0}}-'></a>
### Create\`\`1(properties) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-Action{``0}[]-'></a>
### Create\`\`1(properties) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Collections-Generic-List{System-Action{``0}}-'></a>
### Create\`\`1(name,properties) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Create``1-System-String,System-Action{``0}[]-'></a>
### Create\`\`1(name,properties) `method`

##### Summary

Creates entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

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

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseIntegrationTest-Map``2-``0-'></a>
### Map\`\`2(entity) `method`

##### Summary

Maps an entity to the target type

##### Returns

Mapped entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Source type of entity |
| TTarget | Destination type to map entity to |

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

<a name='P-AndcultureCode-CSharp-Testing-Tests-BaseTest-Faker'></a>
### Faker `property`

##### Summary

Cached instance of 'Faker' to use for specific data generation functions not available
from Randomizer (such as email addresses, ip addresses, names, etc.)

##### Returns



<a name='P-AndcultureCode-CSharp-Testing-Tests-BaseTest-Random'></a>
### Random `property`

##### Summary

Wrapper property for accessing the 'Randomizer' instance of 'Faker' directly. This field
will instantiate a new Faker instance if it has not yet been accessed directly.

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-#cctor'></a>
### #cctor() `method`

##### Summary

Static constructor to set up suite-level actors

 Most recent performance test: .04 milliseconds / ~47 microseconds

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildList``1-System-Int32-'></a>
### BuildList\`\`1(count) `method`

##### Summary

Builds a list of entity type T. A factory for type T must be defined.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-BuildResult``1-System-Action{AndcultureCode-CSharp-Core-Models-Errors-Result{``0}}[]-'></a>
### BuildResult\`\`1(properties) `method`

##### Summary

Factory method for setting properties directly on a new Result. Sets the \`ResultObject\`
to the default value of T, but can be nested with other factory methods if a specific
configuration of \`T\` is required.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{AndcultureCode.CSharp.Core.Models.Errors.Result{\`\`0}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{AndcultureCode.CSharp.Core.Models.Errors.Result{``0}}[]') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1'></a>
### Build\`\`1() `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String-'></a>
### Build\`\`1(name) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Action{``0}-'></a>
### Build\`\`1(property) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Action{``0}-'></a>
### Build\`\`1(name,property) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| property | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Function to set a specific property on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Collections-Generic-List{System-Action{``0}}-'></a>
### Build\`\`1(properties) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-Action{``0}[]-'></a>
### Build\`\`1(properties) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Collections-Generic-List{System-Action{``0}}-'></a>
### Build\`\`1(name,properties) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Collections.Generic.List{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Action{``0}}') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='M-AndcultureCode-CSharp-Testing-Tests-BaseTest-Build``1-System-String,System-Action{``0}[]-'></a>
### Build\`\`1(name,properties) `method`

##### Summary

Builds entity of type T.

##### Returns

Created entity

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Named factory to be used for creation |
| properties | [System.Action{\`\`0}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}[]') | Functions to set properties on the created entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of entity to create |

<a name='T-AndcultureCode-CSharp-Testing-Factories-ErrorFactory'></a>
## ErrorFactory `type`

##### Namespace

AndcultureCode.CSharp.Testing.Factories

##### Summary

Factory for building out configurations of the \`Error\` class

<a name='F-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-BASIC_ERROR'></a>
### BASIC_ERROR `constants`

##### Summary

Represents a basic error for testing.

<a name='F-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-RESOURCE_NOT_FOUND_ERROR'></a>
### RESOURCE_NOT_FOUND_ERROR `constants`

##### Summary

Represents a 'RESOURCE_NOT_FOUND' error using the Core error key.

<a name='M-AndcultureCode-CSharp-Testing-Factories-ErrorFactory-Define'></a>
### Define() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Testing-Factories-Factory'></a>
## Factory `type`

##### Namespace

AndcultureCode.CSharp.Testing.Factories

##### Summary

Base factory class for building out entity configurations

<a name='P-AndcultureCode-CSharp-Testing-Factories-Factory-Faker'></a>
### Faker `property`

##### Summary

Cached instance of 'Faker' to use for specific data generation functions not available
from Randomizer (such as email addresses, ip addresses, names, etc.)

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

Returns a cached \`Randomizer\` instance for generating random data as factory values.

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

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions'></a>
## IActionResultMatcherExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Testing matchers for asserting controller responses

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsAccepted``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsAccepted\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Accepted'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsBadRequest``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsBadRequest\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'BadRequest'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsBadRequest``1-System-Threading-Tasks-Task{Microsoft-AspNetCore-Mvc-IActionResult}-'></a>
### AsBadRequest\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'BadRequest'
and additionally the result object is of the supplied type 'T'
///

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsConflict``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsConflict\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Conflict'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsCreated``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsCreated\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Created'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsFile-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsFile() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'FileContentResult'

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsForbidden``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsForbidden\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Forbidden'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsHttpResult``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsHttpResult\`\`1() `method`

##### Summary

Verifies the result is the correct requested HTTP response type
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsHttpResult``2-Microsoft-AspNetCore-Mvc-IActionResult,System-Nullable{System-Int32}-'></a>
### AsHttpResult\`\`2(action,statusCode) `method`

##### Summary

Verifies the result is the correct requested HTTP response type
and additionally the result object's body is of the supplied type 'T'

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Microsoft.AspNetCore.Mvc.IActionResult](#T-Microsoft-AspNetCore-Mvc-IActionResult 'Microsoft.AspNetCore.Mvc.IActionResult') |  |
| statusCode | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| THttpResult |  |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsInternalError``1-Microsoft-AspNetCore-Mvc-IActionResult,System-Nullable{System-Boolean}-'></a>
### AsInternalError\`\`1(action,shouldValidateType) `method`

##### Summary

Verifies the result is the correct HTTP response type of 'InternalError'
and additionally the result object is of the supplied type 'T'

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Microsoft.AspNetCore.Mvc.IActionResult](#T-Microsoft-AspNetCore-Mvc-IActionResult 'Microsoft.AspNetCore.Mvc.IActionResult') |  |
| shouldValidateType | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | Use 'false' when value of response is NULL to bypass type checking |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsNoContent-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsNoContent() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'NoContent'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsNotFound``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsNotFound\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'NotFound'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsOk``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsOk\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Ok'
and additionally the result object is of the supplied type 'T'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IActionResultMatcherExtensions-AsUnauthorized``1-Microsoft-AspNetCore-Mvc-IActionResult-'></a>
### AsUnauthorized\`\`1() `method`

##### Summary

Verifies the result is the correct HTTP response type of 'Unauthorized'

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions'></a>
## IEnumerableMatcherExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for asserting expected states of \`IEnumerable\` types

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOfSize``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
### ShouldBeOfSize\`\`1(items,expectedSize) `method`

##### Summary

Assert that an IEnumerable{T} has a certain length.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| expectedSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Shouldly.ShouldAssertException](#T-Shouldly-ShouldAssertException 'Shouldly.ShouldAssertException') |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOrderedByDescending``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}-'></a>
### ShouldBeOrderedByDescending\`\`2(items,keySelector) `method`

##### Summary

Assert that a list of T is ordered (descending) by property of type V.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| keySelector | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TValue |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Shouldly.ShouldAssertException](#T-Shouldly-ShouldAssertException 'Shouldly.ShouldAssertException') |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldBeOrderedBy``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}-'></a>
### ShouldBeOrderedBy\`\`2(items,keySelector) `method`

##### Summary

Assert that a list of T is ordered (ascending) by property of type V.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| keySelector | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TValue |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Shouldly.ShouldAssertException](#T-Shouldly-ShouldAssertException 'Shouldly.ShouldAssertException') |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IEnumerableMatcherExtensions-ShouldContain``1-System-Collections-Generic-IEnumerable{``0},System-Collections-Generic-IEnumerable{``0}-'></a>
### ShouldContain\`\`1(actual,expected) `method`

##### Summary

Asserts if a collection contains the exact values in the supplied collection

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| actual | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| expected | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryConductorMockExtensions'></a>
## IRepositoryConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for mocking methods of the \`IRepositoryConductor\` interface

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}-'></a>
### SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Sets up the FindAll method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions".

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

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryCreateConductorMockExtensions'></a>
## IRepositoryCreateConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for mocking methods of the \`IRepositoryCreateConductor\` interface

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryDeleteConductorMockExtensions'></a>
## IRepositoryDeleteConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for mocking methods of the \`IRepositoryDeleteConductor\` interface

<a name='T-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions'></a>
## IRepositoryReadConductorMockExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Extension methods for mocking methods of the \`IRepositoryReadConductor\` interface

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions-SetupFindAllCommitted``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}-'></a>
### SetupFindAllCommitted\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters) `method`

##### Summary

Sets up the FindAllCommitted method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions". See
https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/issues/28

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

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IRepositoryReadConductorMockExtensions-SetupFindAll``1-Moq-Mock{AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{``0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Nullable{System-Boolean}-'></a>
### SetupFindAll\`\`1(mock,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Sets up the FindAll method on a repository read conductor.
NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
via parameters. There seems to be an issue around Moq and c# "Expressions". See
https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/issues/28

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

<a name='F-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE'></a>
### ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE `constants`

##### Summary

Friendlier output message to display when expected entity is not valid for test assertion to continue

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64-'></a>
### ShouldBeCreatedBy\`\`1(result,createdById) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`CreatedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| createdById | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Expected id of the record's creator |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity-'></a>
### ShouldBeCreatedBy\`\`1(result,createdBy) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`CreatedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| createdBy | [AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity](#T-AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity 'AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity') | Expected record's creator |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeCreated``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldBeCreated\`\`1(result) `method`

##### Summary

Assert that the \`ResultObject\` has a \`CreatedOn\` value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeletedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64-'></a>
### ShouldBeDeletedBy\`\`1(result,deletedById) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`DeletedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| deletedById | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Expected id of the record's deletor |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeletedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity-'></a>
### ShouldBeDeletedBy\`\`1(result,deletedBy) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`DeletedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| deletedBy | [AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity](#T-AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity 'AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity') | Expected record's deletor |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeDeleted``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldBeDeleted\`\`1(result) `method`

##### Summary

Assert that the \`ResultObject\` has a \`DeletedOn\` value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Int64-'></a>
### ShouldBeUpdatedBy\`\`1(result,updatedById) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`UpdatedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| updatedById | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Expected id of the record's updater |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdatedBy``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity-'></a>
### ShouldBeUpdatedBy\`\`1(result,updatedBy) `method`

##### Summary

Assert that the \`ResultObject\` has the expected \`UpdatedById\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| updatedBy | [AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity](#T-AndcultureCode-CSharp-Core-Interfaces-Entity-IEntity 'AndcultureCode.CSharp.Core.Interfaces.Entity.IEntity') | Expected record's updater |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldBeUpdated``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldBeUpdated\`\`1(result) `method`

##### Summary

Assert that the \`ResultObject\` has an \`UpdatedOn\` value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveBasicError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldHaveBasicError\`\`1(result) `method`

##### Summary

Assert result has error for \`BASIC_ERROR_KEY\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

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

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-Nullable{System-Int32}-'></a>
### ShouldHaveErrors\`\`1(result,exactCount) `method`

##### Summary

Assert that the result has at least one error

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| exactCount | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | When supplied, asserts the result has this exact number of errors |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResourceNotFoundError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldHaveResourceNotFoundError\`\`1(result) `method`

##### Summary

Assert error exists for \`ERROR_RESOURCE_NOT_FOUND_KEY\`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResultObject``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldHaveResultObject\`\`1(result) `method`

##### Summary

Assert that \`ResultObject\` is not null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldHaveResultObjects``1-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Collections-Generic-IEnumerable{``0}},System-Nullable{System-Int32}-'></a>
### ShouldHaveResultObjects\`\`1(result,exactCount) `method`

##### Summary

Assert that an IEnumerable \`ResultObject\` has values

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{System.Collections.Generic.IEnumerable{\`\`0}}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{System-Collections-Generic-IEnumerable{``0}} 'AndcultureCode.CSharp.Core.Interfaces.IResult{System.Collections.Generic.IEnumerable{``0}}') | Result under test |
| exactCount | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | When supplied, asserts that the collection has exactly this number of elements |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrorsFor``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String-'></a>
### ShouldNotHaveErrorsFor\`\`1(result,property) `method`

##### Summary

Assert that there weren't any errors for the supplied property

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |
| property | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the error to be asserted against |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-IResultMatcherExtensions-ShouldNotHaveErrors``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### ShouldNotHaveErrors\`\`1(result) `method`

##### Summary

Assert that there are no errors for the given result

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | Result under test |

<a name='T-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions'></a>
## ISetupExtensions `type`

##### Namespace

AndcultureCode.CSharp.Testing.Extensions

##### Summary

Setup extension methods.

<a name='M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsBasicErrorResult``2-Moq-Language-Flow-ISetup{``0,AndcultureCode-CSharp-Core-Interfaces-IResult{``1}},``1-'></a>
### ReturnsBasicErrorResult\`\`2() `method`

##### Summary

Returns basic error result.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TResult |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsBasicErrorSequentialResult``1-Moq-Language-ISetupSequentialResult{AndcultureCode-CSharp-Core-Interfaces-IResult{``0}},``0-'></a>
### ReturnsBasicErrorSequentialResult\`\`1() `method`

##### Summary

Returns basic error sequential result.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsGivenResult``2-Moq-Language-Flow-ISetup{``0,AndcultureCode-CSharp-Core-Interfaces-IResult{``1}},``1-'></a>
### ReturnsGivenResult\`\`2() `method`

##### Summary

Returns given result.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TResult |  |

<a name='M-AndcultureCode-CSharp-Testing-Extensions-ISetupExtensions-ReturnsGivenSequentialResult``1-Moq-Language-ISetupSequentialResult{AndcultureCode-CSharp-Core-Interfaces-IResult{``0}},``0-'></a>
### ReturnsGivenSequentialResult\`\`1(setup,resultObject) `method`

##### Summary

Returns given result in sequence of the setup.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| setup | [Moq.Language.ISetupSequentialResult{AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}}](#T-Moq-Language-ISetupSequentialResult{AndcultureCode-CSharp-Core-Interfaces-IResult{``0}} 'Moq.Language.ISetupSequentialResult{AndcultureCode.CSharp.Core.Interfaces.IResult{``0}}') |  |
| resultObject | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult |  |

<a name='T-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub'></a>
## UserStub `type`

##### Namespace

AndcultureCode.CSharp.Testing.Models.Stubs

##### Summary

Stub entity representing a User

<a name='P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-EmailAddress'></a>
### EmailAddress `property`

##### Summary

Email address of the stub user

<a name='P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-FirstName'></a>
### FirstName `property`

##### Summary

First name of the stub user

<a name='P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-LastName'></a>
### LastName `property`

##### Summary

Last name of the stub user

<a name='P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-RelatedUserStub'></a>
### RelatedUserStub `property`

##### Summary

Related stub user for testing navigation properties

<a name='P-AndcultureCode-CSharp-Testing-Models-Stubs-UserStub-RelatedUserStubId'></a>
### RelatedUserStubId `property`

##### Summary

Id of a related stub user

<a name='T-AndcultureCode-CSharp-Testing-Factories-UserStubFactory'></a>
## UserStubFactory `type`

##### Namespace

AndcultureCode.CSharp.Testing.Factories

##### Summary

Factory for building out configurations of the \`UserStub\` class

<a name='F-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-WITH_GMAIL_EMAIL'></a>
### WITH_GMAIL_EMAIL `constants`

##### Summary

Returns a user stub with a gmail address

<a name='F-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-WITH_YAHOO_EMAIL'></a>
### WITH_YAHOO_EMAIL `constants`

##### Summary

Returns a user stub with a yahoo address

<a name='M-AndcultureCode-CSharp-Testing-Factories-UserStubFactory-Define'></a>
### Define() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
