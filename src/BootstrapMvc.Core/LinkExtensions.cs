using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class LinkExtensions
    {
        public static IWriter<T> Href<T>(this IWriter<T> target, string value) where T : ILink, IWritable
        {
            target.Item.SetHref(value);
            return target;
        }

        public static IWriter2<T, TContent> Href<T, TContent>(this IWriter2<T, TContent> target, string value)
            where T : ContentElement<TContent>, ILink, IWritable
            where TContent : DisposableContent
        {
            target.Item.SetHref(value);
            return target;
        }
    }
}
