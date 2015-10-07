using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuExtensions
    {
        public static IWriter2<T, DropdownMenuContent> RightAlign<T>(this IWriter2<T, DropdownMenuContent> target, bool value = true) 
            where T : DropdownMenu
        {
            target.Item.RightAlignValue = value;
            return target;
        }

        #region Generating

        public static IWriter2<DropdownMenu, DropdownMenuContent> DropdownMenu(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<DropdownMenu, DropdownMenuContent>();
        }

        #endregion
    }
}
