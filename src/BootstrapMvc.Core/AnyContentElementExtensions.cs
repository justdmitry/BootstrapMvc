using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AnyContentElementExtensions
    {
        public static IWriter2<T, AnyContent> Content<T>(
            this IWriter2<T, AnyContent> target,
            object value)
            where T : AnyContentElement
        {
            target.Item.AddContent(value);
            return target;
        }

        public static IWriter2<T, AnyContent> Content<T>(
            this IWriter2<T, AnyContent> target,
            params string[] values)
            where T : AnyContentElement
        {
            target.Item.AddContent(string.Concat(values));
            return target;
        }

        public static IWriter2<T, AnyContent> Content<T>(
            this IWriter2<T, AnyContent> target,
            params object[] values)
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
