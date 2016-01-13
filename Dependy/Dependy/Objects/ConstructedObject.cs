// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstructedObject.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The constructed object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Objects
{
    using System;

    /// <summary>
    /// The constructed object.
    /// </summary>
    public class ConstructedObject
    {
        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        public Type ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        public object Object { get; set; }
    }
}
