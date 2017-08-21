using System.Text;
using Blocker.Exceptions;

namespace Blocker
{
    public class StringBlock : Block
    {
        private Configuration configuration;
        public StringBlock(Configuration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        public void SetKey(string key)
        {
            var byteKey = Encoding.UTF8.GetBytes(key);
            if (byteKey.Length > configuration.KeySize)
            {
                throw new IncorrectKeyException("Key is too big");
            }
            byteKey.CopyTo(Key, 0);
        }

        public void Set(string key, string data)
        {
            var byteKey = Encoding.UTF8.GetBytes(key);
            var byteData = Encoding.UTF8.GetBytes(data);

            if (byteKey.Length > configuration.KeySize)
            {
                throw new IncorrectKeyException("Key is too big");
            }

            if (byteData.Length > configuration.DataSize)
            {
                throw new IncorrectKeyException("Data is too big");
            }

            byteKey.CopyTo(Key, 0);
            byteData.CopyTo(Data, 0);
        }

        public string GetKey()
        {
            return Encoding.UTF8.GetString(Key);
        }

        public string GetData()
        {
            return Encoding.UTF8.GetString(Data);
        }
    }
}
