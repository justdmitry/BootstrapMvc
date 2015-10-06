using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class FormGroupExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Label<T>(this IWriter2<T, AnyContent> target, object content)
            where T : FormGroup
        {
            var labelContent = content as FormGroupLabel;
            target.Item.LabelValue = labelContent ?? target.Context.CreateWriter<FormGroupLabel, AnyContent>().Content(content).Item;
            return target;
        }

        public static IWriter2<T, AnyContent> Label<T>(this IWriter2<T, AnyContent> target, params object[] contents)
            where T : FormGroup
        {
            target.Item.LabelValue = target.Context.CreateWriter<FormGroupLabel, AnyContent>().Content(contents).Item;
            return target;
        }

        public static IWriter2<T, AnyContent> Control<T, TControl>(this IWriter2<T, AnyContent> target, IWriter<TControl> value)
            where T : FormGroup
            where TControl : IFormControl
        {
            target.Item.ControlValue = value.Item;
            return target;
        }

        public static IWriter2<T, AnyContent> Required<T>(this IWriter2<T, AnyContent> target, bool value = true)
            where T : FormGroup
        {
            target.Item.IsRequiredValue = value;
            return target;
        }

        public static IWriter2<T, AnyContent> WithSizedControls<T>(this IWriter2<T, AnyContent> target, bool value = true)
            where T : FormGroup
        {
            target.Item.WithSizedControlValue = value;
            return target;
        }

        public static AnyContent BeginControls<T>(this IWriter2<T, AnyContent> target)
            where T : FormGroup
        {
            return target.Item.BeginControls(target.Context);
        }

        #endregion

        #region Generating

        public static IWriter2<FormGroup, AnyContent> FormGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<FormGroup, AnyContent>();
        }

        public static IWriter2<FormGroup, AnyContent> FormGroup(this IAnyContentMarker contentHelper, object label)
        {
            return FormGroup(contentHelper).Label(label);
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper)
        {
            return FormGroup(contentHelper).BeginContent();
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper, object label)
        {
            return FormGroup(contentHelper, label).BeginContent();
        }

        public static IWriter2<FormGroup, AnyContent> FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var fg = contentHelper.Context.CreateWriter<FormGroup, AnyContent>();
            return ControlContextHolderExtensions.ControlContext(fg, contentHelper.Context.GetControlContext(expression));
        }

        public static IWriter2<FormGroup, AnyContent> FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, object label)
        {
            return FormGroupFor(contentHelper, expression).Label(label);
        }

        public static AnyContent BeginFormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return FormGroupFor(contentHelper, expression).BeginContent();
        }

        public static AnyContent BeginFormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, object label)
        {
            return FormGroupFor(contentHelper, expression, label).BeginContent();
        }

        #endregion
    }
}
