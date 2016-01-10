﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependyContainer.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The dependy container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dependy.Interfaces;
    using Dependy.Objects;

    /// <summary>
    /// The dependy container.
    /// </summary>
    public class DependyContainer : IDependyContainer
    {
        /// <summary>
        /// The registrations.
        /// </summary>
        private readonly List<TypeRegistration> registrations;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependyContainer"/> class.
        /// </summary>
        public DependyContainer()
        {
            this.registrations = new List<TypeRegistration>();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <typeparam name="TDependency">
        /// The dependency type
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// The resolution type
        /// </typeparam>
        public void Add<TDependency, TResolve>() where TResolve : TDependency
        {
            this.registrations.Add(new TypeRegistration { Dependency = typeof(TDependency), ResolveType = typeof(TResolve) });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <typeparam name="TDependency">
        /// The dependency type
        /// </typeparam>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Get<TDependency>()
        {
            var typeRegistration = this.registrations.FirstOrDefault(r => r.Dependency == typeof(TDependency));
            if (typeRegistration == null)
            {
                // throw exception
            }

            return Activator.CreateInstance(typeRegistration.ResolveType);
        }
    }
}
