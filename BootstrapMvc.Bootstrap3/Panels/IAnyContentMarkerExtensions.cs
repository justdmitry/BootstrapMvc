using BootstrapMvc.Core;
using BootstrapMvc.Panels;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
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
            var obj = new PanelHeader(contentHelper.Context);
            obj.Content(value);
            return obj;
      }

        public static PanelHeader PanelHeader(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new PanelHeader(contentHelper.Context);
            obj.Content(values);
            return obj;
        }

        public static PanelBody PanelBody(this IAnyContentMarker contentHelper, object value)
        {
            var obj = new PanelBody(contentHelper.Context);
            obj.Content(value);
            return obj;
        }

        public static PanelBody PanelBody(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new PanelBody(contentHelper.Context);
            obj.Content(values);
            return obj;
        }

        public static PanelFooter PanelFooter(this IAnyContentMarker contentHelper, object value)
        {
            var obj = new PanelFooter(contentHelper.Context);
            obj.Content(value);
            return obj;
        }

        public static PanelFooter PanelFooter(this IAnyContentMarker contentHelper, params object[] values)
        {
            var obj = new PanelFooter(contentHelper.Context);
            obj.Content(values);
            return obj;
        }
    }
}
