namespace BootstrapMvc.Core
{
    using System;

    public interface IWritableItem : IWritable
    {
        IWritableItem Parent { get; set; }

        T GetNearestParent<T>() where T : class, IWritableItem;

        IWritingHelper Helper { get; set; }
    }
}
