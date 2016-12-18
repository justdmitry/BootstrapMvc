namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Lists;

    public static class ListGroupExtensions
    {
        #region Fluent
        public static IItemWriter<T, AnyContent> ListGroupItemType<T>(this IItemWriter<T, AnyContent> target, ListGroupItemType type) where T : AnyContentElement
        {
            switch (type)
            {
                case Lists.ListGroupItemType.Danger:
                    return target.CssClass("list-group-item-danger");
                case Lists.ListGroupItemType.Warning:
                    return target.CssClass("list-group-item-warning");
                case Lists.ListGroupItemType.Info:
                    return target.CssClass("list-group-item-info");
                case Lists.ListGroupItemType.Success:
                    return target.CssClass("list-group-item-success");
                default:
                    return target;
            }
        }
        #endregion

        #region Generation

        public static IItemWriter<ListGroup, ListGroupContent> ListGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ListGroup, ListGroupContent>();
        }

        public static ListGroupContent BeginListGroup(this IAnyContentMarker contentHelper)
        {
            return ListGroup(contentHelper).BeginContent();
        }

        public static IItemWriter<OrdinaryElement, AnyContent> ListGroupItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("li");
        }

        public static AnyContent BeginListGroupItem(this IAnyContentMarker contentHelper)
        {
            return ListGroupItem(contentHelper).BeginContent();
        }


        #region Links
        public static IItemWriter<LinksListGroup, LinksListGroupContent> LinksListGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<LinksListGroup, LinksListGroupContent>();
        }

        public static LinksListGroupContent BeginLinksListGroup(this IAnyContentMarker contentHelper)
        {
            return LinksListGroup(contentHelper).BeginContent();
        }

        public static IItemWriter<Anchor, AnyContent> LinksListGroupItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Anchor, AnyContent>();
        }

        public static AnyContent BeginLinksListGroupItem(this IAnyContentMarker contentHelper)
        {
            return LinksListGroupItem(contentHelper).BeginContent();
        }
        #endregion

        #region Buttons
        public static IItemWriter<ButtonsListGroup, ButtonsListGroupContent> ButtonsListGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ButtonsListGroup, ButtonsListGroupContent>();
        }

        public static ButtonsListGroupContent BeginButtonsListGroup(this IAnyContentMarker contentHelper)
        {
            return ButtonsListGroup(contentHelper).BeginContent();
        }

        public static IItemWriter<ListGroupButton, AnyContent> ButtonsListGroupItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ListGroupButton, AnyContent>();
        }

        public static AnyContent BeginButtonsListGroupItem(this IAnyContentMarker contentHelper)
        {
            return ButtonsListGroupItem(contentHelper).BeginContent();
        }
        #endregion


        #endregion
    }
}
