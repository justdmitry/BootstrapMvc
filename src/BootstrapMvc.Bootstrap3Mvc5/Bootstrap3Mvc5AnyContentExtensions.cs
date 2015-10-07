using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class Bootstrap3Mvc5AnyContentExtensions
    {
        public static IWriter2<Select, SelectContent> Select(this IAnyContentMarker contentHelper, IEnumerable<SelectListItem> items)
        {
            var vals = items.Select(x => SelectListItemToSelectOption(contentHelper.Context, x));
            return contentHelper.Select(vals);
        }

        private static IWriter2<SelectOption, AnyContent> SelectListItemToSelectOption(IBootstrapContext context, SelectListItem item)
        {
            return context.CreateWriter<SelectOption, AnyContent>().Value(item.Value).Disabled(item.Disabled).Content(item.Text);
        }
    }
}
