using System;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        public static DropdownMenu DropdownMenu(this IAnyContentMarker contentHelper)
        {
            return new DropdownMenu(contentHelper.Context);
        }
    }
}
