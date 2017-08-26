using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DAL.Entities.Identity
{
    /// <summary>
    /// Role entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityRole{System.Guid, TestCase.DAL.Entities.Identity.UserRoleEntity}" />
    public class RoleEntity : IdentityRole<Guid, UserRoleEntity>
    {
    }
}
