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
    /// Permission lookup interface.
    /// </summary>
    /// <seealso cref="TestCase.Service.Infrastructure.Lookups.Contracts.ILookup{TestCase.Model.Security.Permission}" />
    public interface IPermissionLookup : ILookup<Permission>
    {
    }
}
