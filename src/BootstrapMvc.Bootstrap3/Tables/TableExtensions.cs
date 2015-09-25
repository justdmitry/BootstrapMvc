using System;
using System.Globalization;
using BootstrapMvc.Tables;

namespace BootstrapMvc
{
    public static class TableExtensions
    {
        public static T ColSpan<T>(this T element, int colspan) where T : TableCell
        {
            element.AddAttribute("colspan", colspan.ToString(CultureInfo.InvariantCulture));
            return element;
        }
    }
}
