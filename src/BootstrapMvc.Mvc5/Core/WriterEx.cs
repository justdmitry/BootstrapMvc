using System;

namespace BootstrapMvc.Core
{
    public class WriterEx<TItem, TContent> : Writer<TItem>, IWriter2<TItem, TContent>
        where TItem : ContentElement<TContent>
        where TContent : DisposableContent
    {
        public TContent BeginContent()
        {
            return Item.BeginContent(Context);
        }
    }
}
