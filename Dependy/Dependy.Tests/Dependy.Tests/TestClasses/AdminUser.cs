// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminUser.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The admin user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestClasses
{
    /// <summary>
    /// The admin user.
    /// </summary>
    public class AdminUser : User
    {
        /// <summary>
        /// Gets or sets a value indicating whether can delete user.
        /// </summary>
        public bool CanDeleteUser { get; set; }
    }
}
