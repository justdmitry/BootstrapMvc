using System;
using BootstrapMvc.Core;
using BootstrapMvc.Lists;

namespace BootstrapMvc
{
    public static class ListExtensions
    {
        #region Fluent

        public static IWriter2<T, ListContent> Type<T>(this IWriter2<T, ListContent> target, ListType value) where T : List
        {
            target.Item.TypeValue = value;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<List, ListContent> List(this IAnyContentMarker contentHelper, ListType type)
        {
            return contentHelper.Context.CreateWriter<List, ListContent>().Type(type);
        }

        public static ListContent BeginList(this IAnyContentMarker contentHelper, ListType type)
        {
            return List(contentHelper, type).BeginContent();
        }

        public static IWriter2<OrdinaryElement, AnyContent> ListItem(this IAnyContentMarker contentHelper)
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
