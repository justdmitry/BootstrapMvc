using BootstrapMvc.Panels;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        public static Panel Type(this Panel target, PanelType value)
        {
            target.TypeValue = value;
            return target;
        }
    }
}
