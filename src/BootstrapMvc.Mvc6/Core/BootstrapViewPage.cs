using System;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.AspNet.Mvc.Razor.Internal;
using Microsoft.AspNet.Mvc;

namespace BootstrapMvc.Core
{
    public abstract class BootstrapViewPage : RazorPage<object>
    {
        BootstrapHelper bootstrap;

        public BootstrapHelper Bootstrap {
            get
            {
                if (bootstrap == null)
                {
                    var context = new BootstrapContext(ViewContext, UrlHelper, HtmlEncoder);
                    bootstrap = new BootstrapHelper(context);
                }
                return bootstrap;
            }
        }

        [RazorInject]
        public IUrlHelper UrlHelper { get; set; }

        public static void WriteTo(System.IO.TextWriter writer, WritableBlock block)
        {
            if (block != null)
            {
                block.WriteTo(writer);
            }
        }

        public void Write(WritableBlock block)
        {
            if (block != null)
            {
                block.WriteTo(this.ViewContext.Writer);
            }
        }
    }
}
