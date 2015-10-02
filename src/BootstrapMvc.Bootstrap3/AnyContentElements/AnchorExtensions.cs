using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AnchorExtensions
    {
        #region Generation

        public static IWriter2<Anchor, AnyContent> Anchor(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Anchor, AnyContent>();
        }

        public static IWriter2<Anchor, AnyContent> Anchor(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Context.CreateWriter<Anchor, AnyContent>().Content(content);
        }

        public static IWriter2<Anchor, AnyContent> Anchor(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<Anchor, AnyContent>().Content(contents);
        }

        public static AnyContent BeginAnchor(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Anchor, AnyContent>().BeginContent();
        }

        public static IWriter2<Anchor, AnyContent> Link(this IAnyContentMarker contentHelper)
        {
            return Anchor(contentHelper);
        }

        public static IWriter2<Anchor, AnyContent> Link(this IAnyContentMarker contentHelper, object content)
        {
            return Anchor(contentHelper, content);
        }

        public static IWriter2<Anchor, AnyContent> Link(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return Anchor(contentHelper, contents);
        }

        public static AnyContent BeginLink(this IAnyContentMarker contentHelper)
        {
            return BeginAnchor(contentHelper);
        }

        #endregion
    }
}
