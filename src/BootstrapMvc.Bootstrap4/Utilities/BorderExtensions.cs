namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static class BorderExtensions
    {
        public static IItemWriter<T> Border<T>(this IItemWriter<T> target, BorderType type)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass(type.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> Border<T, TContent>(this IItemWriter<T, TContent> target, BorderType type)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(type.ToCssClass());
            return target;
        }

        public static IItemWriter<T> Border<T>(this IItemWriter<T> target, BorderType type, Color9 color)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass(type.ToCssClass());
            target.Item.AddCssClass("border-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T, TContent> Border<T, TContent>(this IItemWriter<T, TContent> target, BorderType type, Color9 color)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(type.ToCssClass());
            target.Item.AddCssClass("border-" + color.ToCssClassSubstring());
            return target;
        }

        public static IItemWriter<T> Border<T>(this IItemWriter<T> target, BorderType type, Color9 color, BorderRadius radius)
            where T : Element, IWritableItem
        {
            target.Item.AddCssClass(type.ToCssClass());
            target.Item.AddCssClass("border-" + color.ToCssClassSubstring());
            target.Item.AddCssClass(radius.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> Border<T, TContent>(this IItemWriter<T, TContent> target, BorderType type, Color9 color, BorderRadius radius)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(type.ToCssClass());
            target.Item.AddCssClass("border-" + color.ToCssClassSubstring());
            target.Item.AddCssClass(radius.ToCssClass());
            return target;
        }
    }
}
