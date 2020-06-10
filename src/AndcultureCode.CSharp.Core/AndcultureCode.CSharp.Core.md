<a name='assembly'></a>
# AndcultureCode.CSharp.Core

## Contents

- [AmazonEBConfigurationProvider](#T-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider 'AndcultureCode.CSharp.Core.Utilities.Configuration.AmazonEBConfigurationProvider')
  - [CONFIGURATION_FILE_PATH](#F-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-CONFIGURATION_FILE_PATH 'AndcultureCode.CSharp.Core.Utilities.Configuration.AmazonEBConfigurationProvider.CONFIGURATION_FILE_PATH')
  - [CachedConfiguration](#P-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-CachedConfiguration 'AndcultureCode.CSharp.Core.Utilities.Configuration.AmazonEBConfigurationProvider.CachedConfiguration')
  - [Load()](#M-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-Load 'AndcultureCode.CSharp.Core.Utilities.Configuration.AmazonEBConfigurationProvider.Load')
- [AndcultureCodeWebHost](#T-AndcultureCode-CSharp-Core-Utilities-Hosting-AndcultureCodeWebHost 'AndcultureCode.CSharp.Core.Utilities.Hosting.AndcultureCodeWebHost')
  - [Preload()](#M-AndcultureCode-CSharp-Core-Utilities-Hosting-AndcultureCodeWebHost-Preload-System-String[]- 'AndcultureCode.CSharp.Core.Utilities.Hosting.AndcultureCodeWebHost.Preload(System.String[])')
- [ApplicationConstants](#T-AndcultureCode-CSharp-Core-Constants-ApplicationConstants 'AndcultureCode.CSharp.Core.Constants.ApplicationConstants')
  - [API_DATABASE_CONFIGURATION_KEY](#F-AndcultureCode-CSharp-Core-Constants-ApplicationConstants-API_DATABASE_CONFIGURATION_KEY 'AndcultureCode.CSharp.Core.Constants.ApplicationConstants.API_DATABASE_CONFIGURATION_KEY')
- [BasicAuthenticationConfiguration](#T-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration 'AndcultureCode.CSharp.Core.Models.Configuration.BasicAuthenticationConfiguration')
  - [IsEnabled](#P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-IsEnabled 'AndcultureCode.CSharp.Core.Models.Configuration.BasicAuthenticationConfiguration.IsEnabled')
  - [Password](#P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-Password 'AndcultureCode.CSharp.Core.Models.Configuration.BasicAuthenticationConfiguration.Password')
  - [UserName](#P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-UserName 'AndcultureCode.CSharp.Core.Models.Configuration.BasicAuthenticationConfiguration.UserName')
- [BitwiseOperator](#T-AndcultureCode-CSharp-Core-Enumerations-BitwiseOperator 'AndcultureCode.CSharp.Core.Enumerations.BitwiseOperator')
- [Connection](#T-AndcultureCode-CSharp-Core-Models-Connection 'AndcultureCode.CSharp.Core.Models.Connection')
  - [AdditionalParameters](#P-AndcultureCode-CSharp-Core-Models-Connection-AdditionalParameters 'AndcultureCode.CSharp.Core.Models.Connection.AdditionalParameters')
  - [Database](#P-AndcultureCode-CSharp-Core-Models-Connection-Database 'AndcultureCode.CSharp.Core.Models.Connection.Database')
  - [Datasource](#P-AndcultureCode-CSharp-Core-Models-Connection-Datasource 'AndcultureCode.CSharp.Core.Models.Connection.Datasource')
  - [Password](#P-AndcultureCode-CSharp-Core-Models-Connection-Password 'AndcultureCode.CSharp.Core.Models.Connection.Password')
  - [UserId](#P-AndcultureCode-CSharp-Core-Models-Connection-UserId 'AndcultureCode.CSharp.Core.Models.Connection.UserId')
  - [ToString(delimiter)](#M-AndcultureCode-CSharp-Core-Models-Connection-ToString-System-String- 'AndcultureCode.CSharp.Core.Models.Connection.ToString(System.String)')
  - [ValidParameter(value)](#M-AndcultureCode-CSharp-Core-Models-Connection-ValidParameter-System-String- 'AndcultureCode.CSharp.Core.Models.Connection.ValidParameter(System.String)')
- [CultureTranslation](#T-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation 'AndcultureCode.CSharp.Core.Models.Localization.CultureTranslation')
  - [FilePath](#P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-FilePath 'AndcultureCode.CSharp.Core.Models.Localization.CultureTranslation.FilePath')
  - [Key](#P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-Key 'AndcultureCode.CSharp.Core.Models.Localization.CultureTranslation.Key')
  - [Value](#P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-Value 'AndcultureCode.CSharp.Core.Models.Localization.CultureTranslation.Value')
- [DataConfiguration](#T-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration 'AndcultureCode.CSharp.Core.Models.Configuration.DataConfiguration')
  - [IP_ADDRESS_LENGTH](#F-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration-IP_ADDRESS_LENGTH 'AndcultureCode.CSharp.Core.Models.Configuration.DataConfiguration.IP_ADDRESS_LENGTH')
  - [URL_LENGTH](#F-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration-URL_LENGTH 'AndcultureCode.CSharp.Core.Models.Configuration.DataConfiguration.URL_LENGTH')
- [Do\`1](#T-AndcultureCode-CSharp-Core-Do`1 'AndcultureCode.CSharp.Core.Do`1')
  - [Finally(logger,workload)](#M-AndcultureCode-CSharp-Core-Do`1-Finally-Microsoft-Extensions-Logging-ILogger,System-Action{AndcultureCode-CSharp-Core-Interfaces-IResult{`0}}- 'AndcultureCode.CSharp.Core.Do`1.Finally(Microsoft.Extensions.Logging.ILogger,System.Action{AndcultureCode.CSharp.Core.Interfaces.IResult{`0}})')
  - [Try(logger,workload)](#M-AndcultureCode-CSharp-Core-Do`1-Try-Microsoft-Extensions-Logging-ILogger,System-Func{AndcultureCode-CSharp-Core-Interfaces-IResult{`0},`0}- 'AndcultureCode.CSharp.Core.Do`1.Try(Microsoft.Extensions.Logging.ILogger,System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{`0},`0})')
  - [Try(logger,workload,retry)](#M-AndcultureCode-CSharp-Core-Do`1-Try-Microsoft-Extensions-Logging-ILogger,System-UInt32,System-Func{AndcultureCode-CSharp-Core-Interfaces-IResult{`0},`0}- 'AndcultureCode.CSharp.Core.Do`1.Try(Microsoft.Extensions.Logging.ILogger,System.UInt32,System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{`0},`0})')
- [EmailProviderBase](#T-AndcultureCode-CSharp-Core-Providers-EmailProviderBase 'AndcultureCode.CSharp.Core.Providers.EmailProviderBase')
  - [Send(message)](#M-AndcultureCode-CSharp-Core-Providers-EmailProviderBase-Send-MimeKit-MimeMessage- 'AndcultureCode.CSharp.Core.Providers.EmailProviderBase.Send(MimeKit.MimeMessage)')
  - [SendLater(message)](#M-AndcultureCode-CSharp-Core-Providers-EmailProviderBase-SendLater-MimeKit-MimeMessage- 'AndcultureCode.CSharp.Core.Providers.EmailProviderBase.SendLater(MimeKit.MimeMessage)')
- [EmailSettings](#T-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings')
  - [ERROR_MISSING_PROPERTY](#F-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-ERROR_MISSING_PROPERTY 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.ERROR_MISSING_PROPERTY')
  - [CustomHeaders](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-CustomHeaders 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.CustomHeaders')
  - [CustomHeadersAsDictionary](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-CustomHeadersAsDictionary 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.CustomHeadersAsDictionary')
  - [DeveloperEmailAddress](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-DeveloperEmailAddress 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.DeveloperEmailAddress')
  - [SendTestEmail](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-SendTestEmail 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.SendTestEmail')
  - [TestEmailAddress](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-TestEmailAddress 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.TestEmailAddress')
  - [TestEmailEnvironmentToken](#P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-TestEmailEnvironmentToken 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.TestEmailEnvironmentToken')
  - [GetDeveloperEmailAddress(environmentName)](#M-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-GetDeveloperEmailAddress-System-String- 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.GetDeveloperEmailAddress(System.String)')
  - [GetRecipientEmailOrTest(email,environmentName,isProduction)](#M-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-GetRecipientEmailOrTest-System-String,System-String,System-Boolean- 'AndcultureCode.CSharp.Core.Models.Mail.EmailSettings.GetRecipientEmailOrTest(System.String,System.String,System.Boolean)')
- [EnumerableExtensions](#T-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions 'AndcultureCode.CSharp.Core.Extensions.EnumerableExtensions')
  - [Join(list,delimiter)](#M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String- 'AndcultureCode.CSharp.Core.Extensions.EnumerableExtensions.Join(System.Collections.Generic.IEnumerable{System.String},System.String)')
  - [Join(list,keyValueDelimiter,delimiter)](#M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-String}},System-String,System-String- 'AndcultureCode.CSharp.Core.Extensions.EnumerableExtensions.Join(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}},System.String,System.String)')
  - [Join(list,delimiter)](#M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-List{System-String},System-String- 'AndcultureCode.CSharp.Core.Extensions.EnumerableExtensions.Join(System.Collections.Generic.List{System.String},System.String)')
  - [Join(pair,delimiter)](#M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-KeyValuePair{System-String,System-String},System-String- 'AndcultureCode.CSharp.Core.Extensions.EnumerableExtensions.Join(System.Collections.Generic.KeyValuePair{System.String,System.String},System.String)')
- [IAndcultureCodeWebHostBuilder](#T-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder 'AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder')
  - [Args](#P-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder-Args 'AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder.Args')
  - [CreateDefaultBuilder()](#M-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder-CreateDefaultBuilder 'AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder.CreateDefaultBuilder')
- [IAndcultureCodeWebHostBuilderExtensions](#T-AndcultureCode-CSharp-Core-Extensions-IAndcultureCodeWebHostBuilderExtensions 'AndcultureCode.CSharp.Core.Extensions.IAndcultureCodeWebHostBuilderExtensions')
  - [PreloadAmazonElasticBeanstalk(builder,stdoutEnabled)](#M-AndcultureCode-CSharp-Core-Extensions-IAndcultureCodeWebHostBuilderExtensions-PreloadAmazonElasticBeanstalk-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder,System-Boolean,AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider- 'AndcultureCode.CSharp.Core.Extensions.IAndcultureCodeWebHostBuilderExtensions.PreloadAmazonElasticBeanstalk(AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder,System.Boolean,AndcultureCode.CSharp.Core.Utilities.Configuration.AmazonEBConfigurationProvider)')
- [IConfigurationBuilderExtensions](#T-AndcultureCode-CSharp-Core-Extensions-IConfigurationBuilderExtensions 'AndcultureCode.CSharp.Core.Extensions.IConfigurationBuilderExtensions')
  - [AddAmazonElasticBeanstalk(configurationBuilder)](#M-AndcultureCode-CSharp-Core-Extensions-IConfigurationBuilderExtensions-AddAmazonElasticBeanstalk-Microsoft-Extensions-Configuration-IConfigurationBuilder- 'AndcultureCode.CSharp.Core.Extensions.IConfigurationBuilderExtensions.AddAmazonElasticBeanstalk(Microsoft.Extensions.Configuration.IConfigurationBuilder)')
- [IConnection](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection')
  - [AdditionalParameters](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-AdditionalParameters 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.AdditionalParameters')
  - [Database](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Database 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.Database')
  - [Datasource](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Datasource 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.Datasource')
  - [Password](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Password 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.Password')
  - [UserId](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-UserId 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.UserId')
  - [ToString()](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-ToString-System-String- 'AndcultureCode.CSharp.Core.Interfaces.Data.IConnection.ToString(System.String)')
- [ICulture](#T-AndcultureCode-CSharp-Core-Interfaces-ICulture 'AndcultureCode.CSharp.Core.Interfaces.ICulture')
  - [Code](#P-AndcultureCode-CSharp-Core-Interfaces-ICulture-Code 'AndcultureCode.CSharp.Core.Interfaces.ICulture.Code')
  - [IsDefault](#P-AndcultureCode-CSharp-Core-Interfaces-ICulture-IsDefault 'AndcultureCode.CSharp.Core.Interfaces.ICulture.IsDefault')
- [IEmailProvider](#T-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider 'AndcultureCode.CSharp.Core.Interfaces.Providers.Mail.IEmailProvider')
  - [Send(message)](#M-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider-Send-MimeKit-MimeMessage- 'AndcultureCode.CSharp.Core.Interfaces.Providers.Mail.IEmailProvider.Send(MimeKit.MimeMessage)')
  - [SendLater(message)](#M-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider-SendLater-MimeKit-MimeMessage- 'AndcultureCode.CSharp.Core.Interfaces.Providers.Mail.IEmailProvider.SendLater(MimeKit.MimeMessage)')
- [ILockingConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.ILockingConductor`1')
  - [ExtendLock(id,lockUntil,updatedById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-ExtendLock-System-Int64,System-DateTimeOffset,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.ILockingConductor`1.ExtendLock(System.Int64,System.DateTimeOffset,System.Nullable{System.Int64})')
  - [Lock(id,lockUntil,lockedById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-Lock-System-Int64,System-DateTimeOffset,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.ILockingConductor`1.Lock(System.Int64,System.DateTimeOffset,System.Nullable{System.Int64})')
  - [Unlock(id,unlockedById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-Unlock-System-Int64,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.ILockingConductor`1.Unlock(System.Int64,System.Nullable{System.Int64})')
  - [ValidateLock(item,currentUserId)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-ValidateLock-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.ILockingConductor`1.ValidateLock(`0,System.Nullable{System.Int64})')
- [IProvider](#T-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider 'AndcultureCode.CSharp.Core.Interfaces.Providers.IProvider')
  - [Implemented](#P-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider-Implemented 'AndcultureCode.CSharp.Core.Interfaces.Providers.IProvider.Implemented')
  - [Name](#P-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider-Name 'AndcultureCode.CSharp.Core.Interfaces.Providers.IProvider.Name')
- [IRepositoryConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor`1.CommandTimeout')
  - [BulkCreateOrUpdate()](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-BulkCreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor`1.BulkCreateOrUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [CreateOrUpdate()](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CreateOrUpdate-`0,System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor`1.CreateOrUpdate(`0,System.Nullable{System.Int64})')
  - [CreateOrUpdate(items,createdOrUpdatedById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryConductor`1.CreateOrUpdate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
- [IRepositoryCreateConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor`1.CommandTimeout')
  - [BulkCreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor`1.BulkCreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [CreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryCreateConductor`1.CreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
- [IRepositoryDeleteConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryDeleteConductor`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryDeleteConductor`1.CommandTimeout')
- [IRepositoryReadConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor`1.CommandTimeout')
  - [FindAll(filter,orderBy,nextLinkParams)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor`1.FindAll(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean},System.Boolean)')
  - [FindAllCommitted(filter,orderBy,nextLinkParams)](#M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}- 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryReadConductor`1.FindAllCommitted(System.Collections.Generic.Dictionary{System.String,System.String},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.Nullable{System.Boolean})')
- [IRepositoryUpdateConductor\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor`1 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Conductors.IRepositoryUpdateConductor`1.CommandTimeout')
- [IRepository\`1](#T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1')
  - [CommandTimeout](#P-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-CommandTimeout 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.CommandTimeout')
  - [BulkCreate(items,createdById)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.BulkCreate(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
  - [BulkCreateDistinct\`\`1(items,property,createdById,items,property,createdById)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.BulkCreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [BulkDelete(items,deletedById,soft)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.BulkDelete(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64},System.Boolean)')
  - [CreateDistinct\`\`1(items,property,createdById)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.CreateDistinct``1(System.Collections.Generic.IEnumerable{`0},System.Func{`0,``0},System.Nullable{System.Int64})')
  - [FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.FindAll(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}},System.String,System.Nullable{System.Int32},System.Nullable{System.Int32},System.Nullable{System.Boolean},System.Boolean)')
  - [Update(entities,updatedBy)](#M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}- 'AndcultureCode.CSharp.Core.Interfaces.Data.IRepository`1.Update(System.Collections.Generic.IEnumerable{`0},System.Nullable{System.Int64})')
- [IResultExtensions](#T-AndcultureCode-CSharp-Core-Extensions-IResultExtensions 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions')
  - [AddErrorAndLog\`\`1(result,logger,localizer,errorKey,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorAndLog``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Object[])')
  - [AddErrorAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Nullable{System-Int64},System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorAndLog``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Nullable{System.Int64},System.Object[])')
  - [AddErrorAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Int64,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorAndLog``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Int64,System.Object[])')
  - [AddError\`\`1(result,localizer,key,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Object[])')
  - [AddError\`\`1(result,localizer,key,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,AndcultureCode-CSharp-Core-Enumerations-ErrorType,System-String,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Localization.IStringLocalizer,AndcultureCode.CSharp.Core.Enumerations.ErrorType,System.String,System.Object[])')
  - [AddError\`\`1(result,message)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String)')
  - [AddErrorsAndLog\`\`1(result,logger,errorKey,errorMessage,logMessage,resourceIdentifier,errors,methodName)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,System-String,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{AndcultureCode-CSharp-Core-Interfaces-IError},System-String- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorsAndLog``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Logging.ILogger,System.String,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError},System.String)')
  - [AddErrorsAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,errors,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Int64,System-Collections-Generic-IEnumerable{AndcultureCode-CSharp-Core-Interfaces-IError},System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorsAndLog``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Int64,System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError},System.Object[])')
  - [AddErrorsAndReturnDefault\`\`2(destination,source)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndReturnDefault``2-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-IResult{``1}- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddErrorsAndReturnDefault``2(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},AndcultureCode.CSharp.Core.Interfaces.IResult{``1})')
  - [AddNextLinkParam\`\`1(result,key,value)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddNextLinkParam``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String,System-String- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddNextLinkParam``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},System.String,System.String)')
  - [AddNextLinkParams\`\`1(destinationResult,sourceResult)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddNextLinkParams``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-IResult{``0}- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddNextLinkParams``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},AndcultureCode.CSharp.Core.Interfaces.IResult{``0})')
  - [AddValidationError\`\`1(result,localizer,key,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddValidationError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IResultExtensions.AddValidationError``1(AndcultureCode.CSharp.Core.Interfaces.IResult{``0},Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Object[])')
- [IResult\`1](#T-AndcultureCode-CSharp-Core-Interfaces-IResult`1 'AndcultureCode.CSharp.Core.Interfaces.IResult`1')
  - [ErrorCount](#P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-ErrorCount 'AndcultureCode.CSharp.Core.Interfaces.IResult`1.ErrorCount')
  - [Errors](#P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-Errors 'AndcultureCode.CSharp.Core.Interfaces.IResult`1.Errors')
  - [HasErrors](#P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-HasErrors 'AndcultureCode.CSharp.Core.Interfaces.IResult`1.HasErrors')
  - [NextLinkParams](#P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-NextLinkParams 'AndcultureCode.CSharp.Core.Interfaces.IResult`1.NextLinkParams')
  - [ResultObject](#P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-ResultObject 'AndcultureCode.CSharp.Core.Interfaces.IResult`1.ResultObject')
- [IStringLocalizerExtensions](#T-AndcultureCode-CSharp-Core-Extensions-IStringLocalizerExtensions 'AndcultureCode.CSharp.Core.Extensions.IStringLocalizerExtensions')
  - [Default(localizer,key,arguments)](#M-AndcultureCode-CSharp-Core-Extensions-IStringLocalizerExtensions-Default-Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]- 'AndcultureCode.CSharp.Core.Extensions.IStringLocalizerExtensions.Default(Microsoft.Extensions.Localization.IStringLocalizer,System.String,System.Object[])')
- [LocalizationUtils](#T-AndcultureCode-CSharp-Core-Utilities-Localization-LocalizationUtils 'AndcultureCode.CSharp.Core.Utilities.Localization.LocalizationUtils')
  - [Cultures](#P-AndcultureCode-CSharp-Core-Utilities-Localization-LocalizationUtils-Cultures 'AndcultureCode.CSharp.Core.Utilities.Localization.LocalizationUtils.Cultures')
- [Lockable](#T-AndcultureCode-CSharp-Core-Models-Lockable 'AndcultureCode.CSharp.Core.Models.Lockable')
  - [IsLocked](#P-AndcultureCode-CSharp-Core-Models-Lockable-IsLocked 'AndcultureCode.CSharp.Core.Models.Lockable.IsLocked')
  - [DetermineIfLocked()](#M-AndcultureCode-CSharp-Core-Models-Lockable-DetermineIfLocked 'AndcultureCode.CSharp.Core.Models.Lockable.DetermineIfLocked')
- [Provider](#T-AndcultureCode-CSharp-Core-Providers-Provider 'AndcultureCode.CSharp.Core.Providers.Provider')
  - [Implemented](#P-AndcultureCode-CSharp-Core-Providers-Provider-Implemented 'AndcultureCode.CSharp.Core.Providers.Provider.Implemented')
  - [Name](#P-AndcultureCode-CSharp-Core-Providers-Provider-Name 'AndcultureCode.CSharp.Core.Providers.Provider.Name')
- [Queue](#T-AndcultureCode-CSharp-Core-Constants-Queue 'AndcultureCode.CSharp.Core.Constants.Queue')
  - [ALL](#F-AndcultureCode-CSharp-Core-Constants-Queue-ALL 'AndcultureCode.CSharp.Core.Constants.Queue.ALL')
  - [DEFAULT](#F-AndcultureCode-CSharp-Core-Constants-Queue-DEFAULT 'AndcultureCode.CSharp.Core.Constants.Queue.DEFAULT')
- [Rfc4646LanguageCodes](#T-AndcultureCode-CSharp-Core-Constants-Rfc4646LanguageCodes 'AndcultureCode.CSharp.Core.Constants.Rfc4646LanguageCodes')
- [StringExtensions](#T-AndcultureCode-CSharp-Core-Extensions-StringExtensions 'AndcultureCode.CSharp.Core.Extensions.StringExtensions')
  - [LoadTranslations()](#M-AndcultureCode-CSharp-Core-Extensions-StringExtensions-LoadTranslations-System-String,System-String,Newtonsoft-Json-JsonSerializerSettings- 'AndcultureCode.CSharp.Core.Extensions.StringExtensions.LoadTranslations(System.String,System.String,Newtonsoft.Json.JsonSerializerSettings)')

<a name='T-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider'></a>
## AmazonEBConfigurationProvider `type`

##### Namespace

AndcultureCode.CSharp.Core.Utilities.Configuration

##### Summary

Adds support to read environment variables from an Amazon Elastic Beanstalk EC2 instance

 At this time AWS stores these environment variables in its own proprietary configuration
 that we are forced to read and pipe to the application.

<a name='F-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-CONFIGURATION_FILE_PATH'></a>
### CONFIGURATION_FILE_PATH `constants`

##### Summary

Absolute path to the AWS Elastic Beanstalk windows instance configuration file

<a name='P-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-CachedConfiguration'></a>
### CachedConfiguration `property`

##### Summary

Must be static to cache initially loaded configuration across multiple requests

<a name='M-AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-Load'></a>
### Load() `method`

##### Summary

Load the configuration into the inherited 'Data' dictionary for use by ConfigurationRoot/Builder

##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Core-Utilities-Hosting-AndcultureCodeWebHost'></a>
## AndcultureCodeWebHost `type`

##### Namespace

AndcultureCode.CSharp.Core.Utilities.Hosting

<a name='M-AndcultureCode-CSharp-Core-Utilities-Hosting-AndcultureCodeWebHost-Preload-System-String[]-'></a>
### Preload() `method`

##### Summary

Entry point to our custom WebHost builder pattern.
From here extensions methods can but hung off of IAndcultureCodeWebHostBuilder

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Core-Constants-ApplicationConstants'></a>
## ApplicationConstants `type`

##### Namespace

AndcultureCode.CSharp.Core.Constants

##### Summary

Common application constants

<a name='F-AndcultureCode-CSharp-Core-Constants-ApplicationConstants-API_DATABASE_CONFIGURATION_KEY'></a>
### API_DATABASE_CONFIGURATION_KEY `constants`

##### Summary

Key name used to identify the API web application's primary
database in the 'ConnectionStrings' section

<a name='T-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration'></a>
## BasicAuthenticationConfiguration `type`

##### Namespace

AndcultureCode.CSharp.Core.Models.Configuration

##### Summary

Configuration properties available when setting up Basic HTTP authentication

<a name='P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-IsEnabled'></a>
### IsEnabled `property`

##### Summary

Is basic auth enabled for this environment?

<a name='P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-Password'></a>
### Password `property`

##### Summary

Password for users to use when authenticating

<a name='P-AndcultureCode-CSharp-Core-Models-Configuration-BasicAuthenticationConfiguration-UserName'></a>
### UserName `property`

##### Summary

Username for users to use when authenticating

<a name='T-AndcultureCode-CSharp-Core-Enumerations-BitwiseOperator'></a>
## BitwiseOperator `type`

##### Namespace

AndcultureCode.CSharp.Core.Enumerations

##### Summary

Simple Bitwise enumeration

<a name='T-AndcultureCode-CSharp-Core-Models-Connection'></a>
## Connection `type`

##### Namespace

AndcultureCode.CSharp.Core.Models

##### Summary

Breaks out standard connection string params into easy to consume object

<a name='P-AndcultureCode-CSharp-Core-Models-Connection-AdditionalParameters'></a>
### AdditionalParameters `property`

##### Summary

Additional configuration details

<a name='P-AndcultureCode-CSharp-Core-Models-Connection-Database'></a>
### Database `property`

##### Summary

Database name

<a name='P-AndcultureCode-CSharp-Core-Models-Connection-Datasource'></a>
### Datasource `property`

##### Summary

Data host

<a name='P-AndcultureCode-CSharp-Core-Models-Connection-Password'></a>
### Password `property`

##### Summary

Hopefully a secure password

<a name='P-AndcultureCode-CSharp-Core-Models-Connection-UserId'></a>
### UserId `property`

##### Summary

User identifier for the connectiong

<a name='M-AndcultureCode-CSharp-Core-Models-Connection-ToString-System-String-'></a>
### ToString(delimiter) `method`

##### Summary

Return the data to the form from which it came, a semi-colon delimited connection string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Core-Models-Connection-ValidParameter-System-String-'></a>
### ValidParameter(value) `method`

##### Summary

Determines if the supplied value is a valid param

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation'></a>
## CultureTranslation `type`

##### Namespace

AndcultureCode.CSharp.Core.Models.Localization

##### Summary

Translation of a specific term/key for the related culture.

 Keys are in the language of the default culture. (Hopefully the language of this code base :)

<a name='P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-FilePath'></a>
### FilePath `property`

##### Summary

Translation file from which this translation was loaded

<a name='P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-Key'></a>
### Key `property`

##### Summary

Unique key identifying the translation

<a name='P-AndcultureCode-CSharp-Core-Models-Localization-CultureTranslation-Value'></a>
### Value `property`

##### Summary

Translation of message for this culture

<a name='T-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration'></a>
## DataConfiguration `type`

##### Namespace

AndcultureCode.CSharp.Core.Models.Configuration

##### Summary

Commonly used string lengths for various types of data

<a name='F-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration-IP_ADDRESS_LENGTH'></a>
### IP_ADDRESS_LENGTH `constants`

##### Summary

Maximum storage length for IP address columns.
IPv4 is 15 characters and IPv6 is 39 characters

<a name='F-AndcultureCode-CSharp-Core-Models-Configuration-DataConfiguration-URL_LENGTH'></a>
### URL_LENGTH `constants`

##### Summary

IE has a max of 2083

<a name='T-AndcultureCode-CSharp-Core-Do`1'></a>
## Do\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core

<a name='M-AndcultureCode-CSharp-Core-Do`1-Finally-Microsoft-Extensions-Logging-ILogger,System-Action{AndcultureCode-CSharp-Core-Interfaces-IResult{`0}}-'></a>
### Finally(logger,workload) `method`

##### Summary

Extension of 'Finally' that will automatically log any thrown exceptions

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | Logger to use when an unhandled exception is caught |
| workload | [System.Action{AndcultureCode.CSharp.Core.Interfaces.IResult{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{AndcultureCode.CSharp.Core.Interfaces.IResult{`0}}') |  |

<a name='M-AndcultureCode-CSharp-Core-Do`1-Try-Microsoft-Extensions-Logging-ILogger,System-Func{AndcultureCode-CSharp-Core-Interfaces-IResult{`0},`0}-'></a>
### Try(logger,workload) `method`

##### Summary

Extension of 'Try' that will automatically log any thrown exceptions

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | Logger to use when an unhandled exception is caught |
| workload | [System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{\`0},\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{`0},`0}') |  |

<a name='M-AndcultureCode-CSharp-Core-Do`1-Try-Microsoft-Extensions-Logging-ILogger,System-UInt32,System-Func{AndcultureCode-CSharp-Core-Interfaces-IResult{`0},`0}-'></a>
### Try(logger,workload,retry) `method`

##### Summary

Tries to run the given workload the indicated number of times

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') | Logger used to log errors with |
| workload | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | Workload to be performed |
| retry | [System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{\`0},\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{AndcultureCode.CSharp.Core.Interfaces.IResult{`0},`0}') | Number of retries that should be performed. If value is
        zero, will not retry |

<a name='T-AndcultureCode-CSharp-Core-Providers-EmailProviderBase'></a>
## EmailProviderBase `type`

##### Namespace

AndcultureCode.CSharp.Core.Providers

##### Summary

Base abstract class to provide email provider functionality

<a name='M-AndcultureCode-CSharp-Core-Providers-EmailProviderBase-Send-MimeKit-MimeMessage-'></a>
### Send(message) `method`

##### Summary

Deliver a message now

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [MimeKit.MimeMessage](#T-MimeKit-MimeMessage 'MimeKit.MimeMessage') |  |

<a name='M-AndcultureCode-CSharp-Core-Providers-EmailProviderBase-SendLater-MimeKit-MimeMessage-'></a>
### SendLater(message) `method`

##### Summary

Deliver a message later (via background jobs likely)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [MimeKit.MimeMessage](#T-MimeKit-MimeMessage 'MimeKit.MimeMessage') |  |

<a name='T-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings'></a>
## EmailSettings `type`

##### Namespace

AndcultureCode.CSharp.Core.Models.Mail

##### Summary

Commonly used email settings

<a name='F-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-ERROR_MISSING_PROPERTY'></a>
### ERROR_MISSING_PROPERTY `constants`

##### Summary

Required property is not supplied

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-CustomHeaders'></a>
### CustomHeaders `property`

##### Summary

Comma-separated list of custom X-Headers

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-CustomHeadersAsDictionary'></a>
### CustomHeadersAsDictionary `property`

##### Summary

Transforms 'CustomHeaders' into a dictionary

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-DeveloperEmailAddress'></a>
### DeveloperEmailAddress `property`

##### Summary

This email address is for global use of background jobs and other processes
that warrant developer attention if it fails or succeeds

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-SendTestEmail'></a>
### SendTestEmail `property`

##### Summary

Should a test email be used?

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-TestEmailAddress'></a>
### TestEmailAddress `property`

##### Summary

This email address is used for automated testing

<a name='P-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-TestEmailEnvironmentToken'></a>
### TestEmailEnvironmentToken `property`

##### Summary

Test email's environment token

<a name='M-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-GetDeveloperEmailAddress-System-String-'></a>
### GetDeveloperEmailAddress(environmentName) `method`

##### Summary

Returns developer account email address for specified environment

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| environmentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Core-Models-Mail-EmailSettings-GetRecipientEmailOrTest-System-String,System-String,System-Boolean-'></a>
### GetRecipientEmailOrTest(email,environmentName,isProduction) `method`

##### Summary

Handles determining if we are sending a test e-mail or not, and creates a list containing the appropriate address.

##### Returns

Returns a list containing the appropriate address. Returns an empty list if we're not on production and environment variables don't indicate to send a test e-mail.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The intended recipient e-mail |
| environmentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| isProduction | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='T-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions'></a>
## EnumerableExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

<a name='M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-String},System-String-'></a>
### Join(list,delimiter) `method`

##### Summary

Convenience method so joining strings reads better :)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-String}},System-String,System-String-'></a>
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

<a name='M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-List{System-String},System-String-'></a>
### Join(list,delimiter) `method`

##### Summary

Convenience method so joining a list of strings

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [System.Collections.Generic.List{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-EnumerableExtensions-Join-System-Collections-Generic-KeyValuePair{System-String,System-String},System-String-'></a>
### Join(pair,delimiter) `method`

##### Summary

Convenience method so joining key value pairs

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pair | [System.Collections.Generic.KeyValuePair{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyValuePair 'System.Collections.Generic.KeyValuePair{System.String,System.String}') |  |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder'></a>
## IAndcultureCodeWebHostBuilder `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Hosting

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder-Args'></a>
### Args `property`

##### Summary

The command line args to dotnet process. Ultimately piped to AspNetCore WebHost.

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder-CreateDefaultBuilder'></a>
### CreateDefaultBuilder() `method`

##### Summary

Simple wrapper around AspNetCore WebHost.CreateDefaultBuilder
to support our own extensibility model

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Core-Extensions-IAndcultureCodeWebHostBuilderExtensions'></a>
## IAndcultureCodeWebHostBuilderExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

<a name='M-AndcultureCode-CSharp-Core-Extensions-IAndcultureCodeWebHostBuilderExtensions-PreloadAmazonElasticBeanstalk-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder,System-Boolean,AndcultureCode-CSharp-Core-Utilities-Configuration-AmazonEBConfigurationProvider-'></a>
### PreloadAmazonElasticBeanstalk(builder,stdoutEnabled) `method`

##### Summary

Configures resources from Amazon Elastic Beanstalk (EB) before AspNetCore
is started up. Namely, reading of ASPNET environment

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| builder | [AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder](#T-AndcultureCode-CSharp-Core-Interfaces-Hosting-IAndcultureCodeWebHostBuilder 'AndcultureCode.CSharp.Core.Interfaces.Hosting.IAndcultureCodeWebHostBuilder') |  |
| stdoutEnabled | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should errors be output to standard output for debugging being this could be run before logging starts |

<a name='T-AndcultureCode-CSharp-Core-Extensions-IConfigurationBuilderExtensions'></a>
## IConfigurationBuilderExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

<a name='M-AndcultureCode-CSharp-Core-Extensions-IConfigurationBuilderExtensions-AddAmazonElasticBeanstalk-Microsoft-Extensions-Configuration-IConfigurationBuilder-'></a>
### AddAmazonElasticBeanstalk(configurationBuilder) `method`

##### Summary

Configures dotnet IConfigurationBuilder to read Amazon Elastic Beanstalk instance environment variables

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configurationBuilder | [Microsoft.Extensions.Configuration.IConfigurationBuilder](#T-Microsoft-Extensions-Configuration-IConfigurationBuilder 'Microsoft.Extensions.Configuration.IConfigurationBuilder') |  |

##### Example

```
new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddAmazonElasticBeanstalk()
    .AddEnvironmentVariables();
```

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection'></a>
## IConnection `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Data

##### Summary

Describes standard database connection

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-AdditionalParameters'></a>
### AdditionalParameters `property`

##### Summary

Additional custom configuration parameters

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Database'></a>
### Database `property`

##### Summary

Name of database

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Datasource'></a>
### Datasource `property`

##### Summary

Url/Name for server

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-Password'></a>
### Password `property`

##### Summary

Hopefully a secure password

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-UserId'></a>
### UserId `property`

##### Summary

User identifier

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IConnection-ToString-System-String-'></a>
### ToString() `method`

##### Summary

Single flattened string representation for the connection

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Core-Interfaces-ICulture'></a>
## ICulture `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces

<a name='P-AndcultureCode-CSharp-Core-Interfaces-ICulture-Code'></a>
### Code `property`

##### Summary

RFC-4646 5-character Culture code (xx-XX)

<a name='P-AndcultureCode-CSharp-Core-Interfaces-ICulture-IsDefault'></a>
### IsDefault `property`

##### Summary

Is this the default locale in the application? There can only be one

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider'></a>
## IEmailProvider `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Providers.Mail

##### Summary

Generic email provider

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider-Send-MimeKit-MimeMessage-'></a>
### Send(message) `method`

##### Summary

Send an email immediately

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [MimeKit.MimeMessage](#T-MimeKit-MimeMessage 'MimeKit.MimeMessage') | The message to be sent |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Providers-Mail-IEmailProvider-SendLater-MimeKit-MimeMessage-'></a>
### SendLater(message) `method`

##### Summary

Send an email via a background job

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [MimeKit.MimeMessage](#T-MimeKit-MimeMessage 'MimeKit.MimeMessage') | The message to be sent |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1'></a>
## ILockingConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-ExtendLock-System-Int64,System-DateTimeOffset,System-Nullable{System-Int64}-'></a>
### ExtendLock(id,lockUntil,updatedById) `method`

##### Summary

Updates the LockedUntil field for the record, allowing the user that locked
it to have the lock for a longer amount of time.

##### Returns

the updated record if the lock is successfully extended, null otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The record id |
| lockUntil | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The time the record should be locked until |
| updatedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | The id of the user updating the record's lock time |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-Lock-System-Int64,System-DateTimeOffset,System-Nullable{System-Int64}-'></a>
### Lock(id,lockUntil,lockedById) `method`

##### Summary

Updates the locking fields to be set, which denotes that the user locking the record should
have exclusive access to modifying it for the lock's duration. This, however, does
not prohibit the record from being modified by others. When a record is locked, the
ValidateLock method below should be used to determine if the record can be modified. This will
ensure that only the user that locked the record is actually able to modify its contents.

##### Returns

the updated record if it is successfully locked, null otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The record id |
| lockUntil | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The time the record should be locked until |
| lockedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | The id of the user locking the record |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-Unlock-System-Int64,System-Nullable{System-Int64}-'></a>
### Unlock(id,unlockedById) `method`

##### Summary

Updates the locking fields back to null, meaning any user will be able to acquire a lock
so they have exclusive access to editing it.

##### Returns

the updated record if it is successfully unlocked, null otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The record id |
| unlockedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | The id of the user unlocking the record |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-ILockingConductor`1-ValidateLock-`0,System-Nullable{System-Int64}-'></a>
### ValidateLock(item,currentUserId) `method`

##### Summary

Used to determine whether or not the user attempting to update the record is the
user that has the lock, AND that the lock is still valid (i.e. not expired).

##### Returns

true if the lock is still active and is locked by the current user, false otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [\`0](#T-`0 '`0') | The item |
| currentUserId | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | The current user id |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider'></a>
## IProvider `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Providers

##### Summary

Foundation configuration for providers

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider-Implemented'></a>
### Implemented `property`

##### Summary

Specify whether the provider has been implemented

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Providers-IProvider-Name'></a>
### Name `property`

##### Summary

Name of the provider

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1'></a>
## IRepositoryConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-BulkCreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkCreateOrUpdate() `method`

##### Summary

Automatically determines if the supplied entity needs created or updated.

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CreateOrUpdate-`0,System-Nullable{System-Int64}-'></a>
### CreateOrUpdate() `method`

##### Summary

Automatically determines if the supplied entity needs created or updated.

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryConductor`1-CreateOrUpdate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### CreateOrUpdate(items,createdOrUpdatedById) `method`

##### Summary

Automatically determines if the supplied entities need created or updated.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') |  |
| createdOrUpdatedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') |  |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1'></a>
## IRepositoryCreateConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### BulkCreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Calls BulkCreate() with a de-duped list of objects as determined by the
property (or properties) of the object for the 'property' argument
NOTE: Bulking is generally faster than batching, but locks the table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to attempt to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property or properties of the typed object to determine distinctness |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of the user creating the entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryCreateConductor`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### CreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Calls batched overload of Create() with a de-duped list of objects as determined by the
property (or properties) of the object for the 'property' argument.
NOTE: Batching is generally slower than bulking, but does not lock the table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to attempt to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property or properties of the typed object to determine distinctness |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of the user creating the entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor`1'></a>
## IRepositoryDeleteConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryDeleteConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1'></a>
## IRepositoryReadConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-FindAll-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean},System-Boolean-'></a>
### FindAll(filter,orderBy,nextLinkParams) `method`

##### Summary

Altenative FindAll for retrieving records using NextLinkParams in place of tranditonal
determinate pagination mechanisms, such as; skip and take.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') |  |
| orderBy | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') |  |
| nextLinkParams | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryReadConductor`1-FindAllCommitted-System-Collections-Generic-Dictionary{System-String,System-String},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-Nullable{System-Boolean}-'></a>
### FindAllCommitted(filter,orderBy,nextLinkParams) `method`

##### Summary

Altenative FindAll for retrieving records using NextLinkParams in place of tranditonal
determinate pagination mechanisms, such as; skip and take.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') |  |
| orderBy | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') |  |
| nextLinkParams | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') |  |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor`1'></a>
## IRepositoryUpdateConductor\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Conductors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Conductors-IRepositoryUpdateConductor`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='T-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1'></a>
## IRepository\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces.Data

##### Summary



##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='P-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Ability to set and get the underlying DbContext's command timeout

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkCreate-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### BulkCreate(items,createdById) `method`

##### Summary

Perform a DbContext.BulkInsert on an enumeration of T within a single transaction

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') |  |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkCreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### BulkCreateDistinct\`\`1(items,property,createdById,items,property,createdById) `method`

##### Summary

Calls BulkCreate() with a de-duped list of objects as determined by the
property (or properties) of the object for the 'property' argument
NOTE: Bulking is generally faster than batching, but locks the table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to attempt to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property or properties of the typed object to determine distinctness |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of the user creating the entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |
| TKey |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-BulkDelete-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64},System-Boolean-'></a>
### BulkDelete(items,deletedById,soft) `method`

##### Summary

Calls BulkDelete() with a de-duped list of objects as determined by the
property (or properties) of the object for the 'property' argument
NOTE: Bulking is generally faster than batching, but locks the table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') |  |
| deletedById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') |  |
| soft | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-CreateDistinct``1-System-Collections-Generic-IEnumerable{`0},System-Func{`0,``0},System-Nullable{System-Int64}-'></a>
### CreateDistinct\`\`1(items,property,createdById) `method`

##### Summary

Calls batched overload of Create() with a de-duped list of objects as determined by the
property (or properties) of the object for the 'property' argument.
NOTE: Batching is generally slower than bulking, but does not lock the table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | List of items to attempt to create |
| property | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | Property or properties of the typed object to determine distinctness |
| createdById | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') | Id of the user creating the entity |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-FindAll-System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{System-Linq-IQueryable{`0},System-Linq-IOrderedQueryable{`0}},System-String,System-Nullable{System-Int32},System-Nullable{System-Int32},System-Nullable{System-Boolean},System-Boolean-'></a>
### FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking) `method`

##### Summary

Find all filtered, sorted and paged

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') |  |
| orderBy | [System.Func{System.Linq.IQueryable{\`0},System.Linq.IOrderedQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0},System.Linq.IOrderedQueryable{`0}}') |  |
| includeProperties | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| skip | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |
| take | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |
| ignoreQueryFilters | [System.Nullable{System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Boolean}') |  |
| asNoTracking | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-AndcultureCode-CSharp-Core-Interfaces-Data-IRepository`1-Update-System-Collections-Generic-IEnumerable{`0},System-Nullable{System-Int64}-'></a>
### Update(entities,updatedBy) `method`

##### Summary

Calls Update one-by-one for each item in the enumerated entities. 
For large operations, BulkUpdate() is more efficient.

##### Returns

True if entities updated without any exceptions. False if an exception was thrown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entities | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') |  |
| updatedBy | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') |  |

<a name='T-AndcultureCode-CSharp-Core-Extensions-IResultExtensions'></a>
## IResultExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]-'></a>
### AddErrorAndLog\`\`1(result,logger,localizer,errorKey,arguments) `method`

##### Summary

Add translated error record and log un-translated message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| errorKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Nullable{System-Int64},System-Object[]-'></a>
### AddErrorAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,arguments) `method`

##### Summary

Add translated error record and log un-translated message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| errorKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| resourceIdentifier | [System.Nullable{System.Int64}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int64}') |  |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Int64,System-Object[]-'></a>
### AddErrorAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,arguments) `method`

##### Summary

Add translated error record and log un-translated message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| errorKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| resourceIdentifier | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]-'></a>
### AddError\`\`1(result,localizer,key,arguments) `method`

##### Summary

Add translated error record of type Error

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,AndcultureCode-CSharp-Core-Enumerations-ErrorType,System-String,System-Object[]-'></a>
### AddError\`\`1(result,localizer,key,arguments) `method`

##### Summary

Add translated error record

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| key | [AndcultureCode.CSharp.Core.Enumerations.ErrorType](#T-AndcultureCode-CSharp-Core-Enumerations-ErrorType 'AndcultureCode.CSharp.Core.Enumerations.ErrorType') | Error key found in culture files |
| arguments | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String-'></a>
### AddError\`\`1(result,message) `method`

##### Summary

Adds a new error with the calling class and method name as the key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,System-String,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{AndcultureCode-CSharp-Core-Interfaces-IError},System-String-'></a>
### AddErrorsAndLog\`\`1(result,logger,errorKey,errorMessage,logMessage,resourceIdentifier,errors,methodName) `method`

##### Summary

Add error record and log message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| errorKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| errorMessage | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Translated error message |
| logMessage | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Log message - commonly un-translated version of errorMessage |
| resourceIdentifier | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| errors | [System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError}') | Additional errors to forward. These are assumed to have already been translated. |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of calling method for use in log message for improved debugging |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndLog``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Logging-ILogger,Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Int64,System-Collections-Generic-IEnumerable{AndcultureCode-CSharp-Core-Interfaces-IError},System-Object[]-'></a>
### AddErrorsAndLog\`\`1(result,logger,localizer,errorKey,resourceIdentifier,errors,arguments) `method`

##### Summary

Add translated error record and log un-translated message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| logger | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| errorKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| resourceIdentifier | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |
| errors | [System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{AndcultureCode.CSharp.Core.Interfaces.IError}') | Additional errors to forward. These are assumed to have already been translated. |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddErrorsAndReturnDefault``2-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-IResult{``1}-'></a>
### AddErrorsAndReturnDefault\`\`2(destination,source) `method`

##### Summary

Convenience method to simplify common scenario of bubbling errors and
returning null (or default for T type) to the parent

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| destination | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| source | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`1}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``1} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TSource |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddNextLinkParam``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},System-String,System-String-'></a>
### AddNextLinkParam\`\`1(result,key,value) `method`

##### Summary

Adds a new key value pair to the NextLinkParams. Essentially saves needing to
null check and externally manage NextLinkParams property directly.

##### Returns

Reference to NextLinkParams

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Unique key to add for next link params |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Value for supplied key. Can be null |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddNextLinkParams``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},AndcultureCode-CSharp-Core-Interfaces-IResult{``0}-'></a>
### AddNextLinkParams\`\`1(destinationResult,sourceResult) `method`

##### Summary

Adds NextLinkParams key value pairs from a source IResult to a destination IResult.

 The destination result's NextLinkParams dictionary reference will remain unchanged.

##### Returns

Reference to NextLinkParams

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| destinationResult | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | IResult destination to which next link params are copied |
| sourceResult | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') | IResult source from which to copy next link params |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Core-Extensions-IResultExtensions-AddValidationError``1-AndcultureCode-CSharp-Core-Interfaces-IResult{``0},Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]-'></a>
### AddValidationError\`\`1(result,localizer,key,arguments) `method`

##### Summary

Add translated error record of type Validation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| result | [AndcultureCode.CSharp.Core.Interfaces.IResult{\`\`0}](#T-AndcultureCode-CSharp-Core-Interfaces-IResult{``0} 'AndcultureCode.CSharp.Core.Interfaces.IResult{``0}') |  |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error key found in culture files |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='T-AndcultureCode-CSharp-Core-Interfaces-IResult`1'></a>
## IResult\`1 `type`

##### Namespace

AndcultureCode.CSharp.Core.Interfaces

<a name='P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-ErrorCount'></a>
### ErrorCount `property`

##### Summary

Number of errors

<a name='P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-Errors'></a>
### Errors `property`

##### Summary

List of errors around a request

<a name='P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-HasErrors'></a>
### HasErrors `property`

##### Summary

Does this result contain any errors?

<a name='P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-NextLinkParams'></a>
### NextLinkParams `property`

##### Summary

List of key value pairs to be used request the very next related Result

<a name='P-AndcultureCode-CSharp-Core-Interfaces-IResult`1-ResultObject'></a>
### ResultObject `property`

##### Summary

Actual resulting value from the request

<a name='T-AndcultureCode-CSharp-Core-Extensions-IStringLocalizerExtensions'></a>
## IStringLocalizerExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

<a name='M-AndcultureCode-CSharp-Core-Extensions-IStringLocalizerExtensions-Default-Microsoft-Extensions-Localization-IStringLocalizer,System-String,System-Object[]-'></a>
### Default(localizer,key,arguments) `method`

##### Summary

Retrieve given translation for default configured culture

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| localizer | [Microsoft.Extensions.Localization.IStringLocalizer](#T-Microsoft-Extensions-Localization-IStringLocalizer 'Microsoft.Extensions.Localization.IStringLocalizer') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | The values with which to format the translated error message |

<a name='T-AndcultureCode-CSharp-Core-Utilities-Localization-LocalizationUtils'></a>
## LocalizationUtils `type`

##### Namespace

AndcultureCode.CSharp.Core.Utilities.Localization

<a name='P-AndcultureCode-CSharp-Core-Utilities-Localization-LocalizationUtils-Cultures'></a>
### Cultures `property`

##### Summary

Current cultures supported by the application

<a name='T-AndcultureCode-CSharp-Core-Models-Lockable'></a>
## Lockable `type`

##### Namespace

AndcultureCode.CSharp.Core.Models

<a name='P-AndcultureCode-CSharp-Core-Models-Lockable-IsLocked'></a>
### IsLocked `property`

##### Summary

Calculated field based on if LockedUntil (when not null) is in the past or future.

<a name='M-AndcultureCode-CSharp-Core-Models-Lockable-DetermineIfLocked'></a>
### DetermineIfLocked() `method`

##### Summary

A record is considered "locked" if the LockedUntil field is not null
and is set to a time in the future

##### Returns

true if LockedUntil is not null and is set to a time in the future, false otherwise

##### Parameters

This method has no parameters.

<a name='T-AndcultureCode-CSharp-Core-Providers-Provider'></a>
## Provider `type`

##### Namespace

AndcultureCode.CSharp.Core.Providers

##### Summary

Base implementation for Providers

<a name='P-AndcultureCode-CSharp-Core-Providers-Provider-Implemented'></a>
### Implemented `property`

##### Summary

Specify whether the provider has been implemented

<a name='P-AndcultureCode-CSharp-Core-Providers-Provider-Name'></a>
### Name `property`

##### Summary

Name of the provider

<a name='T-AndcultureCode-CSharp-Core-Constants-Queue'></a>
## Queue `type`

##### Namespace

AndcultureCode.CSharp.Core.Constants

<a name='F-AndcultureCode-CSharp-Core-Constants-Queue-ALL'></a>
### ALL `constants`

##### Summary

Easy to access array of all queues in priority order from highest to lowest

<a name='F-AndcultureCode-CSharp-Core-Constants-Queue-DEFAULT'></a>
### DEFAULT `constants`

##### Summary

The default queue, general purpose that should happen relatively soon. Say a few minutes, but the world won't end
if it happens to be delayed.

<a name='T-AndcultureCode-CSharp-Core-Constants-Rfc4646LanguageCodes'></a>
## Rfc4646LanguageCodes `type`

##### Namespace

AndcultureCode.CSharp.Core.Constants

##### Summary

RFC-4646 Language Codes
See https://docs.microsoft.com/en-us/previous-versions/commerce-server/ee825488(v=cs.20)?redirectedfrom=MSDN

<a name='T-AndcultureCode-CSharp-Core-Extensions-StringExtensions'></a>
## StringExtensions `type`

##### Namespace

AndcultureCode.CSharp.Core.Extensions

##### Summary

String extension methods

<a name='M-AndcultureCode-CSharp-Core-Extensions-StringExtensions-LoadTranslations-System-String,System-String,Newtonsoft-Json-JsonSerializerSettings-'></a>
### LoadTranslations() `method`

##### Summary

Loads a given translation .json file and maps contents to CultureTranslation objects

##### Parameters

This method has no parameters.
