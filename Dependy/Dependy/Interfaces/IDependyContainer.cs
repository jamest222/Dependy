// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependyContainer.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The DependyContainer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Interfaces
{
    using Dependy.Enumerations;

    /// <summary>
    /// The DependyContainer interface.
    /// </summary>
    public interface IDependyContainer
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <typeparam name="TDependency">
        /// Dependency type.
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// Resolved type.
        /// </typeparam>
        void Add<TDependency, TResolve>() where TResolve : class, TDependency;

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="lifecyle">
        /// The lifecyle.
        /// </param>
        /// <typeparam name="TDependency">
        /// Dependency type.
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// Resolved type.
        /// </typeparam>
        void Add<TDependency, TResolve>(Lifecycle lifecyle) where TResolve: class, TDependency;

        /// <summary>
        /// The get.
        /// </summary>
        /// <typeparam name="TDependency">
        /// Dependency type to resolve.
        /// </typeparam>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        TDependency Get<TDependency>();
    }
}
