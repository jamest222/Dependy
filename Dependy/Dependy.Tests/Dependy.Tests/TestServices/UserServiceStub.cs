// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserServiceStub.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The user service stub.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestServices
{
    using Dependy.Tests.TestInterfaces;

    /// <summary>
    /// The user service stub.
    /// </summary>
    public class UserServiceStub : IUserServiceStub
    {
        public UserServiceStub()
        {
        }

        /// <summary>
        /// The get service name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetServiceName()
        {
            return "UserService";
        }
    }
}
