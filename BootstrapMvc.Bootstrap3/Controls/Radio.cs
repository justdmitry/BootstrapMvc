using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Radio : Element, IFormControl
    {
        public Radio(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IControlContext ControlContextValue { get; set; }

        public string TextValue { get; set; }

        public bool InlineValue { get; set; }

        public string ValueValue { get; set; }

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

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var formGroup = Context.PeekNearest<FormGroup>();
            if (formGroup != null && ControlContextValue == null)
            {
                ControlContextValue = formGroup.ControlContextValue;
            }

            ITagBuilder div = null;
            if (!InlineValue)
            {
                div = Context.CreateTagBuilder("div");
                div.AddCssClass("radio");
                writer.Write(div.GetStartTag());
            }

            var lbl = Context.CreateTagBuilder("label");
            if (InlineValue)
            {
                lbl.AddCssClass("radio-inline");
            }
            writer.Write(lbl.GetStartTag());

            var input = Context.CreateTagBuilder("input");
            input.MergeAttribute("type", "radio");
            if (ControlContextValue != null)
            {
                input.MergeAttribute("id", ControlContextValue.Name);
                input.MergeAttribute("name", ControlContextValue.Name);
                input.MergeAttribute("value", ValueValue);
                var controlValue = ControlContextValue.Value;
                if (controlValue != null && ValueValue.Equals(controlValue.ToString()))
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

            writer.Write(input.GetFullTag());

            writer.Write(" "); // writing space to separate text from radio itself

            writer.Write(Context.HtmlEncode(TextValue));

            writer.Write(lbl.GetEndTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
