using System;
using BootstrapMvc.Core;
using BootstrapMvc.Buttons;
using BootstrapMvc.Elements;

namespace BootstrapMvc
{
    public static class ButtonExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Type<T>(this IWriter2<T, AnyContent> target, ButtonType value) where T : Button
        {
            target.Item.TypeValue = value;
            return target;
        }

        public static IWriter2<T, AnyContent> BlockSize<T>(this IWriter2<T, AnyContent> target, bool value = true) where T : Button
        {
            target.Item.BlockSizeValue = value;
            return target;
        }

        //public static IWriter2<T, AnyContent> Disabled<T>(this IWriter2<T, AnyContent> target, bool value = true) where T : Button
        //{
        //    target.Item.DisabledValue = value;
        //    return target;
        //}

        #endregion

        #region Generation

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Content(content);
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, object content)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Type(type).Content(content);
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Type(type).Content(contents);
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Content(contentHelper.Context.CreateWriter<Icon>().Type(iconType));
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, IconType iconType, object content)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Content(contentHelper.Context.CreateWriter<Icon>().Type(iconType), content);
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Type(type).Content(contentHelper.Context.CreateWriter<Icon>().Type(iconType));
        }

        public static IWriter2<Button, AnyContent> Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType, object content)
        {
            return contentHelper.Context.CreateWriter<Button, AnyContent>().Type(type).Content(contentHelper.Context.CreateWriter<Icon>().Type(iconType), content);
        }

        #endregion
    }
}
