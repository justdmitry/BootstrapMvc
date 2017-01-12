namespace BootstrapMvc.ListGroups
{
    using BootstrapMvc.Core;

    public class OrdinaryListGroupContent : DisposableContent
    {
        public OrdinaryListGroupContent(IBootstrapContext context, OrdinaryListGroup parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private OrdinaryListGroup Parent { get; set; }

        public IItemWriter<ListGroupSimpleItem, AnyContent> Item()
        {
            return Context.Helper.CreateWriter<ListGroupSimpleItem, AnyContent>(Parent);
        }

        public IItemWriter<ListGroupSimpleItem, AnyContent> Item(ListGroupItemType type)
        {
            return Item().Type(type);
        }

        public AnyContent BeginItem()
        {
            return Item().BeginContent();
        }

        public AnyContent BeginItem(ListGroupItemType type)
        {
            return Item(type).BeginContent();
        }
    }
}
