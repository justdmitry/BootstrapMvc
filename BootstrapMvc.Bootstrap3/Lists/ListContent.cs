using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class ListContent : DisposableContent
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

        public AnyContent BeginItem()
        {
            return Item().BeginContent();
        }
    }
}
