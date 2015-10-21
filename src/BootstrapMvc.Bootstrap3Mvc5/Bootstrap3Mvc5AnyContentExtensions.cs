namespace BootstrapMvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;

    public static class Bootstrap3Mvc5AnyContentExtensions
    {
        public static IItemWriter<Select, SelectContent> Select(this IAnyContentMarker contentHelper, IEnumerable<SelectListItem> items)
        {
            var select = contentHelper.Select();
            select.Item.Items = items.Select(x => SelectListItemToSelectOption(contentHelper.Context, x));
            return select;
        }

        private static SelectOption SelectListItemToSelectOption(IBootstrapContext context, SelectListItem item)
        {
            return context.Helper.CreateWriter<SelectOption, AnyContent>(null).Value(item.Value).Disabled(item.Disabled).Content(item.Text).Item;
        }
    }
}
