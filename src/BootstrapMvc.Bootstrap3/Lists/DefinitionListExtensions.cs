using System;
using BootstrapMvc.Core;
using BootstrapMvc.Lists;

namespace BootstrapMvc
{
    public static class DefinitionListExtensions
    {
        #region Fluent

        public static IWriter2<T, DefinitionListContent> Horizontal<T>(this IWriter2<T, DefinitionListContent> target, bool value = true) where T : DefinitionList
        {
            target.Item.HorizontalValue = value;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<DefinitionList, DefinitionListContent> DefinitionList(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<DefinitionList, DefinitionListContent>();
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
