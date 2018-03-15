namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static class SpacingExtensions2
    {
        /*
         * All
         */
        public static IItemWriter<T> Padding<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.All, value);
        }

        public static IItemWriter<T, TContent> Padding<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.All, value);
        }

        public static IItemWriter<T> Margin<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.All, value);
        }

        public static IItemWriter<T, TContent> Margin<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.All, value);
        }

        /*
         * Top
         */
        public static IItemWriter<T> PaddingTop<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.Top, value);
        }

        public static IItemWriter<T, TContent> PaddingTop<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.Top, value);
        }

        public static IItemWriter<T> MarginTop<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.Top, value);
        }

        public static IItemWriter<T, TContent> MarginTop<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.Top, value);
        }

        /*
         * Right
         */
        public static IItemWriter<T> PaddingRight<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.Right, value);
        }

        public static IItemWriter<T, TContent> PaddingRight<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.Right, value);
        }

        public static IItemWriter<T> MarginRight<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.Right, value);
        }

        public static IItemWriter<T, TContent> MarginRight<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.Right, value);
        }

        /*
         * Bottom
         */
        public static IItemWriter<T> PaddingBottom<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.Bottom, value);
        }

        public static IItemWriter<T, TContent> PaddingBottom<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.Bottom, value);
        }

        public static IItemWriter<T> MarginBottom<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.Bottom, value);
        }

        public static IItemWriter<T, TContent> MarginBottom<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.Bottom, value);
        }

        /*
         * Left
         */
        public static IItemWriter<T> PaddingLeft<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.Left, value);
        }

        public static IItemWriter<T, TContent> PaddingLeft<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.Left, value);
        }

        public static IItemWriter<T> MarginLeft<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.Left, value);
        }

        public static IItemWriter<T, TContent> MarginLeft<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.Left, value);
        }

        /*
         * LeftRight
         */
        public static IItemWriter<T> PaddingLeftRight<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.LeftRight, value);
        }

        public static IItemWriter<T, TContent> PaddingLeftRight<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.LeftRight, value);
        }

        public static IItemWriter<T> MarginLeftRight<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.LeftRight, value);
        }

        public static IItemWriter<T, TContent> MarginLeftRight<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.LeftRight, value);
        }

        /*
         * TopBottom
         */
        public static IItemWriter<T> PaddingTopBottom<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Padding(SpacingSide.TopBottom, value);
        }

        public static IItemWriter<T, TContent> PaddingTopBottom<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Padding(SpacingSide.TopBottom, value);
        }

        public static IItemWriter<T> MarginTopBottom<T>(this IItemWriter<T> target, byte value)
            where T : Element, IWritableItem
        {
            return target.Margin(SpacingSide.TopBottom, value);
        }

        public static IItemWriter<T, TContent> MarginTopBottom<T, TContent>(this IItemWriter<T, TContent> target, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            return target.Margin(SpacingSide.TopBottom, value);
        }
    }
}
