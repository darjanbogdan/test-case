using Microsoft.AspNet.Identity;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Repository.Identity.Managers;
using TestCase.Repository.Identity.Claims;
using TestCase.Repository.Identity.Claims.Contracts;
using TestCase.Repository.Identity.Security;
using TestCase.Repository.Identity.Security.Contracts;
using TestCase.Repository.Membership;
using TestCase.Repository.Membership.Contracts;
using TestCase.Repository.Security.Contracts;
using TestCase.Repository.Security;

namespace TestCase.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryBootstrapper
    {
        /// <summary>
        /// Bootstraps the repository layer.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Bootstrap(Container container)
        {
            RegisterIdentity(container);

            RegisterRepositories(container);
        }

        private static void RegisterIdentity(Container container)
        {
            container.Register<IPasswordHasher, DefaultPasswordHasher>(Lifestyle.Scoped);
            container.Register<IIdentityValidator<string>, DefaultPasswordValidator>(Lifestyle.Scoped);
            container.Register<IIdentityUserValidatorFactory, DefaultUserValidatorFactory>(Lifestyle.Scoped);

            container.Register<UserManager<UserEntity, Guid>, TestCaseUserManager>(Lifestyle.Scoped);
            container.Register<RoleManager<RoleEntity, Guid>, TestCaseRoleManager>(Lifestyle.Scoped);

            container.Register<IClaimsIdentityProvider, ClaimsIdentityProvider>();
        }

        private static void RegisterRepositories(Container container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IRoleRepository, RoleRepository>();

            container.Register<IPermissionRepository, PermissionRepository>();
            container.Register<IPermissionGroupRepository, PermissionGroupRepository>();
            container.Register<IPermissionPolicyRepository, PermissionPolicyRepository>();
        }
    }
}
