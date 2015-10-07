using System;

namespace BootstrapMvc.Core
{
    public interface IWriter2<TItem, TContent> : IWriter<TItem>
        where TItem : ContentElement<TContent>
        where TContent : DisposableContent
    {
        TContent BeginContent();

        TContent BeginContent(System.IO.TextWriter writer);
    }
}
