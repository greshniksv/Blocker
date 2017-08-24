using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blocker.Enums;

namespace Blocker
{
    public class Blocker<T> : IEnumerable<T> where T:Block
    {
        private readonly BlockIndexator _indexator;
        private readonly Configuration _configuration;

        public Blocker(Configuration configuration)
        {
            this._configuration = configuration;
            _indexator = new BlockIndexator(configuration);
        }

        public long Length => _configuration.BlockCount;

        public T this[int index]
        {
            get
            {
                var i = (T)Activator.CreateInstance(typeof(T), _configuration);
                i.Parce(_indexator[index]);
                return i;
            }
            set { _indexator[index] = value; }
        }

        public T Find(T block)
        {
            if (_configuration.IndexType == IndexType.None)
            {
                for (int i = 0; i < _indexator.Length; i++)
                {
                    if (_indexator[i].Key.SequenceEqual(block.Key))
                    {
                        var instance = (T)Activator.CreateInstance(typeof(T), _configuration);
                        instance.Parce(_indexator[i]);
                        return instance;
                    }
                }
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _configuration.BlockCount; i++)
            {
                var instance = (T)Activator.CreateInstance(typeof(T), _configuration);
                instance.Parce(_indexator[i]);
                yield return instance;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetEmptyBlock()
        {
            return (T)Activator.CreateInstance(typeof(T), _configuration);
        }
    }
}
