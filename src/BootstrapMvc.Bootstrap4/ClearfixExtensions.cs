namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ClearfixExtensions
    {
        public static IItemWriter<T> Clearfix<T>(this IItemWriter<T> target) 
            where T : Element
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }

        public static IItemWriter<T, TContent> Clearfix<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("clearfix");
            return target;
        }        
    }
}
