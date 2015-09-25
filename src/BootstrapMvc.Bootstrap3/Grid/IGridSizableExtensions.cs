using System;

namespace BootstrapMvc
{
    public static class IGridSizableExtensions
    {
        public static T Size<T>(T target, GridSize value) where T : IGridSizable
        {
            target.SetSize(value);
            return target;
        }
    }
}
