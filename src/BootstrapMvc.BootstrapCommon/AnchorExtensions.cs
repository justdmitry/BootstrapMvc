namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class AnchorExtensions
    {
        public static IItemWriter<Anchor, AnyContent> Anchor(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Anchor, AnyContent>();
        }

        public static IItemWriter<Anchor, AnyContent> Anchor(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.CreateWriter<Anchor, AnyContent>().Content(contents);
        }

        public static AnyContent BeginAnchor(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Anchor, AnyContent>().BeginContent();
        }

        public static IItemWriter<Anchor, AnyContent> Link(this IAnyContentMarker contentHelper)
        {
            return Anchor(contentHelper);
        }

        public static IItemWriter<Anchor, AnyContent> Link(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return Anchor(contentHelper, contents);
        }

        public static AnyContent BeginLink(this IAnyContentMarker contentHelper)
        {
            return BeginAnchor(contentHelper);
        }
    }
}
