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

        public static IWriter2<T, SelectOptGroupContent> Label<T>(this IWriter2<T, SelectOptGroupContent> target, string value)
            where T : SelectOptGroup
        {
            target.Item.LabelValue = value;
            return target;
        }

        public static IWriter2<T, SelectOptGroupContent> Items<T>(this IWriter2<T, SelectOptGroupContent> target, IEnumerable<ISelectItem> items)
            where T : SelectOptGroup
        {
            target.Item.ItemsValue = items.ToArray();
            return target;
        }

        public static IWriter2<T, SelectOptGroupContent> Items<T>(this IWriter2<T, SelectOptGroupContent> target, params ISelectItem[] items)
            where T : SelectOptGroup
        {
            target.Item.ItemsValue = items;
            return target;
        }

        #endregion

        public static IWriter2<SelectOptGroup, SelectOptGroupContent> SelectOptGroup(this IAnyContentMarker contentHelper, string label)
        {
            return contentHelper.Context.CreateWriter<SelectOptGroup, SelectOptGroupContent>().Label(label);
        }

        public static IWriter2<SelectOptGroup, SelectOptGroupContent> SelectOptGroup<TItem>(this IAnyContentMarker contentHelper, string label, IEnumerable<IWriter<TItem>> items)
            where TItem: ISelectItem
        {
            return SelectOptGroup(contentHelper, label).Items(items.Select(x => (ISelectItem)x.Item));
        }

        public static IWriter2<SelectOptGroup, SelectOptGroupContent> SelectOptGroup<TItem>(this IAnyContentMarker contentHelper, string label, params IWriter<TItem>[] items)
            where TItem : ISelectItem
        {
            return SelectOptGroup(contentHelper, label).Items(items.Select(x => (ISelectItem)x.Item));
        }
    }
}
