using BootstrapMvc.Grid;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region IGridSizable

        public static T Size<T>(this T target, GridSize value) where T : IGridSizable
        {
            target.SetSize(value);
            return target;
        }

        public static T Size<T>(this T target, byte xs, byte sm, byte md, byte lg) where T : IGridSizable
        {
            target.SetSize(new GridSize(xs, sm, md, lg));
            return target;
        }

        #endregion

        #region GridCol

        public static GridCol Offset(this GridCol target, GridSize value)
        {
            target.OffsetValue = value;
            return target;
        }

        #endregion
    }
}
