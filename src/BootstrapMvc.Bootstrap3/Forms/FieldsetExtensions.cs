namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class FieldsetExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Legend<T>(this IItemWriter<T, AnyContent> target, Legend value)
            where T : Fieldset
        {
            target.Item.Legend = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Legend<T>(this IItemWriter<T, AnyContent> target, object value)
            where T : Fieldset
        {
            var leg = target.Helper.CreateWriter<Legend, AnyContent>(target.Item);
            leg.Content(value);
            target.Item.Legend = leg.Item;
            return target;
        }

        public static IItemWriter<T, AnyContent> Legend<T>(this IItemWriter<T, AnyContent> target, params object[] values)
            where T : Fieldset
        {
            var leg = target.Helper.CreateWriter<Legend, AnyContent>(target.Item);
            leg.Content(values);
            target.Item.Legend = leg.Item;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<Fieldset, AnyContent> FormFieldset(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Fieldset, AnyContent>();
        }

        public static AnyContent BeginFormFieldset(this IAnyContentMarker contentHelper)
        {
            return FormFieldset(contentHelper).BeginContent();
        }

        public static AnyContent BeginFormFieldset(this IAnyContentMarker contentHelper, object legend)
        {
            return FormFieldset(contentHelper).Legend(legend).BeginContent();
        }

        #endregion
    }
}
