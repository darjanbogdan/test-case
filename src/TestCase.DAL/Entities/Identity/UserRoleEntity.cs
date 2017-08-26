using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DAL.Entities.Identity
{
    /// <summary>
    /// User role entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{System.Guid}" />
    public class UserRoleEntity : IdentityUserRole<Guid>
    {
    }
}
