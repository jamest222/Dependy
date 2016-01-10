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
        void Add<TDependency, TResolve>() where TResolve : TDependency;

        /// <summary>
        /// The get.
        /// </summary>
        /// <typeparam name="TDependency">
        /// Dependency type to resolve.
        /// </typeparam>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object Get<TDependency>();
    }
}
