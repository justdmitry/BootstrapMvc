using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupContext : ICloneable
    {
        public IControlContext ControlContext { get; set; }

        public bool WithStackedCheckbox { get; set; }

        public bool WithStackedRadio { get; set; }

        public bool WithSizedControls { get; set; }

        public object Clone()
        {
            return new FormGroupContext()
            {
                ControlContext = this.ControlContext,
                WithStackedCheckbox = this.WithStackedCheckbox,
                WithStackedRadio = this.WithStackedRadio,
                WithSizedControls = this.WithSizedControls
            };
        }
    }
}
