// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransientRegistration.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The transient registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Objects
{
    using Dependy.Enumerations;
    using Dependy.Factories;
    using Dependy.Interfaces;

    /// <summary>
    /// The transient registration.
    /// </summary>
    /// <typeparam name="TResolve">
    /// The resolve type.
    /// </typeparam>
    internal class TransientRegistration<TResolve> : RegistrationBase, IRegistration
        where TResolve : class
    {
        /// <summary>
        /// Gets the lifecycle.
        /// </summary>
        public Lifecycle Lifecycle
        {
            get
            {
                return Lifecycle.Transient;
            }
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="TResolved"/>.
        /// </returns>
        public object GetInstance(object[] parameters)
        {
            return InstanceFactory.CreateInstance<TResolve>(parameters);
        }
    }
}
