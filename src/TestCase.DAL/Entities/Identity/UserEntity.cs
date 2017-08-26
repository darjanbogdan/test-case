using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DAL.Entities.Identity
{
    /// <summary>
    /// User entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.Guid, TestCase.DAL.Entities.Identity.UserLoginEntity, TestCase.DAL.Entities.Identity.UserRoleEntity, TestCase.DAL.Entities.Identity.UserClaimEntity}" />
    public class UserEntity : IdentityUser<Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
    }
}
