namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public class Checkbox : Element, IFormControl, ITextDisplay, IInlineDisplay
    {
        public string Text { get; set; }

        public bool Inline { get; set; }

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

            if (controlContext != null)
            {
                if (controlContext.HasErrors)
                {
                    div.AddCssClass("has-danger");
                }

                else if (controlContext.HasWarning)
                {
                    div.AddCssClass("has-warning");
                }
            }

            div.WriteStartTag(writer);

            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "checkbox", true);
            input.AddCssClass("form-check-input");
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.FieldName, true);
                input.MergeAttribute("name", controlContext.FieldName, true);
                input.MergeAttribute("value", "true", true);
                var controlValue = controlContext.FieldValue;
                if (controlValue != null && bool.Parse(controlValue.ToString()))
                {
                    input.MergeAttribute("checked", "checked", true);
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
            lbl.MergeAttribute("for", controlContext?.FieldName, true);
            lbl.AddCssClass("form-check-label");
            lbl.WriteStartTag(writer);
            writer.Write(Helper.HtmlEncode(Text ?? controlContext?.DisplayName));
            lbl.WriteEndTag(writer);

            div.WriteEndTag(writer);
        }
    }
}
