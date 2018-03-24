namespace BootstrapMvc.Core
{
    using System;

    public interface IWritableItem : IWritable
    {
        IWritableItem Parent { get; set; }

        T GetNearestParent<T>() where T : class, IWritableItem;

        T GetNearestParent<T, TStop>()
            where T : class, IWritableItem
            where TStop : class, IWritableItem;

        IWritingHelper Helper { get; set; }
    }
}
