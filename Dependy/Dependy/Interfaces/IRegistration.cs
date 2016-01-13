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
    using System.Collections.Generic;

    using Dependy.Enumerations;
    using Dependy.Objects;

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
        /// Gets the lifecycle.
        /// </summary>
        Lifecycle Lifecycle { get; }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IRegistration"/>.
        /// </returns>
        object GetInstance(IEnumerable<ConstructedObject> parameters);
    }
}
