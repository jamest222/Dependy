// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneralUserFactory.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The general user factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestFactories
{
    using Dependy.Tests.TestClasses;
    using Dependy.Tests.TestInterfaces;

    /// <summary>
    /// The general user factory.
    /// </summary>
    public class GeneralUserFactory : IUserFactory
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
        public User GetNewUser(string firstName, string lastName)
        {
            return new GeneralUser
                       {
                           FirstName = firstName,
                           LastName = lastName,
                           LoginCount = 200
                       };
        }
    }
}
