using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Checkbox : ControlBase
    {
        private IControlContext controlContext;

        private string text;

        private bool inline;

        public Checkbox(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Checkbox ControlContext(IControlContext context)
        {
            controlContext = context;
            return this;
        }

        public Checkbox Text(string text)
        {
            this.text = text;
            return this;
        }

        public Checkbox Inline(bool inline = true)
        {
            this.inline = inline;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (controlContext == null)
            {
                controlContext = FormGroup.TryGetCurrentControlContext(Context);
            }

            var lbl = Context.CreateTagBuilder("label");
            lbl.AddCssClass(inline ? "checkbox-inline" : "checkbox");

            writer.Write(lbl.GetStartTag());

            var input = Context.CreateTagBuilder("input");
            input.MergeAttribute("type", "checkbox");
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.Name);
                input.MergeAttribute("name", controlContext.Name);
                input.MergeAttribute("value", "true");
                var controlValue = controlContext.Value;
                if (controlValue != null && (bool)controlValue)
                {
                    input.MergeAttribute("checked", "checked");
                }
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());

            writer.Write(Context.HtmlEncode(text));

            writer.Write(lbl.GetEndTag());
        }
    }
}
