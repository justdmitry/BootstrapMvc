using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ILinkExtensions
    {
        public static IItemWriter<T> Href<T>(this IItemWriter<T> target, string value) where T : ILink, IWritableItem
        {
            target.Item.Href = value;
            return target;
        }

        public static IItemWriter<T, TContent> Href<T, TContent>(this IItemWriter<T, TContent> target, string value)
            where T : ContentElement<TContent>, ILink, IWritable
            where TContent : DisposableContent
        {
            target.Item.Href = value;
            return target;
        }
    }
}
