// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependyContainer.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The dependy container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Dependy.Enumerations;
    using Dependy.Exceptions;
    using Dependy.Interfaces;
    using Dependy.Objects;
    using Dependy.Resources;

    /// <summary>
    /// The dependy container.
    /// </summary>
    public class DependyContainer : IDependyContainer
    {
        /// <summary>
        /// The registrations.
        /// </summary>
        private readonly List<IRegistration> registrations;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependyContainer"/> class.
        /// </summary>
        public DependyContainer()
        {
            this.registrations = new List<IRegistration>();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <typeparam name="TDependency">
        /// The dependency type
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// The resolution type
        /// </typeparam>
        public void Add<TDependency, TResolve>() where TResolve : class, TDependency
        {
            this.registrations.Add(new TransientRegistration<TResolve> { Dependency = typeof(TDependency), ResolveType = typeof(TResolve) });
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="lifecyle">
        /// The lifecyle.
        /// </param>
        /// <typeparam name="TDependency">
        /// The dependency type
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// The resolution type
        /// </typeparam>
        public void Add<TDependency, TResolve>(Lifecycle lifecyle) where TResolve : class, TDependency
        {
            if (lifecyle == Lifecycle.Transient)
            {
                this.Add<TDependency, TResolve>();
            }
            else
            {
                this.registrations.Add(new SingletonRegistration<TResolve> { Dependency = typeof(TDependency), ResolveType = typeof(TResolve) });
            }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="dependencyInjector">
        /// The dependency injector.
        /// </param>
        /// <typeparam name="TDependency">
        /// The dependency type.
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// The resolution type.
        /// </typeparam>
        public void Add<TDependency, TResolve>(Injector dependencyInjector) where TResolve : class, TDependency
        {
            this.registrations.Add(new TransientRegistration<TResolve>
                                       {
                                           Dependency = typeof(TDependency), 
                                           ResolveType = typeof(TResolve), 
                                           DependencyInjector = dependencyInjector
                                       });
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="dependencyInjector">
        /// The dependency injector.
        /// </param>
        /// <param name="lifecycle">
        /// The lifecycle.
        /// </param>
        /// <typeparam name="TDependency">
        /// The dependency type.
        /// </typeparam>
        /// <typeparam name="TResolve">
        /// The resolution type.
        /// </typeparam>
        public void Add<TDependency, TResolve>(Injector dependencyInjector, Lifecycle lifecycle) where TResolve : class, TDependency
        {
            if (lifecycle == Lifecycle.Transient)
            {
                this.Add<TDependency, TResolve>(dependencyInjector);
            }
            else
            {
                this.registrations.Add(
                    new SingletonRegistration<TResolve>
                        {
                            Dependency = typeof(TDependency),
                            ResolveType = typeof(TResolve),
                            DependencyInjector = dependencyInjector
                        });
            }
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <typeparam name="TDependency">
        /// The dependency type
        /// </typeparam>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public TDependency Get<TDependency>()
        {
            var typeRegistration = this.GetTypeRegistration(typeof(TDependency));
            return (TDependency)typeRegistration.GetInstance(this.RetrieveRegisteredDependencies(typeRegistration));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="dependencyType">
        /// The dependency type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="DependyNotRegisteredException">
        /// Not registered exception;
        /// </exception>
        public object Get(Type dependencyType)
        {
            var typeRegistration = this.GetTypeRegistration(dependencyType);
            return typeRegistration.GetInstance(this.RetrieveRegisteredDependencies(typeRegistration));
        }

        /// <summary>
        /// The retrieve registered dependencies.
        /// </summary>
        /// <param name="typeRegistration">
        /// The type Registration.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private object[] RetrieveRegisteredDependencies(IRegistration typeRegistration)
        {
            var parameters = new List<object>();
            if (typeRegistration.DependencyInjector != null)
            {
                parameters.AddRange(typeRegistration.DependencyInjector.DependencyParameters);
            }
            else
            {
                var constructorInfo = typeRegistration.ResolveType.GetConstructors();
                if (constructorInfo.Length > 0)
                {
                    parameters.AddRange(constructorInfo[0].GetParameters()
                        .Select(param => this.Get(param.ParameterType)));
                }

            }

            return parameters.ToArray();
        }

        /// <summary>
        /// The get type registration.
        /// </summary>
        /// <param name="dependencyType">
        /// The dependency type.
        /// </param>
        /// <returns>
        /// The <see cref="IRegistration"/>.
        /// </returns>
        /// <exception cref="DependyNotRegisteredException">
        /// The dependency not registrered exception.
        /// </exception>
        private IRegistration GetTypeRegistration(Type dependencyType)
        {
            var typeRegistration = this.registrations.FirstOrDefault(r => r.Dependency == dependencyType);
            if (typeRegistration == null)
            {
                throw new DependyNotRegisteredException(string.Format(ExceptionMessages.NotRegistered, dependencyType.Name));
            }

            return typeRegistration;
        }
    }
}
