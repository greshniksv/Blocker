using System;

namespace Blocker.Interfaces
{
    public interface IIndexator : IDisposable
    {
        Block this[int index] { get; set; }
    }
}
