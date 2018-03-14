using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class SelectExtensions
    {
        /* Fluent */

        public static IItemWriter<T, SelectContent> Items<T>(this IItemWriter<T, SelectContent> target, IEnumerable<ISelectItem> items)
            where T : Select
        {
            target.Item.Items = items;
            return target;
        }

        public static IItemWriter<T, SelectContent> Items<T>(this IItemWriter<T, SelectContent> target, params ISelectItem[] items)
            where T : Select
        {
            target.Item.Items = items;
            return target;
        }

        /* Generating */

        public static IItemWriter<Select, SelectContent> Select(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Select, SelectContent>();
        }

        public static IItemWriter<Select, SelectContent> Select<TItem>(this IAnyContentMarker contentHelper, IEnumerable<IItemWriter<TItem>> items)
            where TItem : ISelectItem
        {
            return Select(contentHelper).Items(items.Select(x => (ISelectItem)x.Item));
        }

        public static IItemWriter<Select, SelectContent> Select<TItem>(this IAnyContentMarker contentHelper, params IItemWriter<TItem>[] items)
            where TItem : ISelectItem
        {
            return Select(contentHelper).Items(items.Select(x => (ISelectItem)x.Item));
        }

        public static IItemWriter<Select, SelectContent> Select<TItem, TSource>(this IAnyContentMarker contentHelper, IEnumerable<TSource> source, Func<TSource, object> valueSelector, Func<TSource, string> textSelector)
            where TItem : ISelectItem
        {
            var items = source.Select(x => contentHelper.SelectOption(valueSelector(x), textSelector(x)).Item);
            return Select(contentHelper).Items(items);
        }
    }
}
