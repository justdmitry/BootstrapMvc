using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AnyContentElementExtensions
    {
        public static T Content<T>(this T target, object value) where T : AnyContentElement
        {
            target.AddContent(value);
            return target;
        }

        public static T Content<T>(this T target, params string[] values) where T : AnyContentElement
        {
            target.AddContent(string.Concat(values));
            return target;
        }

        public static T Content<T>(this T target, params object[] values) where T : AnyContentElement
        {
            foreach (var value in values)
            {
                target.AddContent(value);
            }
            return target;
        }
    }
}
