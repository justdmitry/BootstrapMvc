using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;
using Microsoft.AspNet.Mvc.Rendering;

namespace BootstrapMvc
{
    public static class AnyContentExtensions
    {
        public static Select Select(this IAnyContentMarker contentHelper, IEnumerable<SelectListItem> items)
        {
            var res = new Select(contentHelper.Context);
            res.Items(items.Select(x => SelectListItemToSelectOption(contentHelper.Context, x)));
            return res;
        }

        private static SelectOption SelectListItemToSelectOption(IBootstrapContext context, SelectListItem item)
        {
            var option = new SelectOption(context);
            option.Value(item.Value).Disabled(item.Disabled).Content(item.Text);
            return option;
        }
    }
}
