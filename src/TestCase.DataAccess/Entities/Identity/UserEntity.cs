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
    /// User entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.Guid, TestCase.DataAccess.Entities.Identity.UserLoginEntity, TestCase.DataAccess.Entities.Identity.UserRoleEntity, TestCase.DataAccess.Entities.Identity.UserClaimEntity}" />
    public class UserEntity : IdentityUser<Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
    }
}
