﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Linq;

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
        internal static TResolve CreateInstance<TResolve>(object[] parameters)
        {
            var resolvedInstance = default(TResolve);
            if (parameters.Any())
            {
                resolvedInstance = (TResolve)Activator.CreateInstance(typeof(TResolve), parameters);
            }
            else
            {
                resolvedInstance = (TResolve)Activator.CreateInstance(typeof(TResolve));
            }

            return resolvedInstance;
        }
    }
}
