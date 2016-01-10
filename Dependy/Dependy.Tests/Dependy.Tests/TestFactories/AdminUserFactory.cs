// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminUserFactory.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The admin user factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestFactories
{
    using System;

    using Dependy.Tests.TestClasses;
    using Dependy.Tests.TestInterfaces;

    /// <summary>
    /// The admin user factory.
    /// </summary>
    public class AdminUserFactory : IUserFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminUserFactory"/> class.
        /// </summary>
        public AdminUserFactory()
        {
            this.FactoryGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the factory guid.
        /// </summary>
        public Guid FactoryGuid { get; set; }

        /// <summary>
        /// The get new user.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User GetNewUser(string firstName, string lastName)
        {
            return new AdminUser
                       {
                           FirstName = firstName,
                           LastName = lastName,
                           CanDeleteUser = true
                       };
        }
    }
}
