using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TestCase.WebApi.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Dependency injection container factory.
    /// </summary>
    public class DependencyInjectionContainerFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static Container Create()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            AllowResolvingFuncFactories(container.Options);
            return container;
        }

        private static void AllowResolvingFuncFactories(ContainerOptions options)
        {
            options.Container.ResolveUnregisteredType += (s, e) => {
                var type = e.UnregisteredServiceType;

                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Func<>))
                {
                    return;
                }

                Type serviceType = type.GetGenericArguments().First();

                InstanceProducer registration =
                    options.Container.GetRegistration(serviceType, true);

                Type funcType = typeof(Func<>).MakeGenericType(serviceType);

                var factoryDelegate = Expression.Lambda(funcType,
                    registration.BuildExpression()).Compile();

                e.Register(Expression.Constant(factoryDelegate));
            };
        }
    }
}