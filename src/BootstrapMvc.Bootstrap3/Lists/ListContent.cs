using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class ListContent : DisposableContent
    {
        public ListContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; set; }

        public IWriter2<OrdinaryElement, AnyContent> Item()
        {
            var res = Context.CreateWriter<OrdinaryElement, AnyContent>();
            res.Item.TagName = "li";
            return res;
        }

        public AnyContent BeginItem()
        {
            return Item().BeginContent();
        }
    }
}
