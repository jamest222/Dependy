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
    using Dependy.Enumerations;
    using Dependy.Exceptions;
    using Dependy.Objects;
    using Dependy.Tests.TestFactories;
    using Dependy.Tests.TestInterfaces;
    using Dependy.Tests.TestServices;

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
        /// The dependy container should be able to register and resolve dynamically.
        /// </summary>
        [Test]
        public void DependyContainerShouldBeAbleToAddAndGetAdminUserFactoryDynamically()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, AdminUserFactory>();

            // Act.
            var result = dependyContainer.Get(typeof(IUserFactory));

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

        /// <summary>
        /// The dependy container should support transient lifecycle.
        /// </summary>
        [Test]
        public void DependyContainerShouldSupportTransientLifecycle()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, AdminUserFactory>(Lifecycle.Transient);

            // Act.
            var factoryOne = (AdminUserFactory)dependyContainer.Get<IUserFactory>();
            var factoryTwo = (AdminUserFactory)dependyContainer.Get<IUserFactory>();
            
            // Assert.
            Assert.AreNotEqual(factoryOne.FactoryGuid, factoryTwo.FactoryGuid);
        }

        /// <summary>
        /// The dependy container should support singleton lifecycle.
        /// </summary>
        [Test]
        public void DependyContainerShouldSupportSingletonLifecycle()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, AdminUserFactory>(Lifecycle.Singleton);

            // Act.
            var factoryOne = (AdminUserFactory)dependyContainer.Get<IUserFactory>();
            var factoryTwo = (AdminUserFactory)dependyContainer.Get<IUserFactory>();

            // Assert.
            Assert.AreEqual(factoryOne.FactoryGuid, factoryTwo.FactoryGuid);
        }

        /// <summary>
        /// The dependy container should support parameter constructors automatically.
        /// </summary>
        [Test]
        public void DependyContainerShouldSupportParameterConstructorsAutomatically()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IHelpServiceStub, HelpServiceStub>();
            dependyContainer.Add<IUserServiceStub, UserServiceStub>();
            dependyContainer.Add<IUserFactory, GeneralUserFactory>();

            // Act.
            var result = dependyContainer.Get<IUserFactory>();

            // Assert.
            Assert.IsInstanceOf<GeneralUserFactory>(result);
        }

        /// <summary>
        /// The dependy container should throw dependy not registered exception if dependency not found.
        /// </summary>
        [Test]
        [ExpectedException(typeof(DependyNotRegisteredException))]
        public void DependyContainerShouldThrowDependyNotRegisteredExceptionIfDependencyNotFound()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserServiceStub, UserServiceStub>();
            dependyContainer.Add<IUserFactory, GeneralUserFactory>();

            // Act.
            dependyContainer.Get<IUserFactory>();
        }

        /// <summary>
        /// The dependy container should accept injector to resolve dependencies.
        /// </summary>
        [Test]
        public void DependyContainerShouldAcceptInjectorToResolveDependencies()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, GeneralUserFactory>(new Injector(new UserServiceStub(), new HelpServiceStub()));

            // Act.
            var result = dependyContainer.Get<IUserFactory>();

            // Assert.
            Assert.IsInstanceOf<GeneralUserFactory>(result);
        }

        /// <summary>
        /// The dependy container should accept injector to resolve dependencies.
        /// </summary>
        [Test]
        public void DependyContainerShouldAcceptInjectorToResolveDependenciesAndSpecifyLifecycle()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, GeneralUserFactory>(new Injector(new UserServiceStub(), new HelpServiceStub()), Lifecycle.Singleton);

            // Act.
            var result = dependyContainer.Get<IUserFactory>();
            var result2 = dependyContainer.Get<IUserFactory>();
            var castedResult = (GeneralUserFactory)result;
            var castedResult2 = (GeneralUserFactory)result2;

            // Assert.
            Assert.IsInstanceOf<GeneralUserFactory>(result);
            Assert.AreEqual(castedResult.FactoryGuid, castedResult2.FactoryGuid);
        }

        /// <summary>
        /// The dependy container should accept injector to resolve dependencies.
        /// </summary>
        [Test]
        public void DependyContainerShouldAcceptInjectorToResolveDependenciesAndSpecifyTransientLifecycle()
        {
            // Arrange.
            var dependyContainer = new DependyContainer();
            dependyContainer.Add<IUserFactory, GeneralUserFactory>(new Injector(new UserServiceStub(), new HelpServiceStub()), Lifecycle.Transient);

            // Act.
            var result = dependyContainer.Get<IUserFactory>();
            var result2 = dependyContainer.Get<IUserFactory>();
            var castedResult = (GeneralUserFactory)result;
            var castedResult2 = (GeneralUserFactory)result2;

            // Assert.
            Assert.IsInstanceOf<GeneralUserFactory>(result);
            Assert.AreNotEqual(castedResult.FactoryGuid, castedResult2.FactoryGuid);
        }
    }
}
