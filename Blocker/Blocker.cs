using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocker
{
    public class Blocker<T> where T:Block 
    {
        private byte[] _data;
        private readonly Configuration _configuration;

        public Blocker(Configuration configuration)
        {
            this._configuration = configuration;
            var dataSize = configuration.BlockCount * (configuration.KeySize + configuration.DataSize);
            _data = new byte[dataSize];
        }

        public void Add(IEnumerable<T> blocks)
        {
            foreach (var block in blocks)
            {
                Add(block);
            }
        }

        public void Add(T block)
        {
            block.Validate(_configuration);

        }

        public void Change(T block)
        {
            block.Validate(_configuration);

        }

        public void Remove(T block)
        {
            block.Validate(_configuration);

        }

        public void Find(T block)
        {
            block.Validate(_configuration);

        }

        public T CreateBlockInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), _configuration);
        }
    }
}
