//namespace BootstrapMvc
//{
//    using System;
//    using BootstrapMvc.Core;
//    using BootstrapMvc.Forms;

//    public static class ValidationSummaryExtensions
//    {
//        #region Fluent

//        public static IItemWriter<ValidationSummary<TModel>> HidePropertyErrors<TModel>(this IItemWriter<ValidationSummary<TModel>> target, bool hide = true)
//        {
//            target.Item.HidePropertyErrors = hide;
//            return target;
//        }

//        #endregion

//        #region Generation

//        public static IItemWriter<ValidationSummary<TModel>> ValidationSummary<TModel>(this IAnyContentMarker<TModel> contentHelper)
//        {
//            return contentHelper.CreateWriter<ValidationSummary<TModel>>();
//        }

//        #endregion
//    }
//}
