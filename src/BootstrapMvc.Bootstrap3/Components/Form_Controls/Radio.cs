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
            var bootstrap4Mode = false;
#if BOOTSTRAP4
            bootstrap4Mode = true;
#endif

            var controlContext = GetNearestParent<IControlContext>();

            ITagBuilder div = null;
            ITagBuilder lbl = null;

            if (bootstrap4Mode)
            {
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

                lbl = Helper.CreateTagBuilder("label");
                lbl.AddCssClass("form-check-label");

            }
            else
            {
                if (!Inline)
                {
                    div = Helper.CreateTagBuilder("div");
                    div.AddCssClass("radio");
                }

                lbl = Helper.CreateTagBuilder("label");
                if (Inline)
                {
                    lbl.AddCssClass("radio-inline");
                }
            }

            div?.WriteStartTag(writer);
            lbl?.WriteStartTag(writer);

            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "radio", true);
            if (bootstrap4Mode)
            {
                input.AddCssClass("form-check-input");
            }
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.FieldName, true);
                input.MergeAttribute("name", controlContext.FieldName, true);
                input.MergeAttribute("value", Value?.ToString(), true);
                var controlValue = controlContext.FieldValue;
                if (controlValue != null && Value != null && Value.ToString().Equals(controlValue.ToString()))
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

            writer.Write(" "); // writing space to separate text from radio itself

            writer.Write(Helper.HtmlEncode(Text ?? controlContext?.DisplayName));

            lbl?.WriteEndTag(writer);
            div?.WriteEndTag(writer);
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }

        bool IInlineDisplay.IsInline()
        {
            return Inline;
        }

        void IInlineDisplay.SetInline(bool inline)
        {
            Inline = inline;
        }
    }
}
