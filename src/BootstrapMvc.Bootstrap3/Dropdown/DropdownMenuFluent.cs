using BootstrapMvc.Dropdown;

namespace BootstrapMvc
{
    public static class DropdownMenuFluent
    {
        public static T RightAlign<T>(this T target, bool value = true) where T : DropdownMenu
        {
            target.RightAlignValue = value;
            return target;
        }
    }
}