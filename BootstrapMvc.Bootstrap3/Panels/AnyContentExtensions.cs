using BootstrapMvc.Core;
using BootstrapMvc.Panels;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        public static Panel Panel(this IAnyContentMarker contentHelper)
        {
            return new Panel(contentHelper.Context);
        }

        public static Panel Panel(this IAnyContentMarker contentHelper, PanelType type)
        {
            return new Panel(contentHelper.Context).Type(type);
        }

        public static PanelContent BeginPanel(this IAnyContentMarker contentHelper)
        {
            return Panel(contentHelper).BeginContent();
        }

        public static PanelContent BeginPanel(this IAnyContentMarker contentHelper, PanelType type)
        {
            return Panel(contentHelper, type).BeginContent();
        }

        public static PanelHeader PanelHeader(this IAnyContentMarker contentHelper, object value)
        {
            return new PanelHeader(contentHelper.Context).Content(value);
        }

        public static PanelHeader PanelHeader(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new PanelHeader(contentHelper.Context).Content(values);
        }

        public static PanelBody PanelBody(this IAnyContentMarker contentHelper, object value)
        {
            return new PanelBody(contentHelper.Context).Content(value);
        }

        public static PanelBody PanelBody(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new PanelBody(contentHelper.Context).Content(values);
        }

        public static PanelFooter PanelFooter(this IAnyContentMarker contentHelper, object value)
        {
            return new PanelFooter(contentHelper.Context).Content(value);
        }

        public static PanelFooter PanelFooter(this IAnyContentMarker contentHelper, params object[] values)
        {
            return new PanelFooter(contentHelper.Context).Content(values);
        }
    }
}
