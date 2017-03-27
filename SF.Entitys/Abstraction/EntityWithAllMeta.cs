﻿
namespace SF.Entitys.Abstraction
{
    using System;

#if !NET20

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    /// <typeparam name="TUpdatedBy">The updated by type</typeparam>
    /// <typeparam name="TDeletedBy">The deleted by type</typeparam>
    public abstract class EntityWithAllMeta<TIdentity, TCreatedBy, TUpdatedBy, TDeletedBy>
        : EntityWithTypedId<TIdentity>, IHaveCreatedMeta<TCreatedBy>, IHaveUpdatedMeta<TUpdatedBy>, IHaveDeletedMeta<TDeletedBy>
    {
        private DateTimeOffset _createdOn;
        private DateTimeOffset _updatedOn;

        #region Implementation of IHaveCreatedMeta<TCreatedBy>

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was created
        /// </summary>
        public virtual DateTimeOffset CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which first created this entity
        /// </summary>
        public virtual TCreatedBy CreatedBy { get; set; }

        #endregion

        #region Implementation of IHaveUpdatedMeta<TUpdatedBy>

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was last updated
        /// </summary>
        public virtual DateTimeOffset UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which last updated this entity
        /// </summary>
        public virtual TUpdatedBy UpdatedBy { get; set; }

        #endregion

        #region Implementation of IHaveDeletedMeta<TDeletedBy>

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was soft deleted
        /// </summary>
        public virtual DateTimeOffset? DeletedOn { get; set; }

        /// <summary>
        /// The identifier (or entity) which soft deleted this entity
        /// </summary>
        public virtual TDeletedBy DeletedBy { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTimeOffset.Now"/>
        /// </summary>
        protected EntityWithAllMeta()
        {
            _createdOn = _updatedOn = DateTimeOffset.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTimeOffset.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithAllMeta(TIdentity id) : base(id)
        {
            _createdOn = _updatedOn = DateTimeOffset.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedUpdatedAndDeleted">The created, updated and deleted by type</typeparam>
    public abstract class EntityWithAllMeta<TIdentity, TCreatedUpdatedAndDeleted>
        : EntityWithAllMeta<TIdentity, TCreatedUpdatedAndDeleted, TCreatedUpdatedAndDeleted, TCreatedUpdatedAndDeleted>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMeta()
        {
            
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithAllMeta(TIdentity id) : base(id)
        {
            
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata,
    /// using a <see cref="string"/> as an identifier for the <see cref="IHaveCreatedMeta{T}.CreatedBy"/>,
    /// <see cref="IHaveUpdatedMeta{T}.UpdatedBy"/> and <see cref="IHaveDeletedMeta{T}.DeletedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithAllMeta<TIdentity>
        : EntityWithAllMeta<TIdentity, string, string, string>, IHaveCreatedMeta, IHaveUpdatedMeta, IHaveDeletedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMeta()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithAllMeta(TIdentity id) : base(id)
        {

        }
    }

#endif
}
