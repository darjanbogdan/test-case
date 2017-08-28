using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;

namespace TestCase.Repository.Identity.Managers
{
    public class TestCaseRoleManager : RoleManager<RoleEntity, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseRoleManager"/> class.
        /// </summary>
        /// <param name="store">The IRoleStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods</param>
        public TestCaseRoleManager(IRoleStore<RoleEntity, Guid> store) 
            : base(store)
        {
        }
    }
}
