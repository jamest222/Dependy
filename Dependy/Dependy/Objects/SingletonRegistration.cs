// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingletonRegistration.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The singleton registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dependy.Enumerations;
    using Dependy.Factories;
    using Dependy.Interfaces;

    /// <summary>
    /// The singleton registration.
    /// </summary>
    /// <typeparam name="TResolved">
    /// The resolved type.
    /// </typeparam>
    internal class SingletonRegistration<TResolved> : RegistrationBase, IRegistration
        where TResolved : class
    {
        /// <summary>
        /// The created object.
        /// </summary>
        private TResolved createdObject;

        /// <summary>
        /// Gets the lifecycle.
        /// </summary>
        public Lifecycle Lifecycle
        {
            get
            {
                return Lifecycle.Singleton;  
            }
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IRegistration"/>.
        /// </returns>
        public object GetInstance(IEnumerable<ConstructedObject> parameters)
        {
            return this.createdObject ?? (this.createdObject = InstanceFactory.CreateInstance<TResolved>(parameters));
        }
    }
}
