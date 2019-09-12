using System;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Core.Models
{
    public abstract class Auditable : Entity, IAuditable
    {
        #region IAuditable Implementation

        public long?           CreatedById { get; set; }
        public DateTimeOffset? CreatedOn   { get; set; }
        public long?           DeletedById { get; set; }
        public DateTimeOffset? DeletedOn   { get; set; }
        public long?           UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn   { get; set; }

        #endregion
    }
}