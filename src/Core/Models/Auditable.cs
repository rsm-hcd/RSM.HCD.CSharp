using System;
using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Core.Models.Entities;

namespace RSM.HCD.CSharp.Core.Models
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
    /// </summary>
    public abstract class Auditable : Entity, IAuditable
    {
        #region IAuditable Implementation

        /// <summary>
        /// The identifier of the user who created the record
        /// </summary>
        public long? CreatedById { get; set; }

        /// <summary>
        /// The date and time of the record creation
        /// </summary>
        public DateTimeOffset? CreatedOn { get; set; }

        /// <summary>
        /// The identifier of the user who performed the Delete
        /// </summary>
        public long? DeletedById { get; set; }

        /// <summary>
        /// The date and time of the record deletion
        /// </summary>
        public DateTimeOffset? DeletedOn { get; set; }

        /// <summary>
        /// The identifier of the user who performed the Update
        /// </summary>
        public long? UpdatedById { get; set; }

        /// <summary>
        /// The date and time of the record update
        /// </summary>
        public DateTimeOffset? UpdatedOn { get; set; }

        #endregion IAuditable Implementation
    }
}
