using System;
using System.IO;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.Framework.WebEncoders;
using BootstrapMvc.Core;

namespace BootstrapMvc.Mvc6
{
    public class Writer<TItem> : IWriter<TItem>, IHtmlContent
        where TItem : IWritable
    {
        public TItem Item { get; set; }

        public IBootstrapContext Context { get; set; }

        public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
        {
            if (Item != null)
            {
                Item.WriteTo(writer, Context);
            }
        }

        void IWritable.WriteTo(TextWriter writer, IBootstrapContext context)
        {
            if (Item != null)
            {
                Item.WriteTo(writer, context);
            }
        }
    }
}
