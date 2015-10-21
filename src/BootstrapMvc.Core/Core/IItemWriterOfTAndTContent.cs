namespace BootstrapMvc.Core
{
    using System;

    public interface IItemWriter<TItem, TContent> : IItemWriter<TItem>
        where TItem : ContentElement<TContent>, IWritableItem
        where TContent : DisposableContent
    {
        TContent BeginContent();

        TContent BeginContent(System.IO.TextWriter writer);
    }
}
