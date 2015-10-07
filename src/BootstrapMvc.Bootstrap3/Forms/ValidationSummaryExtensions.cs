using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Bootstrap3.Forms
{
    public static class ValidationSummaryExtensions
    {
        #region Fluent

        public static IWriter<ValidationSummary<TModel>> HidePropertyErrors<TModel>(this IWriter<ValidationSummary<TModel>> target, bool hide = true)
        {
            target.Item.HidePropertyErrorsValue = hide;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter<ValidationSummary<TModel>> ValidationSummary<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return contentHelper.Context.CreateWriter<ValidationSummary<TModel>>();
        }

        #endregion
    }
}
