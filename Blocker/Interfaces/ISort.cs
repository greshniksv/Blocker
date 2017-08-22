using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocker.Interfaces
{
    public abstract class Sort
    {
        public delegate void Progress(byte persent);

        public event Progress ProgressEventHandler;

        protected virtual void OnProgressEventHandler(byte persent)
        {
            ProgressEventHandler?.Invoke(persent);
        }

        public abstract void Apply(byte[] data);
    }
}
