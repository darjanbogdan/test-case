using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Core.Query;

namespace TestCase.Service
{
    /// <summary>
    /// Service boostrapper.
    /// </summary>
    public class ServiceBoostrapper
    {
        /// <summary>
        /// Bootstraps the service layer.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Bootstrap(Container container)
        {
            var applicationAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.GetName().Name.StartsWith("TestCase")).ToArray();

            RegisterCommandHandlerPipeline(container, applicationAssemblies);
            RegisterQueryHandlerPipeline(container, applicationAssemblies);
        }

        private static void RegisterCommandHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(ICommandHandler<>), assemblies);
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthorizationCommandHandlerDecorator<>));
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthenticationCommandHandlerDecorator<>));
        }

        private static void RegisterQueryHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(IQueryHandler<,>), assemblies);
            //container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));
            //container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthorizationQueryHandlerDecorator<,>));
            //container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthenticationQueryHandlerDecorator<,>));
        }
    }
}
