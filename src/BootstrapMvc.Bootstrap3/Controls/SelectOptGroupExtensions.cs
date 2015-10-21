using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class SelectOptGroupExtensions
    {
        #region Fluent

        public static IItemWriter<T, SelectOptGroupContent> Label<T>(this IItemWriter<T, SelectOptGroupContent> target, string value)
            where T : SelectOptGroup
        {
            target.Item.Label = value;
            return target;
        }

        public static IItemWriter<T, SelectOptGroupContent> Items<T>(this IItemWriter<T, SelectOptGroupContent> target, IEnumerable<ISelectItem> items)
            where T : SelectOptGroup
        {
            target.Item.ItemsValue = items.ToArray();
            return target;
        }

        public static IItemWriter<T, SelectOptGroupContent> Items<T>(this IItemWriter<T, SelectOptGroupContent> target, params ISelectItem[] items)
            where T : SelectOptGroup
        {
            target.Item.ItemsValue = items;
            return target;
        }

        #endregion

        public static IItemWriter<SelectOptGroup, SelectOptGroupContent> SelectOptGroup(this IAnyContentMarker contentHelper, string label)
        {
            return contentHelper.CreateWriter<SelectOptGroup, SelectOptGroupContent>().Label(label);
        }

        public static IItemWriter<SelectOptGroup, SelectOptGroupContent> SelectOptGroup<TItem>(this IAnyContentMarker contentHelper, string label, IEnumerable<IItemWriter<TItem>> items)
            where TItem: ISelectItem
        {
            return SelectOptGroup(contentHelper, label).Items(items.Select(x => (ISelectItem)x.Item));
        }

        public static IItemWriter<SelectOptGroup, SelectOptGroupContent> SelectOptGroup<TItem>(this IAnyContentMarker contentHelper, string label, params IItemWriter<TItem>[] items)
            where TItem : ISelectItem
        {
            return SelectOptGroup(contentHelper, label).Items(items.Select(x => (ISelectItem)x.Item));
        }
    }
}
