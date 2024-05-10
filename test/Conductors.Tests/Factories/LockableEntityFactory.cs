using System;
using RSM.HCD.CSharp.Conductors.Tests.Stubs;
using RSM.HCD.CSharp.Testing.Factories;

namespace RSM.HCD.CSharp.Conductors.Tests.Factories
{
    /// <summary>
    /// Factory for building out configurations of the `LockableEntity` class
    /// </summary>
    public class LockableEntityFactory : Factory
    {
        #region Constants

        /// <summary>
        /// Represents a resource that was previously locked by a user.
        /// </summary>
        public const string EXPIRED = "EXPIRED";

        /// <summary>
        /// Represents a resource that is currently locked by a user.
        /// </summary>
        public const string LOCKED = "LOCKED";

        /// <summary>
        /// Represents a resource that is not currently locked by any user.
        /// </summary>
        public const string UNLOCKED = "UNLOCKED";

        #endregion Constants

        #region Public Methods

        /// <inheritdoc />
        public override void Define()
        {
            this.DefineFactory(() => new LockableEntity
            {
                Name = Random.Uuid().ToString()
            });

            this.DefineFactory(EXPIRED, () => new LockableEntity
            {
                LockedById = Random.Long(min: 1, max: 100),
                LockedOn = DateTimeOffset.UtcNow.AddMinutes(-30),
                LockedUntil = DateTimeOffset.UtcNow.AddMinutes(-15),
                Name = Random.Uuid().ToString(),
            });

            this.DefineFactory(LOCKED, () => new LockableEntity
            {
                LockedById = Random.Long(min: 1, max: 100),
                LockedOn = DateTimeOffset.UtcNow.AddMinutes(-15),
                LockedUntil = DateTimeOffset.UtcNow.AddMinutes(15),
                Name = Random.Uuid().ToString(),
            });

            this.DefineFactory(UNLOCKED, () => new LockableEntity
            {
                LockedById = null,
                LockedOn = null,
                LockedUntil = null,
                Name = Random.Uuid().ToString(),
            });
        }

        #endregion Public Methods
    }
}
