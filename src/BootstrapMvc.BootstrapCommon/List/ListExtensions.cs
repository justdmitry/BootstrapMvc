namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ListExtensions
    {
        #region Fluent

        public static IItemWriter<T, ListContent> Type<T>(this IItemWriter<T, ListContent> target, ListType value) where T : List
        {
            target.Item.Type = value;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<List, ListContent> List(this IAnyContentMarker contentHelper, ListType type)
        {
            return contentHelper.CreateWriter<List, ListContent>().Type(type);
        }

        public static ListContent BeginList(this IAnyContentMarker contentHelper, ListType type)
        {
            return List(contentHelper, type).BeginContent();
        }

        public static IItemWriter<OrdinaryElement, AnyContent> ListItem(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("li");
        }

        public static AnyContent BeginListItem(this IAnyContentMarker contentHelper)
        {
            return ListItem(contentHelper).BeginContent();
        }

        #endregion
    }
}
