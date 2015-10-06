using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Checkbox : Element, IFormControl, ITextDisplay, IInlineDisplay
    {
        public IControlContext ControlContextValue { get; set; }

        public string TextValue { get; set; }

        public bool InlineValue { get; set; }

        public bool DisabledValue { get; set; }

        void IControlContextHolder.SetControlContext(IControlContext context)
        {
            ControlContextValue = context;
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var formGroup = context.PeekNearest<FormGroup>();
            if (formGroup != null && ControlContextValue == null)
            {
                ControlContextValue = formGroup.ControlContextValue;
            }

            ITagBuilder div = null;
            if (!InlineValue)
            {
                div = context.CreateTagBuilder("div");
                div.AddCssClass("checkbox");
                div.WriteStartTag(writer);
            }

            var lbl = context.CreateTagBuilder("label");
            if (InlineValue)
            {
                lbl.AddCssClass("checkbox-inline");
            }
            lbl.WriteStartTag(writer);

            var input = context.CreateTagBuilder("input");
            input.MergeAttribute("type", "checkbox");
            if (ControlContextValue != null)
            {
                input.MergeAttribute("id", ControlContextValue.Name);
                input.MergeAttribute("name", ControlContextValue.Name);
                input.MergeAttribute("value", "true");
                var controlValue = ControlContextValue.Value;
                if (controlValue != null && bool.Parse(controlValue.ToString()))
                {
                    input.MergeAttribute("checked", "checked");
                }
            }
            if (DisabledValue)
            {
                input.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            input.WriteFullTag(writer);

            writer.Write(" "); // writing space to separate text from checkbox itself

            writer.Write(context.HtmlEncode(TextValue));

            lbl.WriteEndTag(writer);

            if (div != null)
            {
                div.WriteEndTag(writer);
            }
        }

        void IInlineDisplay.SetInline(bool inline)
        {
            InlineValue = inline;
        }

        bool IInlineDisplay.IsInline()
        {
            return InlineValue;
        }
    }
}
