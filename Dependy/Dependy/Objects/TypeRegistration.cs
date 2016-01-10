﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeRegistration.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The type registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Objects
{
    using System;

    /// <summary>
    /// The type registration.
    /// </summary>
    internal class TypeRegistration
    {
        /// <summary>
        /// Gets or sets the dependency.
        /// </summary>
        public Type Dependency { get; set; }

        /// <summary>
        /// Gets or sets the resolve type.
        /// </summary>
        public Type ResolveType { get; set; }
    }
}
