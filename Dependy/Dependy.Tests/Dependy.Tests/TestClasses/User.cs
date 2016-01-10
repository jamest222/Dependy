// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestClasses
{
    /// <summary>
    /// The user.
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
