namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class LegendExtensions
    {
        #region Generation

        public static IItemWriter<Legend, AnyContent> FormLegend(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Legend, AnyContent>();
        }

        #endregion
    }
}
