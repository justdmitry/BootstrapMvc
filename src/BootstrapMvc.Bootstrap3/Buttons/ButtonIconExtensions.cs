namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ButtonIconExtensions
    {
        #region Generation

        private static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Button, AnyContent>();
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType)
        {
            return Button(contentHelper).Content(contentHelper.CreateWriter<Icon>().Type(iconType));
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType, object content)
        {
            return Button(contentHelper).Content(contentHelper.CreateWriter<Icon>().Type(iconType), content);
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType)
        {
            return Button(contentHelper).Type(type).Content(contentHelper.CreateWriter<Icon>().Type(iconType));
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType, object content)
        {
            return Button(contentHelper).Type(type).Content(contentHelper.CreateWriter<Icon>().Type(iconType), content);
        }

        #endregion
    }
}
