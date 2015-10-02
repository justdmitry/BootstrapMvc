using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static partial class LinkExtensions
    {
        public static T Href<T>(this T target, string value) where T : ILink
        {
            target.SetHref(value);
            return target;
        }
    }
}
