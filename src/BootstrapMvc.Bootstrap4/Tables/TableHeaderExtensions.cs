namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class TableHeaderExtensions
    {
        #region Fluent

        public static IItemWriter<T, TableSectionContent> Style<T>(this IItemWriter<T, TableSectionContent> target, TableHeaderStyles styles)
            where T : TableHeader
        {
            target.Item.Style = styles;
            return target;
        }

        #endregion
    }
}
