// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Injector.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The injector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Objects
{
    /// <summary>
    /// The injector.
    /// </summary>
    public class Injector
    {
        /// <summary>
        /// The dependency parameters.
        /// </summary>
        private readonly object[] dependencyParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Injector"/> class.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public Injector(params object[] parameters)
        {
            this.dependencyParameters = parameters;
        }

        /// <summary>
        /// Gets the dependency parameters.
        /// </summary>
        public object[] DependencyParameters
        {
            get
            {
                return this.dependencyParameters;
            }
        }
    }
}
