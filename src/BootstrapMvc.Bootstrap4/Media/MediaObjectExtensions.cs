namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class MediaObjectExtensions
    {
        #region Fluid

        public static IItemWriter<T, AnyContent> Align<T>(this IItemWriter<T, AnyContent> target, MediaObjectAlign value)
            where T : MediaObject
        {
            target.Item.Align = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> AlignRight<T>(this IItemWriter<T, AnyContent> target)
            where T : MediaObject
        {
            return target.Align(MediaObjectAlign.Right);
        }

        public static IItemWriter<T, AnyContent> AlignLeft<T>(this IItemWriter<T, AnyContent> target)
            where T : MediaObject
        {
            return target.Align(MediaObjectAlign.Left);
        }

        public static IItemWriter<T, AnyContent> VerticalAlign<T>(this IItemWriter<T, AnyContent> target, MediaObjectVerticalAlign value)
            where T : MediaObject
        {
            target.Item.VerticalAlign = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> VerticalAlignTop<T>(this IItemWriter<T, AnyContent> target)
            where T : MediaObject
        {
            return target.VerticalAlign(MediaObjectVerticalAlign.Top);
        }

        public static IItemWriter<T, AnyContent> VerticalAlignMiddle<T>(this IItemWriter<T, AnyContent> target)
            where T : MediaObject
        {
            return target.VerticalAlign(MediaObjectVerticalAlign.Middle);
        }

        public static IItemWriter<T, AnyContent> VerticalAlignBottom<T>(this IItemWriter<T, AnyContent> target)
            where T : MediaObject
        {
            return target.VerticalAlign(MediaObjectVerticalAlign.Bottom);
        }

        #endregion
    }
}
