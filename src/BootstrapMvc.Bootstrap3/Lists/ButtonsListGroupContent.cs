namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class ButtonsListGroupContent : ListGroupContent
    {
        public ButtonsListGroupContent(IBootstrapContext context, ButtonsListGroup parent) :
            base(context, null)
        {
            Parent = parent;
        }

        private ButtonsListGroup Parent;

        public new IItemWriter<ListGroupButton, AnyContent> Item()
        {
            var res = Context.Helper.CreateWriter<ListGroupButton, AnyContent>(Parent);

            res.Item.AddCssClass("list-group-item");

            return res;
        }

    }
}
