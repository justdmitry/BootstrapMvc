using BootstrapMvc.Core;
using BootstrapMvc.Panels;

namespace BootstrapMvc
{
    public static class PanelExtensions
    {
        #region Fluent

        public static IWriter2<T, PanelContent> Type<T>(this IWriter2<T, PanelContent> target, PanelType value)
            where T : Panel
        {
            target.Item.TypeValue = value;
            return target;
        }

        public static IWriter2<T, PanelContent> Header<T>(this IWriter2<T, PanelContent> target, PanelHeader value)
            where T : Panel
        {
            target.Item.PanelHeaderValue = value;
            return target;
        }
        
        public static IWriter2<T, PanelContent> Header<T>(this IWriter2<T, PanelContent> target, object value)
            where T : Panel
        {
            var ph = target.Item.PanelHeaderValue = new PanelHeader();
            ph.AddContent(value);
            return target;
        }

        public static IWriter2<T, PanelContent> Header<T>(this IWriter2<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            var ph = target.Item.PanelHeaderValue = new PanelHeader();
            foreach (var value in values)
            {
                ph.AddContent(value);
            }
            return target;
        }

        public static IWriter2<T, PanelContent> Body<T>(this IWriter2<T, PanelContent> target, PanelBody value)
            where T : Panel
        {
            target.Item.PanelBodyValue = value;
            return target;
        }

        public static IWriter2<T, PanelContent> Body<T>(this IWriter2<T, PanelContent> target, object value)
            where T : Panel
        {
            var ph = target.Item.PanelBodyValue = new PanelBody();
            ph.AddContent(value);
            return target;
        }

        public static IWriter2<T, PanelContent> Body<T>(this IWriter2<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            var ph = target.Item.PanelBodyValue = new PanelBody();
            foreach (var value in values)
            {
                ph.AddContent(value);
            }
            return target;
        }

        public static IWriter2<T, PanelContent> Footer<T>(this IWriter2<T, PanelContent> target, PanelFooter value)
            where T : Panel
        {
            target.Item.PanelFooterValue = value;
            return target;
        }

        public static IWriter2<T, PanelContent> Footer<T>(this IWriter2<T, PanelContent> target, object value)
            where T : Panel
        {
            var ph = target.Item.PanelFooterValue = new PanelFooter();
            ph.AddContent(value);
            return target;
        }

        public static IWriter2<T, PanelContent> Footer<T>(this IWriter2<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            var ph = target.Item.PanelFooterValue = new PanelFooter();
            foreach (var value in values)
            {
                ph.AddContent(value);
            }
            return target;
        }

        #endregion

        #region Generating

        public static IWriter2<Panel, PanelContent> Panel(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Panel, PanelContent>();
        }

        public static IWriter2<Panel, PanelContent> Panel(this IAnyContentMarker contentHelper, PanelType type)
        {
            return Panel(contentHelper).Type(type);
        }

        public static PanelContent BeginPanel(this IAnyContentMarker contentHelper)
        {
            return Panel(contentHelper).BeginContent();
        }

        public static PanelContent BeginPanel(this IAnyContentMarker contentHelper, PanelType type)
        {
            return Panel(contentHelper, type).BeginContent();
        }

        public static IWriter2<PanelHeader, AnyContent> PanelHeader(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.Context.CreateWriter<PanelHeader, AnyContent>().Content(value);
        }

        public static IWriter2<PanelHeader, AnyContent> PanelHeader(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.Context.CreateWriter<PanelHeader, AnyContent>().Content(values);
        }

        public static IWriter2<PanelBody, AnyContent> PanelBody(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.Context.CreateWriter<PanelBody, AnyContent>().Content(value);
        }

        public static IWriter2<PanelBody, AnyContent> PanelBody(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.Context.CreateWriter<PanelBody, AnyContent>().Content(values);
        }

        public static IWriter2<PanelFooter, AnyContent> PanelFooter(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.Context.CreateWriter<PanelFooter, AnyContent>().Content(value);
        }

        public static IWriter2<PanelFooter, AnyContent> PanelFooter(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.Context.CreateWriter<PanelFooter, AnyContent>().Content(values);
        }

        #endregion
    }
}
