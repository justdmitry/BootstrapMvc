using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region Checkbox

        public static Checkbox Text(this Checkbox target, string value)
        {
            target.TextValue = value;
            return target;
        }

        public static Checkbox Inline(this Checkbox target, bool inline = true)
        {
            target.InlineValue = inline;
            return target;
        }

        #endregion

        #region Radio

        public static Radio Text(this Radio target, string value)
        {
            target.TextValue = value;
            return target;
        }

        public static Radio Inline(this Radio target, bool inline = true)
        {
            target.InlineValue = inline;
            return target;
        }

        public static Radio Value(this Radio target, string value)
        {
            target.ValueValue = value;
            return target;
        }

        #endregion

        #region Input

        public static Input Type(this Input target, InputType value)
        {
            target.TypeValue = value;
            return target;
        }

        #endregion

        #region Select

        public static Select Items(this Select target, IEnumerable<ISelectItem> items)
        {
            target.ItemsValue = items.ToArray();
            return target;
        }

        public static Select Items(this Select target, params ISelectItem[] items)
        {
            target.ItemsValue = items;
            return target;
        }

        #endregion

        #region SelectOptGroup

        public static SelectOptGroup Label(this SelectOptGroup target, string value) 
        {
            target.LabelValue = value;
            return target;
        }

        public static SelectOptGroup Disabled(this SelectOptGroup target, bool value) 
        {
            target.DisabledValue = value;
            return target;
        }

        #endregion

        #region SelectOption

        public static SelectOption Value(this SelectOption target, object value)
        {
            target.ValueValue = value;
            return target;
        }

        public static SelectOption Disabled(this SelectOption target, bool value)
        {
            target.DisabledValue = value;
            return target;
        }

        #endregion

        #region Textarea

        public static Textarea Rows(this Textarea target, int value)
        {
            target.RowsValue = value;
            return target;
        }

        #endregion

        #region IFormControl

        public static T ControlContext<T>(this T target, IControlContext value) where T : IFormControl
        {
            target.SetControlContext(value);
            return target;
        }

        public static T For<T>(this T target, IControlContext controlContext) where T : IFormControl
        {
            target.SetControlContext(controlContext);
            return target;
        }

        #endregion
    }
}
