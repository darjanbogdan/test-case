using Microsoft.AspNet.Identity;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Context;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Identity;
using TestCase.DataAccess.Identity.Stores;

namespace TestCase.DataAccess
{
    /// <summary>
    /// Data access bootstrapper.
    /// </summary>
    public class DataAccessBootstrapper
    {
        /// <summary>
        /// Bootstraps the data access layer.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Bootstrap(Container container)
        {
            container.Register<DbContext>(() => new TestCaseDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString), Lifestyle.Scoped);

            container.Register<IUserStore<UserEntity, Guid>, TestCaseUserStore>(Lifestyle.Scoped);
            container.Register<IRoleStore<RoleEntity, Guid>, TestCaseRoleStore>(Lifestyle.Scoped);

            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
