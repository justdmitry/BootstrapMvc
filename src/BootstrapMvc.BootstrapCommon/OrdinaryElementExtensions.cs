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
        /// Any HTML tag (by tag name)
        /// </summary>
        public static IItemWriter<OrdinaryElement, AnyContent> Tag(this IAnyContentMarker contentHelper, string tagName, params object[] contents)
        {
            var res = contentHelper.CreateWriter<OrdinaryElement, AnyContent>();
            res.Item.TagName = tagName;
            res.Content(contents);
            return res;
        }
       
        public static IItemWriter<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("span");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> Span(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("span", contents);
        }

        #endregion

        #region Headers

        public static IItemWriter<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h1");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H1(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h1", contents);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h2");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H2(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h2", contents);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h3");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H3(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h3", contents);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h4");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H4(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h4", contents);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h5");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H5(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h5", contents);
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Tag("h6");
        }

        public static IItemWriter<OrdinaryElement, AnyContent> H6(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Tag("h6", contents);
        }

        #endregion
    }
}
