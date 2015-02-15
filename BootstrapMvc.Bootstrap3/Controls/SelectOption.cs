using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class SelectOption : AnyContentElement, ISelectItem
    {
        public SelectOption(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public object ValueValue { get; set; }

        public bool DisabledValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("option");

            if (ValueValue != null)
            {
                tb.MergeAttribute("value", ValueValue.ToString());
            }
            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            var formGroup = Context.PeekNearest<FormGroup>();
            var controlContext = formGroup == null ? null : formGroup.ControlContextValue;
            if (controlContext != null && controlContext.Value != null && ValueValue != null && ValueValue.ToString().Equals(controlContext.Value.ToString()))
            {
                tb.MergeAttribute("selected", "selected");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
