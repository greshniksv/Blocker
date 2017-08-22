using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocker.Enums
{
    /// <summary>
    /// Index types
    /// </summary>
    public enum IndexType
    {
        None,

        /// <summary>
        /// Sorting use internal sorting method.
        /// </summary>
        Internal,

        /// <summary>
        /// Sorting use external method.
        /// </summary>
        External
    }
}
