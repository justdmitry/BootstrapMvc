namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public class Radio : Element, IFormControl, ITextDisplay, IValueHolder, IInlineDisplay
    {
        public string Text { get; set; }

        public bool Inline { get; set; }

        public object Value { get; set; }

        public bool Disabled { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var controlContext = GetNearestParent<IControlContext>();

            ITagBuilder div = null;
            ITagBuilder lbl = null;

            div = Helper.CreateTagBuilder("div");
            div.AddCssClass("form-check");
            if (Inline)
            {
                div.AddCssClass("form-check-inline");
            }

            div.WriteStartTag(writer);

            var fieldId = (controlContext?.FieldName ?? "radio") + "-" + this.GetHashCode();

            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "radio", true);
            input.AddCssClass("form-check-input");
            input.MergeAttribute("id", fieldId, true);
            input.MergeAttribute("value", Value?.ToString(), true);

            if (controlContext != null)
            {
                input.MergeAttribute("name", controlContext.FieldName, true);
                var controlValue = controlContext.FieldValue;
                if (controlValue != null && Value != null && Value.ToString().Equals(controlValue.ToString()))
                {
                    input.MergeAttribute("checked", "checked", true);
                }

                if (controlContext.HasErrors || controlContext.HasWarning)
                {
                    input.AddCssClass("is-invalid");
                }
            }

            if (Disabled)
            {
                input.MergeAttribute("disabled", "disabled", true);
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            input.WriteFullTag(writer);

            lbl = Helper.CreateTagBuilder("label");
            lbl.MergeAttribute("for", fieldId, true);
            lbl.AddCssClass("form-check-label");
            lbl.WriteStartTag(writer);
            writer.Write(Helper.HtmlEncode(Text ?? controlContext?.DisplayName));
            lbl.WriteEndTag(writer);

            div.WriteEndTag(writer);
        }
    }
}
