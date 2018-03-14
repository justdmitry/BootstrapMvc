namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class ValidationSummaryExtensions
    {
        #region Fluent

        public static IItemWriter<ValidationSummary<TModel>> HidePropertyErrors<TModel>(this IItemWriter<ValidationSummary<TModel>> target, bool hide = true)
        {
            target.Item.HidePropertyErrors = hide;
            return target;
        }

        public static IItemWriter<ValidationSummary<TModel>> ErrorHeader<TModel>(this IItemWriter<ValidationSummary<TModel>> target, string value)
        {
            target.Item.ErrorHeader = value;
            return target;
        }

        public static IItemWriter<ValidationSummary<TModel>> ErrorFooter<TModel>(this IItemWriter<ValidationSummary<TModel>> target, string value)
        {
            target.Item.ErrorFooter = value;
            return target;
        }

        public static IItemWriter<ValidationSummary<TModel>> WarningHeader<TModel>(this IItemWriter<ValidationSummary<TModel>> target, string value)
        {
            target.Item.WarningHeader = value;
            return target;
        }

        public static IItemWriter<ValidationSummary<TModel>> WarningFooter<TModel>(this IItemWriter<ValidationSummary<TModel>> target, string value)
        {
            target.Item.WarningFooter = value;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<ValidationSummary<TModel>> ValidationSummary<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return contentHelper.CreateWriter<ValidationSummary<TModel>>();
        }

        #endregion
    }
}
