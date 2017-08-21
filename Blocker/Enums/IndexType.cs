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
        /// <summary>
        /// User should add pre-sorted items by key.
        /// </summary>
        Internal,

        /// <summary>
        /// Index will create by program.
        /// </summary>
        External
    }
}
