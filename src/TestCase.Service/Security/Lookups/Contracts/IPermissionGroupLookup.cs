using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;
using TestCase.Service.Infrastructure.Lookups.Contracts;

namespace TestCase.Service.Security.Lookups.Contracts
{
    /// <summary>
    /// Permission group lookup interface.
    /// </summary>
    /// <seealso cref="TestCase.Service.Infrastructure.Lookups.Contracts.ILookup{TestCase.Model.Security.PermissionGroup}" />
    public interface IPermissionGroupLookup : ILookup<PermissionGroup>
    {
    }
}
