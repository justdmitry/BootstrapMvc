namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public class SelectOption : AnyContentElement, ISelectItem, IDisableable, IValueHolder
    {
        public object Value { get; set; }

        public bool Disabled { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var controlContext = GetNearestParent<IControlContext>();

            var tb = Helper.CreateTagBuilder("option");

            if (Value != null)
            {
                tb.MergeAttribute("value", Value.ToString());
            }
            if (Disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            if (controlContext != null && controlContext.FieldValue != null && Value != null && Value.ToString().Equals(controlContext.FieldValue.ToString()))
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
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }
    }
}
