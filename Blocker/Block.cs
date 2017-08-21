using Blocker.Exceptions;

namespace Blocker
{
    public abstract class Block
    {
        internal Configuration configuration;
        public byte[] Key { get; set; }
        public byte[] Data { get; set; }

        internal Block(Configuration configuration)
        {
            Key = new byte[configuration.KeySize];
            Data = new byte[configuration.DataSize];
            this.configuration = configuration;
        }

        public void Validate(Configuration config)
        {
            if (Key.Length != config.KeySize)
            {
                throw new IncorrectKeyException("Incorrect size");
            }

            if (Data.Length == config.DataSize)
            {
                throw new IncorrectDataException("Incorrect size");
            }
        }
    }
}
