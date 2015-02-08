using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Fieldset : ContentElement<FormContent>
    {
        public Fieldset(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public Legend LegendValue { get; set; }

        public bool DisabledValue { get; set; }

        public Fieldset Legend(object value)
        {
            var legendValue = value as Legend;
            LegendValue = legendValue ?? (Legend)new Legend(Context).Content(value);
            return this;
        }

        public Fieldset Legend(params object[] values)
        {
            LegendValue = (Legend)new Legend(Context).Content(values);
            return this;
        }

        protected override FormContent CreateContentContext()
        {
            return new FormContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("fieldset");

            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (LegendValue != null)
            {
                LegendValue.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</fieldset>");
        }
    }
}
