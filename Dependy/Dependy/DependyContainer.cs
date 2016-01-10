// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependyContainer.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The dependy container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy
{
    using Dependy.Interfaces;

    /// <summary>
    /// The dependy container.
    /// </summary>
    public class DependyContainer : IDependyContainer
    {
        public void Add<TDependency, TResolve>()
        {
            throw new System.NotImplementedException();
        }

        public object Get<TDependency>()
        {
            throw new System.NotImplementedException();
        }
    }
}
