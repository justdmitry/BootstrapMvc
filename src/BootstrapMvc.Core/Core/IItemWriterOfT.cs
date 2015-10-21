namespace BootstrapMvc.Core
{
    using System;

    public interface IItemWriter<TItem> : IItemWriter
        where TItem : IWritableItem
    {
        new TItem Item { get; }
    }
}
