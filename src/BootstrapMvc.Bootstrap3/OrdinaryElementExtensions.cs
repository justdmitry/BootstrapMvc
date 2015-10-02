using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class OrdinaryElementExtensions
    {
        /// <summary>
        /// Any HTML tag (by tag name)
        /// </summary>
        public static IWriter2<OrdinaryElement, AnyContent> Tag(this IAnyContentMarker contentHelper, string tagName)
        {
            var res = contentHelper.Context.CreateWriter<OrdinaryElement, AnyContent>();
            res.Item.TagName = tagName;
            return res;
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static IWriter2<OrdinaryElement, AnyContent> Paragraph(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static IWriter2<OrdinaryElement, AnyContent> Paragraph(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static IWriter2<OrdinaryElement, AnyContent> P(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static IWriter2<OrdinaryElement, AnyContent> P(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("span");
        }

        public static IWriter2<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("span").Content(content);
        }

        #region Headers

        public static IWriter2<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h1");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h1").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h2");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h2").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h3");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h3").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h4");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h4").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h5");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h5").Content(content);
        }

        public static IWriter2<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h6");
        }

        public static IWriter2<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h6").Content(content);
        }

        #endregion
    }
}
