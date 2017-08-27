using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Context
{
    /// <summary>
    /// Execution context contract.
    /// </summary>
    public interface IExecutionContext
    {
        /// <summary>
        /// Gets the user information.
        /// </summary>
        IUserInfo UserInfo { get; }
    }
}
