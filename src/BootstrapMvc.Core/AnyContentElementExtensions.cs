using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AnyContentElementExtensions
    {
        public static IWriter<T> Content<T>(this IWriter<T> target, object value) 
            where T : AnyContentElement
        {
            target.Item.AddContent(value);
            return target;
        }

        public static IWriter<T> Content<T>(this IWriter<T> target, params string[] values) 
            where T : AnyContentElement
        {
            target.Item.AddContent(string.Concat(values));
            return target;
        }

        public static IWriter<T> Content<T>(this IWriter<T> target, params object[] values)
            where T : AnyContentElement
        {
            foreach (var value in values)
            {
                target.Item.AddContent(value);
            }
            return target;
        }
    }
}
