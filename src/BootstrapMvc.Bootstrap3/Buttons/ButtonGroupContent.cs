namespace BootstrapMvc.Buttons
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Elements;

    public partial class ButtonGroupContent : DisposableContent
    {
        public IItemWriter<Button, AnyContent> Button(IconType iconType)
        {
            var btn = Button();
            btn.Content(Context.Helper.CreateWriter<Icon>(btn.Item).Type(iconType));
            return btn;
        }

        public IItemWriter<Button, AnyContent> Button(IconType iconType, object content)
        {
            return Button(iconType).Content(content);
        }

        public IItemWriter<Button, AnyContent> Button(ButtonType type, IconType iconType)
        {
            return Button(iconType).Type(type);
        }

        public IItemWriter<Button, AnyContent> Button(ButtonType type, IconType iconType, object content)
        {
            return Button(iconType).Type(type).Content(content);
        }
    }
}
