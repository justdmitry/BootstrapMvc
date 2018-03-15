namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Buttons;

    public static partial class ButtonExtensions
    {
        public static IItemWriter<T, AnyContent> BlockSize<T>(this IItemWriter<T, AnyContent> target, bool value = true) where T : Button
        {
            target.Item.BlockSize = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> Outline<T>(this IItemWriter<T, AnyContent> target, bool value = true) where T : Button
        {
            target.Item.Outline = value;
            return target;
        }

        private static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Button, AnyContent>();
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, object content)
        {
            return Button(contentHelper).Content(content);
        }

        public static IItemWriter<Button, AnyContent> Button(this IAnyContentMarker contentHelper, Color8 type, params object[] contents)
        {
            return Button(contentHelper).Type(type).Content(contents);
        }
    }
}
