using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Caching
{
    /// <summary>
    /// Cache model interface.
    /// </summary>
    public interface ICacheModel
    {
        /// <summary>
        /// Gets the cache key.
        /// </summary>
        string CacheKey { get; }
    }
}
