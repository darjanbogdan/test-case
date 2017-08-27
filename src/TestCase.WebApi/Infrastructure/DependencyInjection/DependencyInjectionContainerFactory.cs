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
            container.Options.AllowResolvingFuncFactories();
            return container;
        }
    }
}