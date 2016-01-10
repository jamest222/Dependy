// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependyContainerTests.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   Defines the DependyTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests
{
    using Dependy.Exceptions;
    using Dependy.Tests.TestFactories;
    using Dependy.Tests.TestInterfaces;

    using NUnit.Framework;

    /// <summary>
    /// The dependy tests.
    /// </summary>
    [TestFixture]
    public class DependyContainerTests
    {
        /// <summary>
        /// The dependy container should be able to register and resolve.
        /// </summary>
        [Test]
        public void DependyContainerShouldBeAbleToAddAndGetAdminUserFactory()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, AdminUserFactory>();

            // Act.
            var result = dependyContainer.Get<IUserFactory>();

            // Assert.
            Assert.IsInstanceOf<AdminUserFactory>(result);
        }

        /// <summary>
        /// The dependy container should throw exception when no dependency registration is found.
        /// </summary>
        [Test]
        [ExpectedException(typeof(DependyNotRegisteredException))]
        public void DependyContainerShouldThrowExceptionWhenNoDependencyRegistrationIsFound()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();

            // Act.
            var result = dependyContainer.Get<IUserFactory>();
        }
    }
}
