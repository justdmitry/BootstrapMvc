namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static class ColorExtensions
    {
        public static IItemWriter<T> TextColor<T>(this IItemWriter<T> target, Color9 color)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass("text-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T, TContent> TextColor<T, TContent>(this IItemWriter<T, TContent> target, Color9 color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("text-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T> TextMuted<T>(this IItemWriter<T> target)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass("text-muted");
            return target;
        }

        public static IItemWriter<T, TContent> TextMuted<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("text-muted");
            return target;
        }

        public static IItemWriter<T> BackgroundColor<T>(this IItemWriter<T> target, Color9 color)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass("bg-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T, TContent> BackgroundColor<T, TContent>(this IItemWriter<T, TContent> target, Color9 color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("bg-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T> Color<T>(this IItemWriter<T> target, Color9 textColor, Color9 backgroundColor)
            where T : Element, IWritableItem
        {
            target.TextColor(textColor).BackgroundColor(backgroundColor);
            return target;
        }

        public static IItemWriter<T, TContent> Color<T, TContent>(this IItemWriter<T, TContent> target, Color9 textColor, Color9 backgroundColor)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.TextColor(textColor).BackgroundColor(backgroundColor);
            return target;
        }
    }
}
