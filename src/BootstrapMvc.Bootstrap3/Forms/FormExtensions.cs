namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class FormExtensions
    {
        #region Fluent

        public static IItemWriter<T, FormContent<TModel>> Method<T, TModel>(this IItemWriter<T, FormContent<TModel>> target, SubmitMethod value)
            where T : Form<TModel>
        {
            target.Item.Method = value;
            return target;
        }

        public static IItemWriter<T, FormContent<TModel>> Type<T, TModel>(this IItemWriter<T, FormContent<TModel>> target, FormType value)
            where T : Form<TModel>
        {
            target.Item.Type = value;
            return target;
        }

        public static IItemWriter<T, FormContent<TModel>> Enctype<T, TModel>(this IItemWriter<T, FormContent<TModel>> target, FormEnctype value)
            where T : Form<TModel>
        {
            target.Item.Enctype = value;
            return target;
        }
        
        public static IItemWriter<T, FormContent<TModel>> LabelWidth<T, TModel>(this IItemWriter<T, FormContent<TModel>> target, GridSize value)
            where T : Form<TModel>
        {
            target.Item.LabelWidth = value;
            return target;
        }

        public static IItemWriter<T, FormContent<TModel>> ControlsWidth<T, TModel>(this IItemWriter<T, FormContent<TModel>> target, GridSize value)
            where T : Form<TModel>
        {
            target.Item.ControlsWidth = value;
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return contentHelper.CreateWriter<Form<TModel>, FormContent<TModel>>();
        }

        public static IItemWriter<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type)
        {
            return Form<TModel>(contentHelper).Type(type);
        }

        public static IItemWriter<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormEnctype enctype)
        {
            return Form<TModel>(contentHelper).Enctype(enctype);
        }

        public static IItemWriter<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type, FormEnctype enctype)
        {
            return Form<TModel>(contentHelper).Type(type).Enctype(enctype);
        }

        public static FormContent<TModel> BeginForm<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return Form<TModel>(contentHelper).BeginContent();
        }

        public static FormContent<TModel> BeginForm<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type)
        {
            return Form<TModel>(contentHelper, type).BeginContent();
        }

        public static FormContent<TModel> BeginForm<TModel>(this IAnyContentMarker<TModel> contentHelper, FormEnctype enctype)
        {
            return Form<TModel>(contentHelper, enctype).BeginContent();
        }

        public static FormContent<TModel> BeginForm<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type, FormEnctype enctype)
        {
            return Form<TModel>(contentHelper, type, enctype).BeginContent();
        }

        #endregion
    }
}
