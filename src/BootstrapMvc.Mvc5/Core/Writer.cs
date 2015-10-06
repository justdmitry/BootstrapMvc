using System;
using System.IO;
using System.Web;

namespace BootstrapMvc.Core
{
    public class Writer<TItem> : IWriter<TItem>, IHtmlString
        where TItem : IWritable
    {
        public TItem Item { get; set; }

        public IBootstrapContext Context { get; set; }

        void IWritable.WriteTo(TextWriter writer, IBootstrapContext context)
        {
            if (Item != null)
            {
                Item.WriteTo(writer, context);
            }
        }

        public string ToHtmlString()
        {
            using (var sw = new StringWriter())
            {
                Item.WriteTo(sw, Context);
                return sw.ToString();
            }
        }
    }
}
