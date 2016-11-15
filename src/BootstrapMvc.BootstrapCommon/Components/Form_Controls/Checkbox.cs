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
            var bootstrap4Mode = false;
#if BOOTSTRAP4
            bootstrap4Mode = true;
#endif

            var controlContext = GetNearestParent<IControlContext>();

            ITagBuilder div = null;
            if (!Inline)
            {
                div = Helper.CreateTagBuilder("div");
                div.AddCssClass(bootstrap4Mode ? "form-check" : "checkbox");

                if (bootstrap4Mode && controlContext != null)
                {
                    if (controlContext.HasErrors)
                    {
                        div.AddCssClass("has-danger checkbox");
                    }
                    else if (controlContext.HasWarning)
                    {
                        div.AddCssClass("has-warning checkbox");
                    }
                }

                div.WriteStartTag(writer);
            }

            var lbl = Helper.CreateTagBuilder("label");
            if (Inline)
            {
                lbl.AddCssClass(bootstrap4Mode ? "form-check-inline" : "checkbox-inline");
            }
            else
            {
                if (bootstrap4Mode)
                {
                    lbl.AddCssClass("form-check-label");
                }
            }
            lbl.WriteStartTag(writer);

            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "checkbox", true);
            if (bootstrap4Mode)
            {
                input.AddCssClass("form-check-input");
            }
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

            writer.Write(" "); // writing space to separate text from checkbox itself

            writer.Write(Helper.HtmlEncode(Text ?? controlContext?.DisplayName));

            lbl.WriteEndTag(writer);

            if (div != null)
            {
                div.WriteEndTag(writer);
            }
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }

        void IInlineDisplay.SetInline(bool inline)
        {
            Inline = inline;
        }

        bool IInlineDisplay.IsInline()
        {
            return Inline;
        }
    }
}
