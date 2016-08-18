namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Buttons;
    using BootstrapMvc.Elements;

    public static partial class ButtonExtensions
    {
        #region Generation

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType)
        {
            return contentHelper.CreateWriter<Button, AnyContent>().Content(contentHelper.CreateWriter<Icon>().Type(iconType));
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType, object content)
        {
            return contentHelper.CreateWriter<Button, AnyContent>().Content(contentHelper.CreateWriter<Icon>().Type(iconType), content);
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType)
        {
            return contentHelper.CreateWriter<Button, AnyContent>().Type(type).Content(contentHelper.CreateWriter<Icon>().Type(iconType));
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType, object content)
        {
            return contentHelper.CreateWriter<Button, AnyContent>().Type(type).Content(contentHelper.CreateWriter<Icon>().Type(iconType), content);
        }

        #endregion
    }
}
