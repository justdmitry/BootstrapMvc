namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class VisibilityExtensions
    {
        public static IItemWriter<T> Visibility<T>(this IItemWriter<T> target, VisibilityType value) 
            where T : Element
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }

        public static IItemWriter<T, TContent> Visibility<T, TContent>(this IItemWriter<T, TContent> target, VisibilityType value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass(value.ToCssClass());
            return target;
        }
    }
}
