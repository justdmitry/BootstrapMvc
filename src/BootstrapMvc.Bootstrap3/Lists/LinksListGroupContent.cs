namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class LinksListGroupContent : ListGroupContent
    {
        public LinksListGroupContent(IBootstrapContext context, LinksListGroup parent) :
            base(context, null)
        {
            Parent = parent;
        }

        private LinksListGroup Parent;

        public new IItemWriter<Anchor, AnyContent> Item()
        {
            var res = Context.Helper.CreateWriter<Anchor, AnyContent>(Parent);

            res.Item.AddCssClass("list-group-item");

            return res;
        }

    }
}
