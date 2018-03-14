namespace BootstrapMvc.ListGroups
{
    using BootstrapMvc.Core;

    public class ActionableListGroupContent : DisposableContent
    {
        public ActionableListGroupContent(IBootstrapContext context, ActionableListGroup parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private ActionableListGroup Parent { get; set; }

        public IItemWriter<ListGroupButtonItem, AnyContent> Button()
        {
            return Context.Helper.CreateWriter<ListGroupButtonItem, AnyContent>(Parent);
        }

        public IItemWriter<ListGroupButtonItem, AnyContent> Button(ListGroupItemType type)
        {
            return Button().Type(type);
        }

        public IItemWriter<ListGroupLinkItem, AnyContent> Link()
        {
            return Context.Helper.CreateWriter<ListGroupLinkItem, AnyContent>(Parent);
        }

        public IItemWriter<ListGroupLinkItem, AnyContent> Link(ListGroupItemType type)
        {
            return Link().Type(type);
        }

        public AnyContent BeginButton()
        {
            return Button().BeginContent();
        }

        public AnyContent BeginButton(ListGroupItemType type)
        {
            return Button(type).BeginContent();
        }

        public AnyContent BeginLink()
        {
            return Link().BeginContent();
        }

        public AnyContent BeginLink(ListGroupItemType type)
        {
            return Link(type).BeginContent();
        }
    }
}
