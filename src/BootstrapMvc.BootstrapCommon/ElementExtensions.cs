namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static partial class ElementExtensions
    {
        public static IItemWriter<T> Id<T>(this IItemWriter<T> target, string id)
            where T : Element
        {
            target.Item.AddAttribute("id", id);
            return target;
        }

        public static IItemWriter<T, TContent> Id<T, TContent>(this IItemWriter<T, TContent> target, string id)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddAttribute("id", id);
            return target;
        }
    }
}
