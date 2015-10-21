namespace BootstrapMvc
{
    using System;
    using System.Linq.Expressions;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class FormGroupExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Label<T>(this IItemWriter<T, AnyContent> target, object content)
            where T : FormGroup
        {
            var labelContent = content as FormGroupLabel;
            target.Item.Label = labelContent ?? target.Helper.CreateWriter<FormGroupLabel, AnyContent>(target.Item).Content(content).Item;
            return target;
        }

        public static IItemWriter<T, AnyContent> Label<T>(this IItemWriter<T, AnyContent> target, params object[] contents)
            where T : FormGroup
        {
            target.Item.Label = target.Helper.CreateWriter<FormGroupLabel, AnyContent>(target.Item).Content(contents).Item;
            return target;
        }

        public static IItemWriter<T, AnyContent> Control<T>(this IItemWriter<T, AnyContent> target, IFormControl value)
            where T : FormGroup
        {
            target.Item.Control = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Control<T, TControl>(this IItemWriter<T, AnyContent> target, IItemWriter<TControl> value)
            where T : FormGroup
            where TControl : IFormControl
        {
            target.Item.Control = value.Item;
            return target;
        }

        public static IItemWriter<T, AnyContent> Required<T>(this IItemWriter<T, AnyContent> target, bool value = true)
            where T : FormGroup
        {
            target.Item.IsRequired = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> WithSizedControls<T>(this IItemWriter<T, AnyContent> target, bool value = true)
            where T : FormGroup
        {
            target.Item.WithSizedControl = value;
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<FormGroup, AnyContent> FormGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<FormGroup, AnyContent>();
        }

        public static IItemWriter<FormGroup, AnyContent> FormGroup(this IAnyContentMarker contentHelper, object label)
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

        public static IItemWriter<FormGroup, AnyContent> FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var fg = contentHelper.CreateWriter<FormGroup, AnyContent>();
            contentHelper.Context.Helper.FillControlContext(fg.Item, expression);
            return fg;
        }

        public static IItemWriter<FormGroup, AnyContent> FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, object label)
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
