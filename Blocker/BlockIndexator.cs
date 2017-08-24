using System.IO;
using Blocker.Interfaces;

namespace Blocker
{
    public class BlockIndexator : IIndexator
    {
        private readonly Configuration _configuration;
        private readonly byte[] _data;
        private readonly long _blockSize;
        private readonly MemoryStream _stream;

        public BlockIndexator(Configuration configuration)
        {
            _configuration = configuration;
            _blockSize = configuration.KeySize + configuration.DataSize;
            var dataSize = configuration.BlockCount * _blockSize;
            _data = new byte[dataSize];
            _stream = new MemoryStream(_data, true);
        }

        public long Length => _configuration.BlockCount;

        public Block this[int index]
        {
            get { return GetBlock(index); }
            set { SetBlock(index, value); }
        }

        private Block GetBlock(int index)
        {
            var keySize = _configuration.KeySize;
            var dataSize = _configuration.DataSize;
            _stream.Position = index * _blockSize;

            var key = new byte[keySize];
            _stream.Read(key, 0, keySize);

            var data = new byte[dataSize];
            _stream.Read(data, 0, dataSize);

            return new Block(_configuration)
            {
                Key = key,
                Data = data
            };
        }

        private void SetBlock(int index, Block block)
        {
            block.Validate();

            var keySize = _configuration.KeySize;
            var dataSize = _configuration.DataSize;
            _stream.Position = index * _blockSize;
            _stream.Write(block.Key, 0, keySize);
            _stream.Write(block.Data, 0, dataSize);
        }

        public void Dispose()
        {
            _stream?.Dispose();
        }
    }
}
