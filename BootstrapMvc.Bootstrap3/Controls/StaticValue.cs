using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class StaticValue : ControlBase
    {
        private IControlContext controlContext;

        public StaticValue(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public StaticValue ControlContext(IControlContext context)
        {
            controlContext = context;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (controlContext == null)
            {
                controlContext = FormGroup.TryGetCurrentControlContext(Context);
            }

            var input = Context.CreateTagBuilder("p");
            input.AddCssClass("form-control-static");
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.Name);
                var value = controlContext.Value;
                if (value != null)
                {
                    input.SetInnerText(value.ToString());
                }
            }

            ApplyCss(input);
            ApplyAttributes(input);

            //input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());
        }
    }
}
