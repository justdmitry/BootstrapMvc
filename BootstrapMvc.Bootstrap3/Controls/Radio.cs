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

        void IFormControl.SetControlContext(IControlContext context)
        {
            ControlContextValue = context;
        }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var formGroup = Context.PeekNearest<FormGroup>();
            if (formGroup != null && ControlContextValue == null)
            {
                ControlContextValue = formGroup.ControlContextValue;
            }

            var lbl = Context.CreateTagBuilder("label");

            if (InlineValue && formGroup != null && formGroup.WithStackedRadioValue)
            {
                throw new InvalidOperationException("Can't generate 'inline' radio in 'WithStackedRadio' group");
            }
            if (!InlineValue && formGroup != null && !formGroup.WithStackedRadioValue)
            {
                throw new InvalidOperationException("Can't generate 'stacked' radio without 'WithStackedRadio' in group");
            }
            lbl.AddCssClass(InlineValue ? "radio-inline" : "radio");

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

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());

            writer.Write(Context.HtmlEncode(TextValue));

            writer.Write(lbl.GetEndTag());
        }
    }
}
