using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class MarkersExtensions
    {
        public static IWriter<T> Placeholder<T>(this IWriter<T> target, string placeholder) 
            where T : Element, IPlaceholderTarget
        {
            target.Attribute("placeholder", placeholder);
            return target;
        }

        public static IWriter2<T, TContent> Placeholder<T, TContent>(this IWriter2<T, TContent> target, string placeholder)
            where T : ContentElement<TContent>, IPlaceholderTarget
            where TContent: DisposableContent
        {
            target.Attribute("placeholder", placeholder);
            return target;
        }
    }
}
