using System;

namespace BootstrapMvc.Core
{
    public interface IWriter<TItem> : IWritable where TItem : IWritable
    {
        TItem Item { get; set; }

        IBootstrapContext Context { get; set; }
    }
}
