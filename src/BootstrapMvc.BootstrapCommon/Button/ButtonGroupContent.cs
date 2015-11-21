namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class ButtonGroupContent : DisposableContent
    {
        public ButtonGroupContent(IBootstrapContext context, ButtonGroup parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private ButtonGroup Parent { get; set; }

        #region ButtonGroup

        public IItemWriter<ButtonGroup, ButtonGroupContent> ButtonGroup()
        {
            return Context.Helper.CreateWriter<ButtonGroup, ButtonGroupContent>(Parent);
        }

        public ButtonGroupContent BeginButtonGroup()
        {
            return ButtonGroup().BeginContent();
        }

        #endregion

        #region Button

        public IItemWriter<Button, AnyContent> Button()
        {
            return Context.Helper.CreateWriter<Button, AnyContent>(Parent);
        }

        public IItemWriter<Button, AnyContent> Button(object content)
        {
            return Button().Content(content);
        }

        public IItemWriter<Button, AnyContent> Button(ButtonType type, object content)
        {
            return Button().Type(type).Content(content);
        }

        public IItemWriter<Button, AnyContent> Button(ButtonType type, params object[] contents)
        {
            return Button().Type(type).Content(contents);
        }

        #endregion
    }
}
