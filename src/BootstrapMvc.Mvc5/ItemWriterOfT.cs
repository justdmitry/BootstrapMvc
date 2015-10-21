namespace BootstrapMvc.Mvc5
{
    using System;
    using System.IO;
    using System.Web;
    using BootstrapMvc.Core;

    public class ItemWriter<TItem> : IItemWriter<TItem>, IHtmlString
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
            if (Item != null)
            {
                Item.WriteTo(writer);
            }
        }

        public string ToHtmlString()
        {
            using (var sw = new StringWriter())
            {
                Item.WriteTo(sw);
                return sw.ToString();
            }
        }
    }
}
