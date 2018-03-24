namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Grid;

    public static class GridRowExtensions
    {
        public static IItemWriter<T, GridRowContent> VerticalAlignment<T>(this IItemWriter<T, GridRowContent> target, VerticalAlignment value)
            where T : GridRow
        {
            target.Item.VerticalAlignment = value;
            return target;
        }

        public static IItemWriter<T, GridRowContent> HorizontalAlignment<T>(this IItemWriter<T, GridRowContent> target, HorizontalAlignment value)
            where T : GridRow
        {
            target.Item.HorizontalAlignment = value;
            return target;
        }

        public static IItemWriter<T, GridRowContent> NoGutters<T>(this IItemWriter<T, GridRowContent> target, bool value)
            where T : GridRow
        {
            target.Item.NoGutters = value;
            return target;
        }

        public static IItemWriter<GridRow, GridRowContent> GridRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<GridRow, GridRowContent>();
        }

        public static GridRowContent BeginGridRow(this IAnyContentMarker contentHelper)
        {
            return GridRow(contentHelper).BeginContent();
        }

        public static IItemWriter<FormRow, GridRowContent> FormRow(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<FormRow, GridRowContent>();
        }

        public static GridRowContent BeginFormRow(this IAnyContentMarker contentHelper)
        {
            return FormRow(contentHelper).BeginContent();
        }
    }
}
