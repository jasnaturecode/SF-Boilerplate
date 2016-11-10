﻿ 
namespace SimpleFramework.Core.Abstraction.Entitys
{
    using System;

    /// <summary>
    /// Represents an entity that has an unique identifier, local created metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    public abstract class EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity, TCreatedBy>
        : EntityWithTypedId<TIdentity>, IHaveLocalCreatedMeta<TCreatedBy>, IHaveVersionAsLong
    {
        private DateTime _createdOn;

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

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> 
        /// to <see cref="DateTime.Now"/>
        /// </summary>
        protected EntityWithLocalCreatedMetaAndVersionAsLong()
        {
            _createdOn = DateTime.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> 
        /// to <see cref="DateTime.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            _createdOn = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveLocalCreatedMeta{T}.CreatedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity>
        : EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity, string>, IHaveLocalCreatedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedMetaAndVersionAsLong()
        {
            
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id"></param>
        protected EntityWithLocalCreatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            
        }
    }
}
