// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserFactory.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   Defines the ITestUserFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestInterfaces
{
    using Dependy.Tests.TestClasses;

    /// <summary>
    /// The TestUserFactory interface.
    /// </summary>
    public interface IUserFactory
    {
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
        User GetNewUser(string firstName, string lastName);
    }
}
