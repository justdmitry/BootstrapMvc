using BootstrapMvc.Grid;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region GridCol

        public static GridCol Size(this GridCol target, GridSize value)
        {
            target.SizeValue = value;
            return target;
        }

        public static GridCol Offset(this GridCol target, GridSize value)
        {
            target.OffsetValue = value;
            return target;
        }

        #endregion
    }
}
