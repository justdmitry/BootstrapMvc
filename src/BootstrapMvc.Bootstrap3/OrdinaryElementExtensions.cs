using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class OrdinaryElementExtensions
    {
        /// <summary>
        /// Any HTML tag (by tag name)
        /// </summary>
        public static AnyContentElement Tag(this IAnyContentMarker contentHelper, string tagName)
        {
            return new OrdinaryElement(contentHelper.Context, tagName);
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static AnyContentElement Paragraph(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static AnyContentElement Paragraph(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static AnyContentElement P(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static AnyContentElement P(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        public static AnyContentElement Span(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("span");
        }

        public static AnyContentElement Span(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("span").Content(content);
        }

        #region Headers

        public static AnyContentElement H1(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h1");
        }

        public static AnyContentElement H1(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h1").Content(content);
        }

        public static AnyContentElement H2(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h2");
        }

        public static AnyContentElement H2(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h2").Content(content);
        }

        public static AnyContentElement H3(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h3");
        }

        public static AnyContentElement H3(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h3").Content(content);
        }

        public static AnyContentElement H4(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h4");
        }

        public static AnyContentElement H4(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h4").Content(content);
        }

        public static AnyContentElement H5(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h5");
        }

        public static AnyContentElement H5(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h5").Content(content);
        }

        public static AnyContentElement H6(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h6");
        }

        public static AnyContentElement H6(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h6").Content(content);
        }

        #endregion
    }
}
