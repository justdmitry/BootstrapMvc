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
    }
}
