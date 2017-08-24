using Blocker.Exceptions;

namespace Blocker
{
    public class Block : BaseBlock
    {
        internal readonly Configuration Configuration;

        internal Block(Configuration configuration)
        {
            if (configuration == null)
            {
                return;
            }

            Key = new byte[configuration.KeySize];
            Data = new byte[configuration.DataSize];
            this.Configuration = configuration;
        }

        public void Validate()
        {
            if (Key.Length != Configuration.KeySize)
            {
                throw new IncorrectKeyException("Incorrect size");
            }

            if (Data.Length != Configuration.DataSize)
            {
                throw new IncorrectDataException("Incorrect size");
            }
        }
    }
}
