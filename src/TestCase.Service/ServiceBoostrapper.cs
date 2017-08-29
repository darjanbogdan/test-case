using AutoMapper;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Core.Query;
using TestCase.Core.Validation;
using TestCase.Service.Auth.Aspects;
using TestCase.Service.Infrastructure.Lookups.Contracts;
using TestCase.Service.Security;
using TestCase.Service.Security.Contracts;
using TestCase.Service.Validation.Aspects;

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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.GetName().Name.StartsWith("TestCase")).ToArray();

            RegisterMapper(container, assemblies);

            RegisterLookups(container, assemblies);
            RegisterValidators(container, assemblies);
            RegisterSecurityEvaluators(container, assemblies);

            RegisterCommandHandlerPipeline(container, assemblies);
            RegisterQueryHandlerPipeline(container, assemblies);
        }

        private static void RegisterSecurityEvaluators(Container container, Assembly[] assemblies)
        {
            container.Register<IGroupPermissionEvaluator, GroupPermissionEvaluator>();
            container.Register(typeof(IObjectPermissionEvaluator<>), assemblies);
            container.RegisterConditional(typeof(IObjectPermissionEvaluator<>), typeof(NullObjectPermissionEvaluator<>), c => !c.Handled);
        }

        private static void RegisterValidators(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(IModelValidator<>), assemblies);
        }

        private static void RegisterLookups(Container container, Assembly[] assemblies)
        {
            var assemblyTypes = assemblies.SelectMany(asm => asm.GetTypes());
            var lookupTypes = assemblyTypes.Where(type => 
                !type.IsAbstract 
                && !type.IsInterface
                && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ILookup<>))
            );

            foreach (var lookupType in lookupTypes)
            {
                //Each lookup type implements only one specific non-generic interface
                var lookupInterface = lookupType.GetInterfaces().FirstOrDefault(i => !i.IsGenericType);
                if (lookupInterface != null)
                {
                    container.Register(lookupInterface, lookupType);
                }
            }
        }

        private static void RegisterMapper(Container container, Assembly[] assemblies)
        {
            var profileTypes = assemblies.SelectMany(asm => asm.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x)));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                
                foreach (var profileType in profileTypes)
                {
                    cfg.AddProfile(Activator.CreateInstance(profileType) as Profile);
                }
            });
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
        }

        private static void RegisterCommandHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(ICommandHandler<>), assemblies);

            // Validation
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            
            //Auth
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthorizationCommandHandlerDecorator<>));
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthenticationCommandHandlerDecorator<>));
        }

        private static void RegisterQueryHandlerPipeline(Container container, Assembly[] assemblies)
        {
            container.Register(typeof(IQueryHandler<,>), assemblies);

            //Validation
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));

            //Auth
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthorizationQueryHandlerDecorator<,>));
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthenticationQueryHandlerDecorator<,>));
        }
    }
}
