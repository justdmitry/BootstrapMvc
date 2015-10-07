using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class SelectExtensions
    {
        #region Select

        public static IWriter2<T, SelectContent> Items<T>(this IWriter2<T, SelectContent> target, IEnumerable<ISelectItem> items)
            where T : Select
        {
            target.Item.ItemsValue = items;
            return target;
        }

        public static IWriter2<T, SelectContent> Items<T>(this IWriter2<T, SelectContent> target, params ISelectItem[] items)
            where T : Select
        {
            target.Item.ItemsValue = items;
            return target;
        }

        #endregion

        #region Generating

        public static IWriter2<Select, SelectContent> Select(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Select, SelectContent>();
        }

        public static IWriter2<Select, SelectContent> Select<TItem>(this IAnyContentMarker contentHelper, IEnumerable<IWriter<TItem>> items)
            where TItem : ISelectItem
        {
            return Select(contentHelper).Items(items.Select(x => (ISelectItem)x.Item));
        }

        public static IWriter2<Select, SelectContent> Select<TItem>(this IAnyContentMarker contentHelper, params IWriter<TItem>[] items)
            where TItem : ISelectItem
        {
            return Select(contentHelper).Items(items.Select(x => (ISelectItem)x.Item));
        }

        #endregion
    }
}
