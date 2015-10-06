using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class StaticValue : Element, IFormControl
    {
        private IControlContext controlContext;

        public bool DisabledValue { get; set; }

        public IControlContext ControlContextValue { get; set; }

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
            if (formGroup != null && controlContext == null)
            {
                controlContext = formGroup.ControlContextValue;
            }

            var input = context.CreateTagBuilder("p");
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
            if (DisabledValue)
            {
                // nothing - already read-only :)
            }

            ApplyCss(input);
            ApplyAttributes(input);

            writer.Write(input.GetFullTag());
        }
    }
}
