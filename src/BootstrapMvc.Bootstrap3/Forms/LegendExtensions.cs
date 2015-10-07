using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class LegendExtensions
    {
        #region Generation

        public static IWriter2<Legend, AnyContent> FormLegend(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Legend, AnyContent>();
        }

        #endregion
    }
}
