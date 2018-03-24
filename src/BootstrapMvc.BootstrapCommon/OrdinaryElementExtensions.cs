namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public static partial class OrdinaryElementExtensions
    {
        /// <summary>
        /// Any HTML tag (by tag name)
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> Tag(this IAnyContentMarker contentHelper, string tagName)
        {
            var res = contentHelper.CreateWriter<OrdinaryElement, AnyContent>();
            res.Item.TagName = tagName;
            return res;
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Tag(this IAnyContentMarker contentHelper, string tagName, params object[] content)
        {
            return contentHelper.Tag(tagName).Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> P(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("p").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Paragraph(this IAnyContentMarker contentHelper, params object[] content)
        {
            return P(contentHelper, content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("span").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Small(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("small").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Strong(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("strong").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Em(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("em").Content(content);
        }

        #region Headers

        public static IItemWriter<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h1").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h2").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h3").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h4").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h5").Content(content);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper, params object[] content)
        {
            return contentHelper.Tag("h6").Content(content);
        }

        #endregion
    }
}
