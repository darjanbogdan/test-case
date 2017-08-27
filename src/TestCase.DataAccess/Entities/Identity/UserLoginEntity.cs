using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Identity
{
    /// <summary>
    /// User login entity.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin{System.Guid}" />
    public class UserLoginEntity : IdentityUserLogin<Guid>
    {
    }
}
