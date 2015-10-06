using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class FieldsetExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Legend<T>(this IWriter2<T, AnyContent> target, Legend value)
            where T : Fieldset
        {
            target.Item.LegendValue = value;
            return target;
        }

        public static IWriter2<T, AnyContent> Legend<T>(this IWriter2<T, AnyContent> target, object value)
            where T : Fieldset
        {
            var leg = target.Context.CreateWriter<Legend, AnyContent>();
            leg.Content(value);
            target.Item.LegendValue = leg.Item;
            return target;
        }

        public static IWriter2<T, AnyContent> Legend<T>(this IWriter2<T, AnyContent> target, params object[] values)
            where T : Fieldset
        {
            var leg = target.Context.CreateWriter<Legend, AnyContent>();
            leg.Content(values);
            target.Item.LegendValue = leg.Item;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<Fieldset, AnyContent> FormFieldset(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Fieldset, AnyContent>();
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
