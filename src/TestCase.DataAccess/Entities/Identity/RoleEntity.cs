using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess.Entities.Identity
{
    /// <summary>
    /// Role entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityRole{System.Guid, TestCase.DataAccess.Entities.Identity.UserRoleEntity}" />
    public class RoleEntity : IdentityRole<Guid, UserRoleEntity>
    {
    }
}
