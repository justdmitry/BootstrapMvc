namespace BootstrapMvc
{
    using System;
    using System.Linq.Expressions;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class ControlContextExtensions
    {
        public static IItemWriter<T> Required<T>(this IItemWriter<T> target, bool value = true)
            where T : IControlContext
        {
            target.Item.IsRequired = value;
            return target;
        }

        public static IItemWriter<T, TContent> Required<T, TContent>(this IItemWriter<T, TContent> target, bool value = true)
            where T : ContentElement<TContent>, IControlContext
            where TContent : DisposableContent
        {
            target.Item.IsRequired = value;
            return target;
        }

        public static IItemWriter<ControlContext, AnyContent> ControlFor<TModel, TProperty>(
            this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var fg = contentHelper.CreateWriter<ControlContext, AnyContent>();
            contentHelper.Context.Helper.FillControlContext(fg.Item, expression);
            return fg;
        }

        public static IItemWriter<ControlContext, AnyContent> ControlFor<TModel, TProperty, TControl>(
            this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression,
            IItemWriter<TControl> control)
            where TControl : IFormControl
        {
            return ControlFor(contentHelper, expression).Content(control);
        }
    }
}
