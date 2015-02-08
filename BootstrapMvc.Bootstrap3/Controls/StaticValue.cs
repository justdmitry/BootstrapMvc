using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class StaticValue : Element, IFormControl
    {
        private IControlContext controlContext;

        public StaticValue(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IControlContext ControlContextValue { get; set; }

        void IFormControl.SetControlContext(IControlContext context)
        {
            ControlContextValue = context;
        }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var formGroup = Context.PeekNearest<FormGroup>();
            if (formGroup != null && controlContext == null)
            {
                controlContext = formGroup.ControlContextValue;
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

            writer.Write(input.GetFullTag());
        }
    }
}
