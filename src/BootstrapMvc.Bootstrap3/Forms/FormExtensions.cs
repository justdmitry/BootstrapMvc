using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class FormExtensions
    {
        #region Fluent

        public static IWriter2<T, FormContent<TModel>> Method<T, TModel>(this IWriter2<T, FormContent<TModel>> target, SubmitMethod value)
            where T : Form<TModel>
        {
            target.Item.MethodValue = value;
            return target;
        }

        public static IWriter2<T, FormContent<TModel>> Type<T, TModel>(this IWriter2<T, FormContent<TModel>> target, FormType value)
            where T : Form<TModel>
        {
            target.Item.TypeValue = value;
            return target;
        }

        public static IWriter2<T, FormContent<TModel>> Enctype<T, TModel>(this IWriter2<T, FormContent<TModel>> target, FormEnctype value)
            where T : Form<TModel>
        {
            target.Item.EnctypeValue = value;
            return target;
        }
        
        public static IWriter2<T, FormContent<TModel>> LabelWidth<T, TModel>(this IWriter2<T, FormContent<TModel>> target, GridSize value)
            where T : Form<TModel>
        {
            target.Item.LabelWidthValue = value;
            return target;
        }

        public static IWriter2<T, FormContent<TModel>> ControlsWidth<T, TModel>(this IWriter2<T, FormContent<TModel>> target, GridSize value)
            where T : Form<TModel>
        {
            target.Item.ControlsWidthValue = value;
            return target;
        }

        #endregion

        #region Generating

        public static IWriter2<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return contentHelper.Context.CreateWriter<Form<TModel>, FormContent<TModel>>();
        }

        public static IWriter2<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type)
        {
            return Form<TModel>(contentHelper).Type(type);
        }

        public static IWriter2<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormEnctype enctype)
        {
            return Form<TModel>(contentHelper).Enctype(enctype);
        }

        public static IWriter2<Form<TModel>, FormContent<TModel>> Form<TModel>(this IAnyContentMarker<TModel> contentHelper, FormType type, FormEnctype enctype)
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
