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
            if (!Inline)
            {
                div = Helper.CreateTagBuilder("div");
                div.AddCssClass("checkbox");
                div.WriteStartTag(writer);
            }

            var lbl = Helper.CreateTagBuilder("label");
            if (Inline)
            {
                lbl.AddCssClass("checkbox-inline");
            }
            lbl.WriteStartTag(writer);

            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "checkbox");
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.FieldName);
                input.MergeAttribute("name", controlContext.FieldName);
                input.MergeAttribute("value", "true");
                var controlValue = controlContext.FieldValue;
                if (controlValue != null && bool.Parse(controlValue.ToString()))
                {
                    input.MergeAttribute("checked", "checked");
                }
            }
            if (Disabled)
            {
                input.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            input.WriteFullTag(writer);

            writer.Write(" "); // writing space to separate text from checkbox itself

            writer.Write(Helper.HtmlEncode(Text));

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
