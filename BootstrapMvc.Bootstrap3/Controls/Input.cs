using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Input : Element, IFormControl, IPlaceholderTarget
    {
        private IControlContext controlContext;

        private InputType type = InputType.Default;

        public Input(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }
        
        public void SetControlContext(IControlContext context)
        {
            controlContext = context;
        }

        #region Fluent

        public Input Type(InputType type)
        {
            this.type = type;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (controlContext == null)
            {
                controlContext = FormGroup.TryGetCurrentControlContext(Context);
            }

            var input = Context.CreateTagBuilder("input");
            input.AddCssClass("form-control");
            if (type != InputType.Text)
            {
                input.MergeAttribute("type", type.ToType());
            }
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.Name);
                input.MergeAttribute("name", controlContext.Name);
                var value = controlContext.Value;
                if (value != null)
                {
                    input.MergeAttribute("value", value.ToString());
                }
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());
        }
    }
}
