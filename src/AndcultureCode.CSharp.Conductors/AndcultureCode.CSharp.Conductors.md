<a name='assembly'></a>
# AndcultureCode.CSharp.Conductors

## Contents

- [LockingConductor\`1](#T-AndcultureCode-CSharp-Conductors-Aspects-LockingConductor`1 'AndcultureCode.CSharp.Conductors.Aspects.LockingConductor`1')
  - [#ctor()](#M-AndcultureCode-CSharp-Conductors-Aspects-LockingConductor`1-#ctor-Microsoft-Extensions-Logging-ILogger{AndcultureCode-CSharp-Conductors-Aspects-LockingConductor{`0}},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor{`0}- 'AndcultureCode.CSharp.Conductors.Aspects.LockingConductor`1.#ctor(Microsoft.Extensions.Logging.ILogger{AndcultureCode.CSharp.Conductors.Aspects.LockingConductor{`0}},AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{`0},AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor{`0})')
- [RepositoryReadConductor\`1](#T-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1')
  - [#ctor(repository)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0})')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-CommandTimeout 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.CommandTimeout')
  - [FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindAll(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Boolean)')
  - [FindAll(nextLinkParams,filter,orderBy,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindAll(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean},System.Boolean)')
  - [FindAllCommitted(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindAllCommitted(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean})')
  - [FindAllCommitted(nextLinkParams,filter,orderBy,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindAllCommitted(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean})')
  - [FindById(id)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindById(System.Int64)')
  - [FindById(id,ignoreQueryFilters,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-Boolean,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindById(System.Int64,System.Boolean,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[])')
  - [FindById(id,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindById(System.Int64,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[])')
  - [FindById(id,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-String[]- 'AndcultureCode.CSharp.Conductors.RepositoryReadConductor`1.FindById(System.Int64,System.String[])')

<a name='T-AndcultureCode-CSharp-Conductors-Aspects-LockingConductor`1'></a>
## LockingConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors.Aspects

##### Summary



##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-Aspects-LockingConductor`1-#ctor-Microsoft-Extensions-Logging-ILogger{AndcultureCode-CSharp-Conductors-Aspects-LockingConductor{`0}},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor{`0}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1'></a>
## RepositoryReadConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary



##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Creates and instance of RepositoryReadConductor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0}') |  |

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying Repository's command timeout

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean-'></a>
### FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Find all filtered, sorted and paged

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Navigation properties that should be included. |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities that should be skipped. |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities per page. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If previous applied filters should be ignore. |
| asNoTracking | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | To ignore tracking for changes on the result. Set

```
true
```

for read-only operations. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean-'></a>
### FindAll(nextLinkParams,filter,orderBy,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Alternative FindAll for retrieving records using NextLinkParams in place of traditional
determinate pagination mechanisms, such as; skip and take.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nextLinkParams | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') | Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses. |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If previous applied filters should be ignore. |
| asNoTracking | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If the context should track changes to the entities. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}-'></a>
### FindAllCommitted(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters) `method`

##### Summary

Similar to FindAll but loading all data into memory.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Navigation properties that should be included. |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities that should be skipped. |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities per page. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If previous applied filters should be ignore. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}-'></a>
### FindAllCommitted(nextLinkParams,filter,orderBy,ignoreQueryFilters) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nextLinkParams | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') | Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses. |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If previous applied filters should be ignore. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64-'></a>
### FindById(id) `method`

##### Summary

Finds an entity by its ID.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-Boolean,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]-'></a>
### FindById(id,ignoreQueryFilters,includeProperties) `method`

##### Summary

Finds an entity by its ID.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| ignoreQueryFilters | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If previous applied filters should be ignore. |
| includeProperties | [System.Linq.Expressions.Expression{System.Func{\`0,System.Object}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[]') | Navigation properties that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]-'></a>
### FindById(id,includeProperties) `method`

##### Summary

Finds an entity by its ID.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| includeProperties | [System.Linq.Expressions.Expression{System.Func{\`0,System.Object}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[]') | Navigation properties that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindById-System-Int64,System-String[]-'></a>
### FindById(id,includeProperties) `method`

##### Summary

Finds an entity by its ID.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| includeProperties | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Navigation properties that should be included. |
