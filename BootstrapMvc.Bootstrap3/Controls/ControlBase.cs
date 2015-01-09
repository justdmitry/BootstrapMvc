using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public abstract class ControlBase : Element
    {
        public ControlBase(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public ControlBase Disabled(bool disabled = true)
        {
            MergeAttribute("disabled", disabled ? "disabled" : string.Empty);
            return this;
        }
    }
}
