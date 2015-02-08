using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuItemLinkFluent
    {
        public static T Disabled<T>(this T target, bool value = true) where T : DropdownMenuItemLink
        {
            target.DisabledValue = value;
            return target;
        }
    }
}
