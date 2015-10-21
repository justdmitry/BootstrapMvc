namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Lists;

    public static class DefinitionListExtensions
    {
        #region Fluent

        public static IItemWriter<T, DefinitionListContent> Horizontal<T>(this IItemWriter<T, DefinitionListContent> target, bool value = true) where T : DefinitionList
        {
            target.Item.Horizontal = value;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<DefinitionList, DefinitionListContent> DefinitionList(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<DefinitionList, DefinitionListContent>();
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
