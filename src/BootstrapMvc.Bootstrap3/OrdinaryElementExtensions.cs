namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static class OrdinaryElementExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> TagName<T>(this IItemWriter<T, AnyContent> target, string tagName)
            where T : OrdinaryElement
        {
            target.Item.TagName = tagName;
            return target;
        }

        #endregion

        #region Generation

        /// <summary>
        /// Any HTML tag (by tag name)
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> Tag(this IAnyContentMarker contentHelper, string tagName)
        {
            var res = contentHelper.CreateWriter<OrdinaryElement, AnyContent>();
            res.Item.TagName = tagName;
            return res;
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> Paragraph(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> Paragraph(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        /// <summary>
        /// Paragraph element (&ltp&gt)
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> P(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("p");
        }

        /// <summary>
        /// Paragraph element (&ltp&gt) with content
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> P(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("span");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("span").Content(content);
        }

        #endregion

        #region Headers

        public static IItemWriter<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h1");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h1").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h2");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h2").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h3");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h3").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h4");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h4").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h5");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h5").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h6");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Tag("h6").Content(content);
        }

        #endregion
    }
}
