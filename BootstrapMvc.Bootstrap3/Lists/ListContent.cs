using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class ListContent : DisposableContext
    {
        public ListContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public AnyContentElement Item()
        {
            return new OrdinaryElement(Context, "li");
        }

        public AnyContentContext BeginItem()
        {
            return Item().BeginContent();
        }
    }
}
