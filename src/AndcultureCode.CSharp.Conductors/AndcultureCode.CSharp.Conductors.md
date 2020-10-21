<a name='assembly'></a>
# AndcultureCode.CSharp.Conductors

## Contents

- [Conductor](#T-AndcultureCode-CSharp-Conductors-Conductor 'AndcultureCode.CSharp.Conductors.Conductor')
- [RepositoryConductor\`1](#T-AndcultureCode-CSharp-Conductors-RepositoryConductor`1 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1')
  - [#ctor(createConductor,readConductor,updateConductor,deleteConductor)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor{`0}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor{`0},AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{`0},AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor{`0},AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryDeleteConductor{`0})')
  - [_createConductor](#F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_createConductor 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1._createConductor')
  - [_deleteConductor](#F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_deleteConductor 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1._deleteConductor')
  - [_readConductor](#F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_readConductor 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1._readConductor')
  - [_updateConductor](#F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_updateConductor 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1._updateConductor')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CommandTimeout 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.CommandTimeout')
  - [BulkCreate(items,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.BulkCreate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [BulkCreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.BulkCreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [BulkCreateOrUpdate(items,createdOrUpdatedById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.BulkCreateOrUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [BulkDelete(items,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.BulkDelete(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64},System.Boolean)')
  - [BulkUpdate(items,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.BulkUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [Create(item,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Create-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Create(`0,System.Nullable{System.Int64})')
  - [Create(items,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Create-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Create(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [CreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.CreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [CreateOrUpdate(item,createdOrUpdatedById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateOrUpdate-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.CreateOrUpdate(`0,System.Nullable{System.Int64})')
  - [CreateOrUpdate(items,createdOrUpdatedById)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.CreateOrUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [Delete(id,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-System-Int64,System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Delete(System.Int64,System.Nullable{System.Int64},System.Boolean)')
  - [Delete(o,deletedById,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-`0,System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Delete(`0,System.Nullable{System.Int64},System.Boolean)')
  - [Delete(items,deletedById,batchSize,soft)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Int64,System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Delete(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64},System.Int64,System.Boolean)')
  - [FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindAll(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Boolean)')
  - [FindAll(nextLinkParams,filter,orderBy,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindAll(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean},System.Boolean)')
  - [FindAllCommitted(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAllCommitted-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindAllCommitted(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean})')
  - [FindAllCommitted(nextLinkParams,filter,orderBy,ignoreQueryFilters)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindAllCommitted(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean})')
  - [FindById(id)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindById(System.Int64)')
  - [FindById(id,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindById(System.Int64,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[])')
  - [FindById(id,ignoreQueryFilters,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-Boolean,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindById(System.Int64,System.Boolean,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[])')
  - [FindById(id,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-String[]- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindById(System.Int64,System.String[])')
  - [FindById(id,includeProperties)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-String- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.FindById(System.Int64,System.String)')
  - [Restore(o)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Restore-`0- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Restore(`0)')
  - [Restore(id)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Restore-System-Int64- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Restore(System.Int64)')
  - [Update(item,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Update-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Update(`0,System.Nullable{System.Int64})')
  - [Update(items,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryConductor`1.Update(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
- [RepositoryCreateConductor\`1](#T-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1')
  - [#ctor(repository)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0})')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-CommandTimeout 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.CommandTimeout')
  - [BulkCreate(items,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.BulkCreate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [BulkCreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.BulkCreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [Create(item,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-Create-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.Create(`0,System.Nullable{System.Int64})')
  - [Create(items,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-Create-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.Create(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [CreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryCreateConductor`1.CreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
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
- [RepositoryUpdateConductor\`1](#T-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1')
  - [#ctor(repository)](#M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}- 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0})')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-CommandTimeout 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1.CommandTimeout')
  - [BulkUpdate(items,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-BulkUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1.BulkUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [Update(item,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-Update-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1.Update(`0,System.Nullable{System.Int64})')
  - [Update(items,updatedBy)](#M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Conductors.RepositoryUpdateConductor`1.Update(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')

<a name='T-AndcultureCode-CSharp-Conductors-Conductor'></a>
## Conductor `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Conductor class

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryConductor`1'></a>
## RepositoryConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Provides CRUD operations on a given repository

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor{`0},AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor{`0}-'></a>
### #ctor(createConductor,readConductor,updateConductor,deleteConductor) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| createConductor | [AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor{`0} 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor{`0}') | The conductor instance that should be used to perform create operations |
| readConductor | [AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor{`0} 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor{`0}') | The conductor instance that should be used to perform read operations |
| updateConductor | [AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor{`0} 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor{`0}') | The conductor instance that should be used to perform update operations |
| deleteConductor | [AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryDeleteConductor{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor{`0} 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryDeleteConductor{`0}') | The conductor instance that should be used to perform delete operations |

<a name='F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_createConductor'></a>
### _createConductor `constants`

##### Summary

Conductor property to create an entity or entities

<a name='F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_deleteConductor'></a>
### _deleteConductor `constants`

##### Summary

Conductor property to delete an entity or entities

<a name='F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_readConductor'></a>
### _readConductor `constants`

##### Summary

Conductor property to get an entity or entities

<a name='F-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-_updateConductor'></a>
### _updateConductor `constants`

##### Summary

Conductor property to update an entity or entities

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying repository's command timeout

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkCreate(items,createdById) `method`

##### Summary

Ability to create entities using a list in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### BulkCreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Ability to create entities using a list in a single bulk operation without duplicates.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property used to remove duplicates |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkCreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkCreateOrUpdate(items,createdOrUpdatedById) `method`

##### Summary

Ability to create or update a list of entities in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create or update |
| createdOrUpdatedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating or updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-BulkUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkUpdate(items,updatedBy) `method`

##### Summary

Ability to update a list of entities in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Create-`0,System-Nullable{System-Int64}-'></a>
### Create(item,createdById) `method`

##### Summary

Ability to create an entity

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | Item to be created |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the item |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Create-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### Create(items,createdById) `method`

##### Summary

Ability to create entities individually using a list

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to be created |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### CreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Ability to create entities individually without duplicates

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property used to remove duplicates |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateOrUpdate-`0,System-Nullable{System-Int64}-'></a>
### CreateOrUpdate(item,createdOrUpdatedById) `method`

##### Summary

Ability to create or update an entity

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | Item to create or update |
| createdOrUpdatedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating or updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-CreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### CreateOrUpdate(items,createdOrUpdatedById) `method`

##### Summary

Ability to create or update a list of items but each item is created or updated individually.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create or update |
| createdOrUpdatedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating or updating the entities |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-System-Int64,System-Nullable{System-Int64},System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-`0,System-Nullable{System-Int64},System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Delete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Int64,System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAllCommitted-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean}-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}-'></a>
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

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64-'></a>
### FindById(id) `method`

##### Summary

Finds an entity by its Id.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]-'></a>
### FindById(id,includeProperties) `method`

##### Summary

Finds an entity by its Id.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| includeProperties | [System.Linq.Expressions.Expression{System.Func{\`0,System.Object}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[]') | Navigation properties that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-Boolean,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}[]-'></a>
### FindById(id,ignoreQueryFilters,includeProperties) `method`

##### Summary

Finds an entity by its Id.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| ignoreQueryFilters | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, global query filters will be ignored for this query. |
| includeProperties | [System.Linq.Expressions.Expression{System.Func{\`0,System.Object}}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[]') | Navigation properties that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-String[]-'></a>
### FindById(id,includeProperties) `method`

##### Summary

Finds an entity by its Id.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| includeProperties | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Navigation properties that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-FindById-System-Int64,System-String-'></a>
### FindById(id,includeProperties) `method`

##### Summary

Finds an entity by its Id.

##### Returns

The entity with the provided identity value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The entity identity value. |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Navigation property that should be included. |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Restore-`0-'></a>
### Restore(o) `method`

##### Summary

Ability to restore a soft-deleted entity using the entity itself.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [\`0](#T-`0 '`0') | Entity to be restored |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Restore-System-Int64-'></a>
### Restore(id) `method`

##### Summary

Ability to restore a soft-deleted entity using the entity id.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Id of entity to be restored |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Update-`0,System-Nullable{System-Int64}-'></a>
### Update(item,updatedBy) `method`

##### Summary

Ability to update an entity

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | Item to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryConductor`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### Update(items,updatedBy) `method`

##### Summary

Ability to update a list of items but each item is updated individually.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1'></a>
## RepositoryCreateConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Ability to create an entity or multiple entities

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0}') |  |

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkCreate(items,createdById) `method`

##### Summary

Ability to create entities using a list in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### BulkCreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Ability to create entities using a list in a single bulk operation without duplicates.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property used to remove duplicates |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-Create-`0,System-Nullable{System-Int64}-'></a>
### Create(item,createdById) `method`

##### Summary

Ability to create an entity

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | Item to be created |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the item |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-Create-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### Create(items,createdById) `method`

##### Summary

Ability to create entities individually using a list

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to be created |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryCreateConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### CreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Ability to create entities individually without duplicates

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property used to remove duplicates |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user creating the items |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |

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

<a name='T-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1'></a>
## RepositoryUpdateConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Conductors

##### Summary

Ability to update an entity or a list of entities

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository{`0} 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository{`0}') |  |

<a name='P-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-BulkUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkUpdate(items,updatedBy) `method`

##### Summary

Ability to update a list of entities in a single bulk operation.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-Update-`0,System-Nullable{System-Int64}-'></a>
### Update(item,updatedBy) `method`

##### Summary

Ability to update an entity

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | Item to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |

<a name='M-AndcultureCode-CSharp-Conductors-RepositoryUpdateConductor`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### Update(items,updatedBy) `method`

##### Summary

Ability to update a list of items but each item is updated individually.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to update |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of user updating the entity |
