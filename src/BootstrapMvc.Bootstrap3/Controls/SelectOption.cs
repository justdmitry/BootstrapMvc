using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class SelectOption : AnyContentElement, ISelectItem, IDisableable, IValueHolder
    {
        public object ValueValue { get; set; }

        public bool DisabledValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("option");

            if (ValueValue != null)
            {
                tb.MergeAttribute("value", ValueValue.ToString());
            }
            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            var formGroup = context.PeekNearest<Select>();
            var controlContext = formGroup == null ? null : formGroup.ControlContextValue;
            if (controlContext != null && controlContext.Value != null && ValueValue != null && ValueValue.ToString().Equals(controlContext.Value.ToString()))
            {
                tb.MergeAttribute("selected", "selected");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }
    }
}
