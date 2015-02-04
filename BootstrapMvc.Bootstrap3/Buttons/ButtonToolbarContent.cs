using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonToolbarContent : DisposableContext
    {
        public ButtonToolbarContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public ButtonGroup ButtonGroup()
        {
            return new ButtonGroup(Context);
        }

        public ButtonGroup ButtonGroup(ButtonSize size)
        {
            return new ButtonGroup(Context).Size(size);
        }

        public ButtonGroupContent BeginButtonGroup()
        {
            return new ButtonGroup(Context).BeginContent();
        }

        public ButtonGroupContent BeginButtonGroup(ButtonSize size)
        {
            return new ButtonGroup(Context).Size(size).BeginContent();
        }
    }
}
