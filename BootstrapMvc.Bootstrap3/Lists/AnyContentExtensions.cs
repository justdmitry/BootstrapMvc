using BootstrapMvc.Core;
using BootstrapMvc.Lists;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region DenifnitionList

        public static DefinitionList DefinitionList(this IAnyContentMarker contentHelper)
        {
            return new DefinitionList(contentHelper.Context);
        }

        public static DefinitionListContent BeginDefinitionList(this IAnyContentMarker contentHelper)
        {
            return DefinitionList(contentHelper).BeginContent();
        }

        public static DefinitionListContent BeginDefinitionList(this IAnyContentMarker contentHelper, bool horizontal)
        {
            return DefinitionList(contentHelper).Horizontal(horizontal).BeginContent();
        }

        #endregion

        #region List

        public static List List(this IAnyContentMarker contentHelper, ListType type)
        {
            return new List(contentHelper.Context).Type(type);
        }

        public static ListContent BeginList(this IAnyContentMarker contentHelper, ListType type)
        {
            return List(contentHelper, type).BeginContent();
        }

        public static AnyContentElement ListItem(this IAnyContentMarker contentHelper)
        {
            return new OrdinaryElement(contentHelper.Context, "li");
        }

        public static AnyContent BeginListItem(this IAnyContentMarker contentHelper)
        {
            return ListItem(contentHelper).BeginContent();
        }

        #endregion
    }
}
