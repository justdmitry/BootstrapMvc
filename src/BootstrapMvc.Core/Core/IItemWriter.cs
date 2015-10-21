namespace BootstrapMvc.Core
{
    using System;

    public interface IItemWriter
    {
        IWritableItem Item { get; }

        IWritingHelper Helper { get; }
    }
}
