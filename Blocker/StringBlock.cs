using System;
using System.Text;
using Blocker.Exceptions;

namespace Blocker
{
    public class StringBlock : Block
    {
        public StringBlock(Configuration configuration) : base(configuration)
        {
        }

        public StringBlock(Configuration configuration, string key): base(configuration)
        {
            Key = key;
        }
        
        public new string Key {
            get { return Encoding.UTF8.GetString(base.Key); }
            set
            {
                var byteKey = Encoding.UTF8.GetBytes(value);
                if (byteKey.Length > Configuration.KeySize)
                {
                    throw new IncorrectKeyException("Key is too big");
                }
                byteKey.CopyTo(base.Key, 0);
                Array.Clear(base.Key, byteKey.Length, base.Key.Length - byteKey.Length);
            }
        }

        public new string Data
        {
            get { return Encoding.UTF8.GetString(base.Data); }
            set
            {
                var byteData = Encoding.UTF8.GetBytes(value);
                if (byteData.Length > Configuration.DataSize)
                {
                    throw new IncorrectKeyException("Data is too big");
                }
                byteData.CopyTo(base.Data, 0);
                Array.Clear(base.Data, byteData.Length, base.Data.Length - byteData.Length);
            }
        }
    }
}
