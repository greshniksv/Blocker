using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocker
{
    public class Blocker
    {
        private byte[] Data;
        private Configuration configuration;

        public Blocker(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public Blocker(Configuration configuration, IEnumerable<Block> blocks)
        {
            this.configuration = configuration;
        }

        public void Add(Block block)
        {
            block.Validate(configuration);

        }

        public void Change(Block block)
        {
            block.Validate(configuration);

        }

        public void Find(Block block)
        {
            block.Validate(configuration);

        }

        public T CreateBlock<T>()  where T:Block
        {
            return (T)Activator.CreateInstance(typeof(T), configuration);
        }
    }
}
