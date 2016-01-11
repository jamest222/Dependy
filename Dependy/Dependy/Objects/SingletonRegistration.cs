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

    using Dependy.Enumerations;
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
        /// <returns>
        /// The <see cref="IRegistration"/>.
        /// </returns>
        public object GetInstance()
        {
            return this.createdObject ?? (this.createdObject = (TResolved)Activator.CreateInstance(typeof(TResolved)));
        }
    }
}
