<a name='assembly'></a>
# AndcultureCode.CSharp.Extensions

## Contents

- [ApiClaimTypes](#T-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes')
  - [IS_SUPER_ADMIN](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-IS_SUPER_ADMIN 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.IS_SUPER_ADMIN')
  - [ROLE_ID](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_ID 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.ROLE_ID')
  - [ROLE_IDS](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_IDS 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.ROLE_IDS')
  - [ROLE_TYPE](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_TYPE 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.ROLE_TYPE')
  - [USER_ID](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-USER_ID 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.USER_ID')
  - [USER_LOGIN_ID](#F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-USER_LOGIN_ID 'AndcultureCode.CSharp.Core.Constants.ApiClaimTypes.USER_LOGIN_ID')
- [ClaimsPrincipalExtensions](#T-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions')
  - [IsAuthenticated(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsAuthenticated-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.IsAuthenticated(System.Security.Claims.ClaimsPrincipal)')
  - [IsSuperAdmin(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsSuperAdmin-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.IsSuperAdmin(System.Security.Claims.ClaimsPrincipal)')
  - [IsUnauthenticated(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsUnauthenticated-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.IsUnauthenticated(System.Security.Claims.ClaimsPrincipal)')
  - [RoleId(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-RoleId-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.RoleId(System.Security.Claims.ClaimsPrincipal)')
  - [RoleIds(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-RoleIds-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.RoleIds(System.Security.Claims.ClaimsPrincipal)')
  - [UserId(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-UserId-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.UserId(System.Security.Claims.ClaimsPrincipal)')
  - [UserLoginId(principal)](#M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-UserLoginId-System-Security-Claims-ClaimsPrincipal- 'AndcultureCode.CSharp.Extensions.ClaimsPrincipalExtensions.UserLoginId(System.Security.Claims.ClaimsPrincipal)')
- [DateExtensions](#T-AndcultureCode-CSharp-Extensions-DateExtensions 'AndcultureCode.CSharp.Extensions.DateExtensions')
  - [AtEndOfDay(date)](#M-AndcultureCode-CSharp-Extensions-DateExtensions-AtEndOfDay-System-DateTimeOffset- 'AndcultureCode.CSharp.Extensions.DateExtensions.AtEndOfDay(System.DateTimeOffset)')
  - [AtMidnight(date)](#M-AndcultureCode-CSharp-Extensions-DateExtensions-AtMidnight-System-DateTimeOffset- 'AndcultureCode.CSharp.Extensions.DateExtensions.AtMidnight(System.DateTimeOffset)')
  - [CalculateAge()](#M-AndcultureCode-CSharp-Extensions-DateExtensions-CalculateAge-System-DateTime- 'AndcultureCode.CSharp.Extensions.DateExtensions.CalculateAge(System.DateTime)')
  - [IsBetweenDates()](#M-AndcultureCode-CSharp-Extensions-DateExtensions-IsBetweenDates-System-DateTimeOffset,System-DateTimeOffset,System-DateTimeOffset- 'AndcultureCode.CSharp.Extensions.DateExtensions.IsBetweenDates(System.DateTimeOffset,System.DateTimeOffset,System.DateTimeOffset)')
  - [IsBetweenDates()](#M-AndcultureCode-CSharp-Extensions-DateExtensions-IsBetweenDates-System-DateTimeOffset,System-DateTimeOffset,System-DateTimeOffset,System-Boolean- 'AndcultureCode.CSharp.Extensions.DateExtensions.IsBetweenDates(System.DateTimeOffset,System.DateTimeOffset,System.DateTimeOffset,System.Boolean)')
  - [SetTime(date,hour,minute,second)](#M-AndcultureCode-CSharp-Extensions-DateExtensions-SetTime-System-DateTimeOffset,System-Int32,System-Int32,System-Int32- 'AndcultureCode.CSharp.Extensions.DateExtensions.SetTime(System.DateTimeOffset,System.Int32,System.Int32,System.Int32)')
  - [SubtractWeekdays()](#M-AndcultureCode-CSharp-Extensions-DateExtensions-SubtractWeekdays-System-DateTime,System-Int32- 'AndcultureCode.CSharp.Extensions.DateExtensions.SubtractWeekdays(System.DateTime,System.Int32)')
  - [SubtractWeekdays()](#M-AndcultureCode-CSharp-Extensions-DateExtensions-SubtractWeekdays-System-DateTimeOffset,System-Int32- 'AndcultureCode.CSharp.Extensions.DateExtensions.SubtractWeekdays(System.DateTimeOffset,System.Int32)')
- [DictionaryExtensions](#T-AndcultureCode-CSharp-Extensions-DictionaryExtensions 'AndcultureCode.CSharp.Extensions.DictionaryExtensions')
  - [Merge\`\`2(left,right,takeLastKey)](#M-AndcultureCode-CSharp-Extensions-DictionaryExtensions-Merge``2-System-Collections-Generic-Dictionary{``0,``1},System-Collections-Generic-Dictionary{``0,``1},System-Boolean- 'AndcultureCode.CSharp.Extensions.DictionaryExtensions.Merge``2(System.Collections.Generic.Dictionary{``0,``1},System.Collections.Generic.Dictionary{``0,``1},System.Boolean)')
- [ExpressionExtensions](#T-AndcultureCode-CSharp-Extensions-ExpressionExtensions 'AndcultureCode.CSharp.Extensions.ExpressionExtensions')
  - [AndAlso\`\`1(expr1,expr2)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-AndAlso``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.AndAlso``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [AndAlso\`\`2(expr1,expr2,navigationProperty)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-AndAlso``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.AndAlso``2(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,``1}})')
  - [OrElse\`\`1(expr1,expr2)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-OrElse``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.OrElse``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [OrElse\`\`2(expr1,expr2,navigationProperty)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-OrElse``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.OrElse``2(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,``1}})')
  - [Or\`\`1(expr1,expr2)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-Or``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.Or``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [Or\`\`2(expr1,expr2,navigationProperty)](#M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-Or``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}- 'AndcultureCode.CSharp.Extensions.ExpressionExtensions.Or``2(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}},System.Linq.Expressions.Expression{System.Func{``0,``1}})')
- [HttpRequestExtensions](#T-AndcultureCode-CSharp-Extensions-HttpRequestExtensions 'AndcultureCode.CSharp.Extensions.HttpRequestExtensions')
  - [X_FORWARDED_FOR](#F-AndcultureCode-CSharp-Extensions-HttpRequestExtensions-X_FORWARDED_FOR 'AndcultureCode.CSharp.Extensions.HttpRequestExtensions.X_FORWARDED_FOR')
  - [GetForwardedIpAddress(httpRequest)](#M-AndcultureCode-CSharp-Extensions-HttpRequestExtensions-GetForwardedIpAddress-Microsoft-AspNetCore-Http-HttpRequest- 'AndcultureCode.CSharp.Extensions.HttpRequestExtensions.GetForwardedIpAddress(Microsoft.AspNetCore.Http.HttpRequest)')
- [HttpResponseMessageExtensions](#T-AndcultureCode-CSharp-Extensions-HttpResponseMessageExtensions 'AndcultureCode.CSharp.Extensions.HttpResponseMessageExtensions')
  - [FromJson\`\`1(response)](#M-AndcultureCode-CSharp-Extensions-HttpResponseMessageExtensions-FromJson``1-System-Net-Http-HttpResponseMessage- 'AndcultureCode.CSharp.Extensions.HttpResponseMessageExtensions.FromJson``1(System.Net.Http.HttpResponseMessage)')
- [IConfigurationRootExtensions](#T-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions')
  - [CONFIGURATION_VERSION_DEVELOPMENT_VALUE](#F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_DEVELOPMENT_VALUE 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.CONFIGURATION_VERSION_DEVELOPMENT_VALUE')
  - [CONFIGURATION_VERSION_KEY](#F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_KEY 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.CONFIGURATION_VERSION_KEY')
  - [CONFIGURATION_VERSION_TEMPLATE](#F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_TEMPLATE 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.CONFIGURATION_VERSION_TEMPLATE')
  - [DEFAULT_DATABASE_KEY](#F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-DEFAULT_DATABASE_KEY 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.DEFAULT_DATABASE_KEY')
  - [GetDatabaseConnectionString(configuration,databaseKey)](#M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetDatabaseConnectionString-Microsoft-Extensions-Configuration-IConfigurationRoot,System-String- 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.GetDatabaseConnectionString(Microsoft.Extensions.Configuration.IConfigurationRoot,System.String)')
  - [GetDatabaseName(configuration)](#M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetDatabaseName-Microsoft-Extensions-Configuration-IConfigurationRoot- 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.GetDatabaseName(Microsoft.Extensions.Configuration.IConfigurationRoot)')
  - [GetVersion(configuration,isDevelopment)](#M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetVersion-Microsoft-Extensions-Configuration-IConfigurationRoot,System-Boolean- 'AndcultureCode.CSharp.Extensions.IConfigurationRootExtensions.GetVersion(Microsoft.Extensions.Configuration.IConfigurationRoot,System.Boolean)')
- [IEnumerableExtensions](#T-AndcultureCode-CSharp-Extensions-IEnumerableExtensions 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions')
  - [IsEmpty\`\`1(source,predicate)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-IsEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.IsEmpty``1(System.Collections.Generic.IEnumerable{``0})')
  - [IsNullOrEmpty\`\`1(source,predicate)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
  - [Join(list,delimiter)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.Join(System.Collections.Generic.IEnumerable{System.String},System.String)')
  - [Join(list,keyValueDelimiter,delimiter)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-String}},System-String,System-String- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.Join(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}},System.String,System.String)')
  - [Join(list,delimiter)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-List{System-String},System-String- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.Join(System.Collections.Generic.List{System.String},System.String)')
  - [Join(pair,delimiter)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-KeyValuePair{System-String,System-String},System-String- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.Join(System.Collections.Generic.KeyValuePair{System.String,System.String},System.String)')
  - [PickRandom\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-PickRandom``1-System-Collections-Generic-IEnumerable{``0}- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.PickRandom``1(System.Collections.Generic.IEnumerable{``0})')
  - [PickRandom\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-PickRandom``1-System-Collections-Generic-IEnumerable{``0},System-Int32- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.PickRandom``1(System.Collections.Generic.IEnumerable{``0},System.Int32)')
  - [Shuffle\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Shuffle``1-System-Collections-Generic-IEnumerable{``0}- 'AndcultureCode.CSharp.Extensions.IEnumerableExtensions.Shuffle``1(System.Collections.Generic.IEnumerable{``0})')
- [IQueryableExtensions](#T-AndcultureCode-CSharp-Extensions-IQueryableExtensions 'AndcultureCode.CSharp.Extensions.IQueryableExtensions')
  - [IsEmpty\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsEmpty``1-System-Linq-IQueryable{``0}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.IsEmpty``1(System.Linq.IQueryable{``0})')
  - [IsEmpty\`\`1(source,predicate)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsEmpty``1-System-Linq-IQueryable{``0},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.IsEmpty``1(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [IsNullOrEmpty\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsNullOrEmpty``1-System-Linq-IQueryable{``0}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.IsNullOrEmpty``1(System.Linq.IQueryable{``0})')
  - [IsNullOrEmpty\`\`1(source,predicate)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsNullOrEmpty``1-System-Linq-IQueryable{``0},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.IsNullOrEmpty``1(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [PickRandom\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-PickRandom``1-System-Linq-IQueryable{``0}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.PickRandom``1(System.Linq.IQueryable{``0})')
  - [PickRandom\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-PickRandom``1-System-Linq-IQueryable{``0},System-Int32- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.PickRandom``1(System.Linq.IQueryable{``0},System.Int32)')
  - [Shuffle\`\`1(source)](#M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-Shuffle``1-System-Linq-IQueryable{``0}- 'AndcultureCode.CSharp.Extensions.IQueryableExtensions.Shuffle``1(System.Linq.IQueryable{``0})')
- [StringExtensions](#T-AndcultureCode-CSharp-Extensions-StringExtensions 'AndcultureCode.CSharp.Extensions.StringExtensions')
  - [AsIndentedJson(str)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-AsIndentedJson-System-String- 'AndcultureCode.CSharp.Extensions.StringExtensions.AsIndentedJson(System.String)')
  - [IsInvalidHttpUrl(source)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-IsInvalidHttpUrl-System-String- 'AndcultureCode.CSharp.Extensions.StringExtensions.IsInvalidHttpUrl(System.String)')
  - [IsValidEmail(email)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-IsValidEmail-System-String- 'AndcultureCode.CSharp.Extensions.StringExtensions.IsValidEmail(System.String)')
  - [IsValidHttpUrl(source)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-IsValidHttpUrl-System-String- 'AndcultureCode.CSharp.Extensions.StringExtensions.IsValidHttpUrl(System.String)')
  - [ToBoolean()](#M-AndcultureCode-CSharp-Extensions-StringExtensions-ToBoolean-System-String- 'AndcultureCode.CSharp.Extensions.StringExtensions.ToBoolean(System.String)')
  - [ToEnumerable\`\`1(input,separator)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-ToEnumerable``1-System-String,System-Char- 'AndcultureCode.CSharp.Extensions.StringExtensions.ToEnumerable``1(System.String,System.Char)')
  - [ToInt(number,defaultValue)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-ToInt-System-String,System-Int32- 'AndcultureCode.CSharp.Extensions.StringExtensions.ToInt(System.String,System.Int32)')
  - [TryChangeType(value,conversionType)](#M-AndcultureCode-CSharp-Extensions-StringExtensions-TryChangeType-System-Object,System-Type- 'AndcultureCode.CSharp.Extensions.StringExtensions.TryChangeType(System.Object,System.Type)')
- [TypeExtensions](#T-AndcultureCode-CSharp-Extensions-TypeExtensions 'AndcultureCode.CSharp.Extensions.TypeExtensions')
  - [GetPublicConstantValues\`\`1()](#M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetPublicConstantValues``1-System-Type- 'AndcultureCode.CSharp.Extensions.TypeExtensions.GetPublicConstantValues``1(System.Type)')
  - [GetTypeName(obj)](#M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetTypeName-System-Object- 'AndcultureCode.CSharp.Extensions.TypeExtensions.GetTypeName(System.Object)')
  - [GetTypeName(type)](#M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetTypeName-System-Type- 'AndcultureCode.CSharp.Extensions.TypeExtensions.GetTypeName(System.Type)')
  - [WhereWithAttribute\`\`1()](#M-AndcultureCode-CSharp-Extensions-TypeExtensions-WhereWithAttribute``1-System-Collections-Generic-IEnumerable{System-Type}- 'AndcultureCode.CSharp.Extensions.TypeExtensions.WhereWithAttribute``1(System.Collections.Generic.IEnumerable{System.Type})')
  - [WhereWithoutAttribute\`\`1()](#M-AndcultureCode-CSharp-Extensions-TypeExtensions-WhereWithoutAttribute``1-System-Collections-Generic-IEnumerable{System-Type}- 'AndcultureCode.CSharp.Extensions.TypeExtensions.WhereWithoutAttribute``1(System.Collections.Generic.IEnumerable{System.Type})')

<a name='T-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes'></a>
## ApiClaimTypes `type`

##### Namespace

AndcultureCode.CSharp.Core.Constants

##### Summary

Commonly used Claim types for APIs

 TODO: Migrate to AndcultureCode.CSharp.Core

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-IS_SUPER_ADMIN'></a>
### IS_SUPER_ADMIN `constants`

##### Summary

Is the current user elevated to super admin

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_ID'></a>
### ROLE_ID `constants`

##### Summary

Active Role Id

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_IDS'></a>
### ROLE_IDS `constants`

##### Summary

Available Role Ids

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-ROLE_TYPE'></a>
### ROLE_TYPE `constants`

##### Summary

Active Role Type

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-USER_ID'></a>
### USER_ID `constants`

##### Summary

Current User Id

<a name='F-AndcultureCode-CSharp-Core-Constants-ApiClaimTypes-USER_LOGIN_ID'></a>
### USER_LOGIN_ID `constants`

##### Summary

Current User Login Id

<a name='T-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions'></a>
## ClaimsPrincipalExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

##### Summary

Extension methods for ClaimsPrincipal

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsAuthenticated-System-Security-Claims-ClaimsPrincipal-'></a>
### IsAuthenticated(principal) `method`

##### Summary

Whether the current user is authenticated

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsSuperAdmin-System-Security-Claims-ClaimsPrincipal-'></a>
### IsSuperAdmin(principal) `method`

##### Summary

Retrieves whether the user is a super admin by way of their identity claims

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-IsUnauthenticated-System-Security-Claims-ClaimsPrincipal-'></a>
### IsUnauthenticated(principal) `method`

##### Summary

Whether the current user is unauthenticated

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-RoleId-System-Security-Claims-ClaimsPrincipal-'></a>
### RoleId(principal) `method`

##### Summary

Retrieves user's current role id by way of their identity claims

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-RoleIds-System-Security-Claims-ClaimsPrincipal-'></a>
### RoleIds(principal) `method`

##### Summary

Retrieves user's role ids by way of their identity claims

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-UserId-System-Security-Claims-ClaimsPrincipal-'></a>
### UserId(principal) `method`

##### Summary

Retrieves user's id by way of identity claims

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='M-AndcultureCode-CSharp-Extensions-ClaimsPrincipalExtensions-UserLoginId-System-Security-Claims-ClaimsPrincipal-'></a>
### UserLoginId(principal) `method`

##### Summary

Retrieves user's UserLoginId from identity claims.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| principal | [System.Security.Claims.ClaimsPrincipal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Claims.ClaimsPrincipal 'System.Security.Claims.ClaimsPrincipal') |  |

<a name='T-AndcultureCode-CSharp-Extensions-DateExtensions'></a>
## DateExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-AtEndOfDay-System-DateTimeOffset-'></a>
### AtEndOfDay(date) `method`

##### Summary

Sets and returns the time to 11:59:59 on the given DateTimeOffset.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-AtMidnight-System-DateTimeOffset-'></a>
### AtMidnight(date) `method`

##### Summary

Useful when you only care about the date, but do not want to lose the offset.
Returns the midnight representation of the given DateTimeOffset.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-CalculateAge-System-DateTime-'></a>
### CalculateAge() `method`

##### Summary

Convenience method to calculate an age from a birthdate

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-IsBetweenDates-System-DateTimeOffset,System-DateTimeOffset,System-DateTimeOffset-'></a>
### IsBetweenDates() `method`

##### Summary

Convenience method to default the inclusive parameter
LINQ doesn't like optional parameters on methods used in expressions

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-IsBetweenDates-System-DateTimeOffset,System-DateTimeOffset,System-DateTimeOffset,System-Boolean-'></a>
### IsBetweenDates() `method`

##### Summary

Provides filtering method for date ranges (excluding time portions)

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-SetTime-System-DateTimeOffset,System-Int32,System-Int32,System-Int32-'></a>
### SetTime(date,hour,minute,second) `method`

##### Summary

Sets the hour, minute, and second on the given DateTimeOffset with the supplied values.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| date | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |  |
| hour | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| minute | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| second | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-SubtractWeekdays-System-DateTime,System-Int32-'></a>
### SubtractWeekdays() `method`

##### Summary

Convenience method to subtract weekdays

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-DateExtensions-SubtractWeekdays-System-DateTimeOffset,System-Int32-'></a>
### SubtractWeekdays() `method`

##### Summary

Convenience method to subtract weekdays

##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Extensions-DictionaryExtensions'></a>
## DictionaryExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-DictionaryExtensions-Merge``2-System-Collections-Generic-Dictionary{``0,``1},System-Collections-Generic-Dictionary{``0,``1},System-Boolean-'></a>
### Merge\`\`2(left,right,takeLastKey) `method`

##### Summary

'Merges' two dictionaries into one. If duplicate keys are encountered, either the first
or last occurrence will be used. See 'takeLastKey'

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [System.Collections.Generic.Dictionary{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{``0,``1}') | Dictionary to be merged into. |
| right | [System.Collections.Generic.Dictionary{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{``0,``1}') | Dictionary to be merged into the left dictionary. |
| takeLastKey | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Determines whether the value of the last occurrence of a key is used as the final value
when duplicates are encountered. If false, uses the value of the first occurrence. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |
| TValue |  |

<a name='T-AndcultureCode-CSharp-Extensions-ExpressionExtensions'></a>
## ExpressionExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-AndAlso``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### AndAlso\`\`1(expr1,expr2) `method`

##### Summary

Adds another expression filter to original expression using AndAlso operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Additional filter expression on the same type of object as the main expression |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-AndAlso``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}-'></a>
### AndAlso\`\`2(expr1,expr2,navigationProperty) `method`

##### Summary

Adds another expression filter to original expression using AndAlso operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`1,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}}') | Filter expression that filters on the navigated property |
| navigationProperty | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1}}') | Expression to the navigation property (eg e => e.PropA.PropB) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |
| TNav | Type of the navigation property (can be deeply nested) |

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-OrElse``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### OrElse\`\`1(expr1,expr2) `method`

##### Summary

Adds another expression filter to original expression using OrElse operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Additional filter expression on the same type of object as the main expression |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-OrElse``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}-'></a>
### OrElse\`\`2(expr1,expr2,navigationProperty) `method`

##### Summary

Adds another expression filter to original expression using OrElse operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`1,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}}') | Filter expression that filters on the navigated property |
| navigationProperty | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1}}') | Expression to the navigation property (eg e => e.PropA.PropB) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |
| TNav | Type of the navigation property (can be deeply nested) |

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-Or``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### Or\`\`1(expr1,expr2) `method`

##### Summary

Adds another expression filter to original expression using Or operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Additional filter expression on the same type of object as the main expression |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |

<a name='M-AndcultureCode-CSharp-Extensions-ExpressionExtensions-Or``2-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``1,System-Boolean}},System-Linq-Expressions-Expression{System-Func{``0,``1}}-'></a>
### Or\`\`2(expr1,expr2,navigationProperty) `method`

##### Summary

Adds another expression filter to original expression using Or operator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr1 | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Main filter expression |
| expr2 | [System.Linq.Expressions.Expression{System.Func{\`\`1,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``1,System.Boolean}}') | Filter expression that filters on the navigated property |
| navigationProperty | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1}}') | Expression to the navigation property (eg e => e.PropA.PropB) |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type of object in the main filter |
| TNav | Type of the navigation property (can be deeply nested) |

<a name='T-AndcultureCode-CSharp-Extensions-HttpRequestExtensions'></a>
## HttpRequestExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

##### Summary

Extension methods for HttpRequest

<a name='F-AndcultureCode-CSharp-Extensions-HttpRequestExtensions-X_FORWARDED_FOR'></a>
### X_FORWARDED_FOR `constants`

##### Summary

Standard X-Header for forwarding IP addresses in varying infrastructures

<a name='M-AndcultureCode-CSharp-Extensions-HttpRequestExtensions-GetForwardedIpAddress-Microsoft-AspNetCore-Http-HttpRequest-'></a>
### GetForwardedIpAddress(httpRequest) `method`

##### Summary

Retrieves the client's forwarded IP address, if present. Returns null otherwise.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| httpRequest | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |

<a name='T-AndcultureCode-CSharp-Extensions-HttpResponseMessageExtensions'></a>
## HttpResponseMessageExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-HttpResponseMessageExtensions-FromJson``1-System-Net-Http-HttpResponseMessage-'></a>
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

<a name='T-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions'></a>
## IConfigurationRootExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

##### Summary

Extension methods for IConfigurationRoot

<a name='F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_DEVELOPMENT_VALUE'></a>
### CONFIGURATION_VERSION_DEVELOPMENT_VALUE `constants`

##### Summary

Version value when application is run in development environment

<a name='F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_KEY'></a>
### CONFIGURATION_VERSION_KEY `constants`

##### Summary

Key value for build version number

<a name='F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-CONFIGURATION_VERSION_TEMPLATE'></a>
### CONFIGURATION_VERSION_TEMPLATE `constants`

##### Summary

Template string replaced with current version number

<a name='F-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-DEFAULT_DATABASE_KEY'></a>
### DEFAULT_DATABASE_KEY `constants`

##### Summary

Default connection string database key

<a name='M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetDatabaseConnectionString-Microsoft-Extensions-Configuration-IConfigurationRoot,System-String-'></a>
### GetDatabaseConnectionString(configuration,databaseKey) `method`

##### Summary

Retrieves web application's primary database connection string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [Microsoft.Extensions.Configuration.IConfigurationRoot](#T-Microsoft-Extensions-Configuration-IConfigurationRoot 'Microsoft.Extensions.Configuration.IConfigurationRoot') |  |
| databaseKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetDatabaseName-Microsoft-Extensions-Configuration-IConfigurationRoot-'></a>
### GetDatabaseName(configuration) `method`

##### Summary

Retrieves the database name of the primary database connection string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [Microsoft.Extensions.Configuration.IConfigurationRoot](#T-Microsoft-Extensions-Configuration-IConfigurationRoot 'Microsoft.Extensions.Configuration.IConfigurationRoot') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IConfigurationRootExtensions-GetVersion-Microsoft-Extensions-Configuration-IConfigurationRoot,System-Boolean-'></a>
### GetVersion(configuration,isDevelopment) `method`

##### Summary

Loads and conditionally updates the Version number based upon environment

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configuration | [Microsoft.Extensions.Configuration.IConfigurationRoot](#T-Microsoft-Extensions-Configuration-IConfigurationRoot 'Microsoft.Extensions.Configuration.IConfigurationRoot') |  |
| isDevelopment | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='T-AndcultureCode-CSharp-Extensions-IEnumerableExtensions'></a>
## IEnumerableExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-IsEmpty``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### IsEmpty\`\`1(source,predicate) `method`

##### Summary

Determines if the source list is empty

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### IsNullOrEmpty\`\`1(source,predicate) `method`

##### Summary

Determines if the source list is null or empty

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-'></a>
### Join(list,delimiter) `method`

##### Summary

Convenience method so joining strings reads better :)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-String}},System-String,System-String-'></a>
### Join(list,keyValueDelimiter,delimiter) `method`

##### Summary

Convenience method for joining dictionary key values into a string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}') |  |
| keyValueDelimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-List{System-String},System-String-'></a>
### Join(list,delimiter) `method`

##### Summary

Convenience method so joining a list of strings

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.List{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Join-System-Collections-Generic-KeyValuePair{System-String,System-String},System-String-'></a>
### Join(pair,delimiter) `method`

##### Summary

Convenience method for joining key value pairs

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pair | [System.Collections.Generic.KeyValuePair{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyValuePair 'System.Collections.Generic.KeyValuePair{System.String,System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-PickRandom``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### PickRandom\`\`1(source) `method`

##### Summary

Returns a random value in the related IEnumerable list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-PickRandom``1-System-Collections-Generic-IEnumerable{``0},System-Int32-'></a>
### PickRandom\`\`1(source) `method`

##### Summary

Returns X number of random values in the related IEnumerable list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IEnumerableExtensions-Shuffle``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### Shuffle\`\`1(source) `method`

##### Summary

Returns source enumerable in randomized order

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Extensions-IQueryableExtensions'></a>
## IQueryableExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsEmpty``1-System-Linq-IQueryable{``0}-'></a>
### IsEmpty\`\`1(source) `method`

##### Summary

Determines if the source list is empty

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsEmpty``1-System-Linq-IQueryable{``0},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### IsEmpty\`\`1(source,predicate) `method`

##### Summary

Determines if the source list is empty (based on the given predicate)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |
| predicate | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsNullOrEmpty``1-System-Linq-IQueryable{``0}-'></a>
### IsNullOrEmpty\`\`1(source) `method`

##### Summary

Determines if the source list is null or empty

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-IsNullOrEmpty``1-System-Linq-IQueryable{``0},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### IsNullOrEmpty\`\`1(source,predicate) `method`

##### Summary

Determines if the source list is null or empty (based on the given predicate)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |
| predicate | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-PickRandom``1-System-Linq-IQueryable{``0}-'></a>
### PickRandom\`\`1(source) `method`

##### Summary

Returns a random value in the related IQueryable list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-PickRandom``1-System-Linq-IQueryable{``0},System-Int32-'></a>
### PickRandom\`\`1(source) `method`

##### Summary

Returns X number of random values in the related IQueryable list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Extensions-IQueryableExtensions-Shuffle``1-System-Linq-IQueryable{``0}-'></a>
### Shuffle\`\`1(source) `method`

##### Summary

Returns source enumerable in randomized order

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-AndcultureCode-CSharp-Extensions-StringExtensions'></a>
## StringExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-AsIndentedJson-System-String-'></a>
### AsIndentedJson(str) `method`

##### Summary

Formats string for pretty printing of a JSON string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-IsInvalidHttpUrl-System-String-'></a>
### IsInvalidHttpUrl(source) `method`

##### Summary

Determines if the supplied string is not a valid HTTP or HTTPS Url

 Uses the native Uri class

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-IsValidEmail-System-String-'></a>
### IsValidEmail(email) `method`

##### Summary

Determines if the supplied string is an email address

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-IsValidHttpUrl-System-String-'></a>
### IsValidHttpUrl(source) `method`

##### Summary

Determines if the supplied string is a valid HTTP or HTTPS url

 Uses the native Uri class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-ToBoolean-System-String-'></a>
### ToBoolean() `method`

##### Summary

Converts a string representation of a boolean into an actual boolean

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-ToEnumerable``1-System-String,System-Char-'></a>
### ToEnumerable\`\`1(input,separator) `method`

##### Summary

Converts a string of ints into an enumerable

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| separator | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-ToInt-System-String,System-Int32-'></a>
### ToInt(number,defaultValue) `method`

##### Summary

Convert a string to integer, otherwise default the value

##### Returns

Converted string as an integer value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| number | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String that should be a number |
| defaultValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Default value used if the number cannot be parse (0 is default) |

<a name='M-AndcultureCode-CSharp-Extensions-StringExtensions-TryChangeType-System-Object,System-Type-'></a>
### TryChangeType(value,conversionType) `method`

##### Summary

Returns true or false if the value can be converted

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| conversionType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='T-AndcultureCode-CSharp-Extensions-TypeExtensions'></a>
## TypeExtensions `type`

##### Namespace

AndcultureCode.CSharp.Extensions

##### Summary

Extensions for Type

<a name='M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetPublicConstantValues``1-System-Type-'></a>
### GetPublicConstantValues\`\`1() `method`

##### Summary

Retrieve all constant values for given type whose value matches type T

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetTypeName-System-Object-'></a>
### GetTypeName(obj) `method`

##### Summary

Returns the name the underlying type of any object

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-AndcultureCode-CSharp-Extensions-TypeExtensions-GetTypeName-System-Type-'></a>
### GetTypeName(type) `method`

##### Summary

Returns the full name of the type as well as the assembly qualified name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='M-AndcultureCode-CSharp-Extensions-TypeExtensions-WhereWithAttribute``1-System-Collections-Generic-IEnumerable{System-Type}-'></a>
### WhereWithAttribute\`\`1() `method`

##### Summary

Filters the provided list of types to only those that are
decorated with the TAttribute attribute at the class level.

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Extensions-TypeExtensions-WhereWithoutAttribute``1-System-Collections-Generic-IEnumerable{System-Type}-'></a>
### WhereWithoutAttribute\`\`1() `method`

##### Summary

Filters the provided list of types to only those that aren't
decorated with the TAttribute attribute at the class level.

##### Parameters

This method has no parameters.
