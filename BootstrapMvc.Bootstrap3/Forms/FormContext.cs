using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormContext : ICloneable
    {
        public FormType FormType { get; set; }

        public GridSize LabelWidth { get; set; }
        
        public GridSize ControlsWidth { get; set; }

        public object Clone()
        {
            return new FormContext()
            {
                FormType = this.FormType,
                LabelWidth = this.LabelWidth,
                ControlsWidth = this.ControlsWidth
            };
        }
    }
}
