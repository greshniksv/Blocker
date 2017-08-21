using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blocker.Enums;

namespace Blocker
{
    public class Configuration
    {
        public long BlockCount { get; set; }
        public IndexType IndexType { get; set; }
        public int KeySize { get; set; }
        public int DataSize { get; set; }
    }
}
