using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class SelectOption : AnyContentElement, ISelectItem
    {
        private object value;
        private bool disabled;

        public SelectOption(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public SelectOption Value(object value)
        {
            this.value = value;
            return this;
        }

        public SelectOption Disabled(bool disabled = true)
        {
            this.disabled = disabled;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("option");

            if (value != null)
            {
                tb.MergeAttribute("value", value.ToString());
            }
            if (disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            var controlContext = FormGroup.TryGetCurrentControlContext(Context);
            if (controlContext != null && controlContext.Value != null && controlContext.Value == value)
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
