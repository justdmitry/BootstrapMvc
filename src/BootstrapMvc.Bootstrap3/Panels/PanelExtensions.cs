namespace BootstrapMvc
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Panels;

    public static class PanelExtensions
    {
        #region Fluent

        public static IItemWriter<T, PanelContent> Type<T>(this IItemWriter<T, PanelContent> target, PanelType value)
            where T : Panel
        {
            target.Item.Type = value;
            return target;
        }
        
        public static IItemWriter<T, PanelContent> Header<T>(this IItemWriter<T, PanelContent> target, object value)
            where T : Panel
        {
            var writer = value as IItemWriter<PanelHeader>;
            if (writer != null)
            {
                target.Item.PanelHeader = writer.Item;
                return target;
            }

            var header = value as PanelHeader;
            if (header != null)
            {
                target.Item.PanelHeader = header;
                return target;
            }

            target.Item.PanelHeader = target.Helper.CreateWriter<PanelHeader, AnyContent>(target.Item).Content(value).Item;
            return target;
        }

        public static IItemWriter<T, PanelContent> Header<T>(this IItemWriter<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            target.Item.PanelHeader = target.Helper.CreateWriter<PanelHeader, AnyContent>(target.Item).Content(values).Item;
            return target;
        }

        public static IItemWriter<T, PanelContent> Body<T>(this IItemWriter<T, PanelContent> target, object value)
            where T : Panel
        {
            var writer = value as IItemWriter<PanelBody>;
            if (writer != null)
            {
                target.Item.PanelBody = writer.Item;
                return target;
            }

            var header = value as PanelBody;
            if (header != null)
            {
                target.Item.PanelBody = header;
                return target;
            }

            target.Item.PanelBody = target.Helper.CreateWriter<PanelBody, AnyContent>(target.Item).Content(value).Item;
            return target;
        }

        public static IItemWriter<T, PanelContent> Body<T>(this IItemWriter<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            target.Item.PanelBody = target.Helper.CreateWriter<PanelBody, AnyContent>(target.Item).Content(values).Item;
            return target;
        }

        public static IItemWriter<T, PanelContent> Footer<T>(this IItemWriter<T, PanelContent> target, object value)
            where T : Panel
        {
            var writer = value as IItemWriter<PanelFooter>;
            if (writer != null)
            {
                target.Item.PanelFooter = writer.Item;
                return target;
            }

            var header = value as PanelFooter;
            if (header != null)
            {
                target.Item.PanelFooter = header;
                return target;
            }

            target.Item.PanelFooter = target.Helper.CreateWriter<PanelFooter, AnyContent>(target.Item).Content(value).Item;
            return target;
        }

        public static IItemWriter<T, PanelContent> Footer<T>(this IItemWriter<T, PanelContent> target, params object[] values)
            where T : Panel
        {
            target.Item.PanelFooter = target.Helper.CreateWriter<PanelFooter, AnyContent>(target.Item).Content(values).Item;
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<Panel, PanelContent> Panel(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Panel, PanelContent>();
        }

        public static IItemWriter<Panel, PanelContent> Panel(this IAnyContentMarker contentHelper, PanelType type)
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

        public static IItemWriter<PanelHeader, AnyContent> PanelHeader(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.CreateWriter<PanelHeader, AnyContent>().Content(value);
        }

        public static IItemWriter<PanelHeader, AnyContent> PanelHeader(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.CreateWriter<PanelHeader, AnyContent>().Content(values);
        }

        public static IItemWriter<PanelBody, AnyContent> PanelBody(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.CreateWriter<PanelBody, AnyContent>().Content(value);
        }

        public static IItemWriter<PanelBody, AnyContent> PanelBody(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.CreateWriter<PanelBody, AnyContent>().Content(values);
        }

        public static IItemWriter<PanelFooter, AnyContent> PanelFooter(this IAnyContentMarker contentHelper, object value)
        {
            return contentHelper.CreateWriter<PanelFooter, AnyContent>().Content(value);
        }

        public static IItemWriter<PanelFooter, AnyContent> PanelFooter(this IAnyContentMarker contentHelper, params object[] values)
        {
            return contentHelper.CreateWriter<PanelFooter, AnyContent>().Content(values);
        }

        #endregion
    }
}
