namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ButtonGroupContentExtensions
    {
        public static IItemWriter<Button, AnyContent> Button(this ButtonGroupContent buttonGroup, IconType iconType)
        {
            var btn = buttonGroup.Button();
            btn.Content(btn.Helper.CreateWriter<Icon>(btn.Item).Type(iconType));
            return btn;
        }

        public static IItemWriter<Button, AnyContent> Button(this ButtonGroupContent buttonGroup, IconType iconType, object content)
        {
            return Button(buttonGroup, iconType).Content(content); 
        }

        public static IItemWriter<Button, AnyContent> Button(this ButtonGroupContent buttonGroup, ButtonType type, IconType iconType)
        {
            return Button(buttonGroup, iconType).Type(type);
        }

        public static IItemWriter<Button, AnyContent> Button(this ButtonGroupContent buttonGroup, ButtonType type, IconType iconType, object content)
        {
            return Button(buttonGroup, iconType).Type(type).Content(content);
        }
    }
}
