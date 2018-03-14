namespace BootstrapMvc.Lists
{
    using System;
    using BootstrapMvc.Core;

    public class ListContent : DisposableContent
    {
        public ListContent(IBootstrapContext context, List parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private List Parent { get; set; }

        public IItemWriter<OrdinaryElement, AnyContent> Item()
        {
            var res = Context.Helper.CreateWriter<OrdinaryElement, AnyContent>(Parent);
            res.Item.TagName = "li";
#if BOOTSTRAP4
            if (Parent.Type == ListType.Inline)
            {
                res.Item.AddCssClass("list-inline-item");
            }
#endif
            return res;
        }

        public AnyContent BeginItem()
        {
            return Item().BeginContent();
        }
    }
}
