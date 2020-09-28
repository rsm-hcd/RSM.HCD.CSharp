<a name='assembly'></a>
# AndcultureCode.CSharp.Conductors

## Contents

- [RepositoryDeleteConductor\`1](#T-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1')
  - [#ctor(repository)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0})')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-CommandTimeout 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.CommandTimeout')
  - [BulkDelete(items,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.BulkDelete(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64},System.Boolean)')
  - [Delete(id,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-System-Int64,System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.Delete(System.Int64,System.Nullable{System.Int64},System.Boolean)')
  - [Delete(o,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-`0,System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.Delete(`0,System.Nullable{System.Int64},System.Boolean)')
  - [Delete(items,deletedById,batchSize,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Int64,System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.Delete(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64},System.Int64,System.Boolean)')
  - [Restore(o)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Restore-`0- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.Restore(`0)')
  - [Restore(id)](#M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Restore-System-Int64- 'AndcultureCode.CSharp.Conductors.RepositoryDeleteConductor`1.Restore(System.Int64)')
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

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1'></a>
## RepositoryDeleteConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Ability to delete an entity or list of entities

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0}') |  |

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean-'></a>
### BulkDelete(items,deletedById,soft) `method`

##### Summary

Ability to delete a list of entities in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to delete |
| deletedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user deleting the items |
| soft | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Boolean flag for soft-deleting items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-System-Int64,System-Nullable{System-Int64},System-Boolean-'></a>
### Delete(id,deletedById,soft) `method`

##### Summary

Ability to delete an entity using an Id

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Id of item to be deleted |
| deletedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user deleting the item |
| soft | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Boolean flag for soft-deleting the item |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-`0,System-Nullable{System-Int64},System-Boolean-'></a>
### Delete(o,deletedById,soft) `method`

##### Summary

Ability to delete an entity using the entity itself

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [\`0](#T-`0 '`0') | Item to be deleted |
| deletedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user deleting the item |
| soft | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Boolean flag for soft-deleting the item |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Delete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Int64,System-Boolean-'></a>
### Delete(items,deletedById,batchSize,soft) `method`

##### Summary

Ability to delete a list of entities by batch size.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to delete |
| deletedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user deleting the items |
| batchSize | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Number of items to include in a batch, defaults to 100 |
| soft | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Boolean flag for soft-deleting the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Restore-`0-'></a>
### Restore(o) `method`

##### Summary

Ability to restore a soft-deleted entity using the entity itself.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [\`0](#T-`0 '`0') | Entity to be restored |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryDeleteConductor`1-Restore-System-Int64-'></a>
### Restore(id) `method`

##### Summary

Ability to restore a soft-deleted entity using the entity id.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Id of entity to be restored |

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1'></a>
## RepositoryReadConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Provides read operations on a given repository.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Creates an instance of RepositoryReadConductor for an [IRepository\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1') instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0}') | The Repository instance that should be used to perform read operations. |

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying Repository's command timeout.

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean-'></a>
### FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Find all filtered, sorted and paged.

##### Returns

A queryable collection of entities for the given criteria.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Navigation properties that should be included. |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities that should be skipped. |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities per page. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If true, global query filters will be ignored for this query. |
| asNoTracking | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Ignore change tracking on the result. Set

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

A queryable collection of entities for the given criteria.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nextLinkParams | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') | Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses. |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If true, global query filters will be ignored for this query. |
| asNoTracking | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Ignore change tracking on the result. Set

```
true
```

for read-only operations. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}-'></a>
### FindAllCommitted(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters) `method`

##### Summary

Similar to FindAll but loading the result into memory.

##### Returns

An in-memory collection of entities for the given criteria.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Navigation properties that should be included. |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities that should be skipped. |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | Number of entities per page. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If true, global query filters will be ignored for this query. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryReadConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}-'></a>
### FindAllCommitted(nextLinkParams,filter,orderBy,ignoreQueryFilters) `method`

##### Summary

Similar to FindAll but loading the result into memory.

##### Returns

An in-memory collection of entities for the given criteria.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nextLinkParams | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') | Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses. |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | Filter to be used for querying. |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') | Properties that should be used for sorting. |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') | If true, global query filters will be ignored for this query. |

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
| ignoreQueryFilters | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, global query filters will be ignored for this query. |
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
