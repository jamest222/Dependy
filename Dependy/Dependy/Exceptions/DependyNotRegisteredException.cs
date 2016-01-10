// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependyNotRegisteredException.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The dependy not registered exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Exceptions
{
    using System;

    /// <summary>
    /// The dependy not registered exception.
    /// </summary>
    public class DependyNotRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependyNotRegisteredException"/> class.
        /// </summary>
        public DependyNotRegisteredException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependyNotRegisteredException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public DependyNotRegisteredException(string message)
            : base(message)
        {
        }
    }
}
