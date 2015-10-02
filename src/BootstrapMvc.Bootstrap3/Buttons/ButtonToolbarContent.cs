using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonToolbarContent : DisposableContent
    {
        public ButtonToolbarContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<ButtonGroup, ButtonGroupContent> ButtonGroup()
        {
            return Context.CreateWriter<ButtonGroup, ButtonGroupContent>();
        }

        public IWriter2<ButtonGroup, ButtonGroupContent> ButtonGroup(ButtonSize size)
        {
            return Context.CreateWriter<ButtonGroup, ButtonGroupContent>().Size(size);
        }

        public ButtonGroupContent BeginButtonGroup()
        {
            return ButtonGroup().BeginContent();
        }

        public ButtonGroupContent BeginButtonGroup(ButtonSize size)
        {
            return ButtonGroup().Size(size).BeginContent();
        }
    }
}
