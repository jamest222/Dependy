// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceFactory.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   Defines the InstanceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dependy.Objects;

    /// <summary>
    /// The instance factory.
    /// </summary>
    internal static class InstanceFactory
    {
        /// <summary>
        /// The create instance.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="TResolve">
        /// The resolve type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResolve"/>.
        /// </returns>
        internal static TResolve CreateInstance<TResolve>(IEnumerable<ConstructedObject> parameters)
        {
            if (parameters.Any())
            {
                return (TResolve)Activator.CreateInstance(typeof(TResolve), parameters.Select(p => p.Object).ToArray());
            }

            return (TResolve)Activator.CreateInstance(typeof(TResolve));
        }
    }
}
