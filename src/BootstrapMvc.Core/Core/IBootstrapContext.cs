namespace BootstrapMvc.Core
{
    using System;

    public interface IBootstrapContext
    {
        IWritableItem GetCurrentParent();

        void PushParent(IWritableItem parent);

        void PopParent(IWritableItem parentToMatch);

        IWritingHelper Helper { get; }
    }
}
