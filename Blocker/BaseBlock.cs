namespace Blocker
{
    public abstract class BaseBlock
    {
        public byte[] Key { get; set; }
        public byte[] Data { get; set; }

        public void Parce(BaseBlock block)
        {
            Key = block.Key;
            Data = block.Data;
        }
    }
}
