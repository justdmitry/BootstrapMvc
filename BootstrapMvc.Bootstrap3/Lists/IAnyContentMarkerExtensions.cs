using BootstrapMvc.Core;
using BootstrapMvc.Lists;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
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
    }
}
