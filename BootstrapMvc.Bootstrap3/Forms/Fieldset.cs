using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Fieldset : ContentElement<FormContent>
    {
        private Legend legend;

        private bool disabled;

        public Fieldset(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Fieldset Legend(object value)
        {
            var legendValue = value as Legend;
            legend = legendValue ?? (Legend)new Legend(Context).Content(value);
            return this;
        }

        public Fieldset Legend(params object[] values)
        {
            legend = (Legend)new Legend(Context).Content(values);
            return this;
        }

        public Fieldset Disabled(bool disabled = true)
        {
            this.disabled = disabled;
            return this;
        }

        #endregion

        protected override FormContent CreateContent()
        {
            return new FormContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("fieldset");

            if (disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (legend != null)
            {
                legend.WriteTo(writer);
            }

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
