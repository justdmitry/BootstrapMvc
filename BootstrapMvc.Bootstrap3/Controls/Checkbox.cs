using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Checkbox : Element, IFormControl
    {
        public Checkbox(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IControlContext ControlContextValue { get; set; }

        public string TextValue { get; set; }

        public bool InlineValue { get; set; }

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

            ITagBuilder div = null;
            if (!InlineValue)
            {
                div = Context.CreateTagBuilder("div");
                div.AddCssClass("checkbox");
                writer.Write(div.GetStartTag());
            }

            var lbl = Context.CreateTagBuilder("label");
            if (InlineValue)
            {
                lbl.AddCssClass("checkbox-inline");
            }
            writer.Write(lbl.GetStartTag());

            var input = Context.CreateTagBuilder("input");
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

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());

            writer.Write(" "); // writing space to separate text from checkbox itself

            writer.Write(Context.HtmlEncode(TextValue));

            writer.Write(lbl.GetEndTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
