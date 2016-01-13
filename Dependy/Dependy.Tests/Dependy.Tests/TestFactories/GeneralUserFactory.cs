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
    using System;

    using Dependy.Tests.TestClasses;
    using Dependy.Tests.TestInterfaces;

    /// <summary>
    /// The general user factory.
    /// </summary>
    public class GeneralUserFactory : IUserFactory
    {
        /// <summary>
        /// The user service stub.
        /// </summary>
        private readonly IUserServiceStub userServiceStub;

        /// <summary>
        /// The help service stub.
        /// </summary>
        private readonly IHelpServiceStub helpServiceStub;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralUserFactory"/> class.
        /// </summary>
        /// <param name="userServiceStub">
        /// The user service stub.
        /// </param>
        /// <param name="helpServiceStub">
        /// The help service stub.
        /// </param>
        public GeneralUserFactory(IUserServiceStub userServiceStub, IHelpServiceStub helpServiceStub)
        {
            this.userServiceStub = userServiceStub;
            this.helpServiceStub = helpServiceStub;
            this.FactoryGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the factory guid.
        /// </summary>
        public Guid FactoryGuid { get; private set; }

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
