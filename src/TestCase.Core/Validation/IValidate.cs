using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Validation
{
    /// <summary>
    /// Validate model interface.
    /// </summary>
    public interface IValidate
    {
        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string ModelName { get; }
    }
}
