// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegistration.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The Registration interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Interfaces
{
    using System;

    using Dependy.Enumerations;

    /// <summary>
    /// The Registration interface.
    /// </summary>
    internal interface IRegistration
    {
        /// <summary>
        /// Gets or sets the dependency.
        /// </summary>
        Type Dependency { get; set; }

        /// <summary>
        /// Gets or sets the resolve type.
        /// </summary>
        Type ResolveType { get; set; }

        /// <summary>
        /// Gets or sets the lifecycle.
        /// </summary>
        Lifecycle Lifecycle { get; }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="IRegistration"/>.
        /// </returns>
        object GetInstance();
    }
}
