namespace BootstrapMvc.Mvc6
{
    using System;
    using System.IO;
    using Microsoft.AspNet.Html.Abstractions;
    using Microsoft.Framework.WebEncoders;
    using BootstrapMvc.Core;

    public class ItemWriter<TItem> : IItemWriter<TItem>, IHtmlContent
        where TItem : IWritableItem
    {
        public TItem Item { get; private set; }

        public IWritingHelper Helper { get; set; }

        IWritableItem IItemWriter.Item
        {
            get
            {
                return this.Item;
            }
        }

        public ItemWriter(TItem item)
        {
            Item = item;
            Helper = item.Helper;
        }

        public void WriteTo(TextWriter writer)
        {
            Item.WriteTo(writer);
        }

        public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
        {
            Item.WriteTo(writer);
        }
    }
}
