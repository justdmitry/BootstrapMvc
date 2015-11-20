namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class HiddenTextExtensions
    {
        public static IItemWriter<T> HiddenText<T>(this IItemWriter<T> target) 
            where T : Element
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }

        public static IItemWriter<T, TContent> HiddenText<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("text-hide");
            return target;
        }        
    }
}
