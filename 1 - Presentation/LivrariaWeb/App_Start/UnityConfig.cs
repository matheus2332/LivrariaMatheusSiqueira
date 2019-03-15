using DependencyInjection;
using LivrariaWeb.Mapper;
using Microsoft.Practices.Unity;
using System;
using Unity;

namespace LivrariaWeb
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        private static Lazy<Microsoft.Practices.Unity.IUnityContainer> container =
          new Lazy<Microsoft.Practices.Unity.IUnityContainer>(() =>
          {
              var container = new Microsoft.Practices.Unity.UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static Microsoft.Practices.Unity.IUnityContainer Container => container.Value;

        public static Microsoft.Practices.Unity.IUnityContainer GetConfiguredContainer()
        {
            return Container;
        }

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(Microsoft.Practices.Unity.IUnityContainer container)
        {
            Registration.Register(container);

            var mapper = AutoMapperRegister.RegisterServices(container).CreateMapper();
            container.RegisterInstance(mapper);
        }
    }
}