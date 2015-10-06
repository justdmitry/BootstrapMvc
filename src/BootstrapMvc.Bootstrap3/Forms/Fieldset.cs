using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Fieldset : AnyContentElement, IDisableable
    {
        public Legend LegendValue { get; set; }

        public bool DisabledValue { get; set; }

        public void SetDisabled(bool disabled = true)
        {
            DisabledValue = disabled;
        }

        public bool Disabled()
        {
            return DisabledValue;
        }

        protected override AnyContent CreateContentContext(IBootstrapContext context)
        {
            return new AnyContent(context);
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("fieldset");

            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (LegendValue != null)
            {
                LegendValue.WriteTo(writer, context);
            }

            return "</fieldset>";
        }
    }
}
