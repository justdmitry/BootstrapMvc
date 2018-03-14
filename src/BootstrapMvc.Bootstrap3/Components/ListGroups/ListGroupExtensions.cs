namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.ListGroups;

    public static class ListGroupExtensions
    {
        public static IItemWriter<OrdinaryListGroup, OrdinaryListGroupContent> OrdinaryListGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<OrdinaryListGroup, OrdinaryListGroupContent>();
        }

        public static OrdinaryListGroupContent BeginOrdinaryListGroup(this IAnyContentMarker contentHelper)
        {
            return OrdinaryListGroup(contentHelper).BeginContent();
        }

        public static IItemWriter<ActionableListGroup, ActionableListGroupContent> ActionableListGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ActionableListGroup, ActionableListGroupContent>();
        }

        public static ActionableListGroupContent BeginActionableListGroup(this IAnyContentMarker contentHelper)
        {
            return ActionableListGroup(contentHelper).BeginContent();
        }


        public static IItemWriter<ListGroupSimpleItem, AnyContent> ListGroupSimpleItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ListGroupSimpleItem, AnyContent>();
        }

        public static IItemWriter<ListGroupSimpleItem, AnyContent> ListGroupSimpleItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupSimpleItem(contentHelper).Type(type);
        }

        public static AnyContent BeginListGroupSimpleItem(this IAnyContentMarker contentHelper)
        {
            return ListGroupSimpleItem(contentHelper).BeginContent();
        }

        public static AnyContent BeginListGroupSimpleItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupSimpleItem(contentHelper).Type(type).BeginContent();
        }


        public static IItemWriter<ListGroupLinkItem, AnyContent> ListGroupLinkItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ListGroupLinkItem, AnyContent>();
        }

        public static IItemWriter<ListGroupLinkItem, AnyContent> ListGroupLinkItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupLinkItem(contentHelper).Type(type);
        }

        public static AnyContent BeginListGroupLinkItem(this IAnyContentMarker contentHelper)
        {
            return ListGroupLinkItem(contentHelper).BeginContent();
        }

        public static AnyContent BeginListGroupLinkItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupLinkItem(contentHelper).Type(type).BeginContent();
        }


        public static IItemWriter<ListGroupButtonItem, AnyContent> ListGroupButtonItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ListGroupButtonItem, AnyContent>();
        }

        public static IItemWriter<ListGroupButtonItem, AnyContent> ListGroupButtonItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupButtonItem(contentHelper).Type(type);
        }

        public static AnyContent BeginListGroupButtonItem(this IAnyContentMarker contentHelper)
        {
            return ListGroupButtonItem(contentHelper).BeginContent();
        }

        public static AnyContent BeginListGroupButtonItem(this IAnyContentMarker contentHelper, ListGroupItemType type)
        {
            return ListGroupButtonItem(contentHelper).Type(type).BeginContent();
        }
    }
}
