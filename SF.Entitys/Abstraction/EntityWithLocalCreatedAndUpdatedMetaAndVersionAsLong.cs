﻿ 
namespace SF.Entitys.Abstraction
{
    using System;

    /// <summary>
    /// Represents an entity that has an unique identifier, local created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    /// <typeparam name="TUpdatedBy">The updated by type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedBy, TUpdatedBy>
        : EntityWithTypedId<TIdentity>, IHaveLocalCreatedMeta<TCreatedBy>, IHaveLocalUpdatedMeta<TUpdatedBy>, IHaveVersionAsLong
    {
        private DateTime _createdOn;
        private DateTime _updatedOn;

        #region Implementation of IHaveLocalCreatedMeta<TCreatedBy>

        /// <summary>
        /// The <see cref="DateTime"/> when it was created
        /// </summary>
        public virtual DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which first created this entity
        /// </summary>
        public virtual TCreatedBy CreatedBy { get; set; }

        #endregion

        #region Implementation of IHaveLocalUpdatedMeta<TUpdatedBy>

        /// <summary>
        /// The <see cref="DateTime"/> when it was last updated
        /// </summary>
        public virtual DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which last updated this entity
        /// </summary>
        public virtual TUpdatedBy UpdatedBy { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTime.Now"/>
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {
            _createdOn = _updatedOn = DateTime.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTime.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            _createdOn = _updatedOn = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedAndUpdated">The created, updated and deleted by type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedAndUpdated>
        : EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedAndUpdated, TCreatedAndUpdated>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {
            
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveLocalCreatedMeta{T}.CreatedBy"/>,
    /// and <see cref="IHaveLocalUpdatedMeta{T}.UpdatedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity>
        : EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, string, string>, IHaveLocalCreatedMeta, IHaveLocalUpdatedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {

        }
    }
}
