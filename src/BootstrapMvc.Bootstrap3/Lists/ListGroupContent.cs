namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class ListGroupContent : DisposableContent
    {
        public ListGroupContent(IBootstrapContext context, ListGroup parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        protected IBootstrapContext Context { get; set; }

        private ListGroup Parent { get; set; }

        public IItemWriter<OrdinaryElement, AnyContent> Item()
        {
            var res = Context.Helper.CreateWriter<OrdinaryElement, AnyContent>(Parent);

            res.Item.TagName = "li";

            res.Item.AddCssClass("list-group-item");

            return res;
        }

        public AnyContent BeginItem()
        {
            return Item().BeginContent();
        }
    }
}
