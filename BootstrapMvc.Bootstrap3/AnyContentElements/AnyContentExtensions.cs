using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region Label

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type)
        {
            return new Label(contentHelper.Context).Type(type);
        }

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type, object content)
        {
            return new Label(contentHelper.Context).Type(type).Content(content);
        }

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type, params object[] contents)
        {
            return new Label(contentHelper.Context).Type(type).Content(contents);
        }

        public static AnyContent BeginLabel(this IAnyContentMarker contentHelper, LabelType type)
        {
            return Label(contentHelper, type).BeginContent();
        }

        #endregion

        #region Alert

        public static Alert Alert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return new Alert(contentHelper.Context).Type(type);
        }

        public static Alert Alert(this IAnyContentMarker contentHelper, AlertType type, object content)
        {
            return new Alert(contentHelper.Context).Type(type).Content(content);
        }

        public static Alert Alert(this IAnyContentMarker contentHelper, object content, AlertType type)
        {
            return new Alert(contentHelper.Context).Type(type).Content(content);
        }

        public static Alert Alert(this IAnyContentMarker contentHelper, AlertType type, params object[] contents)
        {
            return new Alert(contentHelper.Context).Type(type).Content(contents);
        }

        public static AnyContent BeginAlert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return Alert(contentHelper, type).BeginContent();
        }

        #endregion

        public static Badge Badge(this IAnyContentMarker contentHelper, object content)
        {
            return new Badge(contentHelper.Context).Content(content);
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper)
        {
            return new Anchor(contentHelper.Context);
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper, object content)
        {
            return new Anchor(contentHelper.Context).Content(content);
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return new Anchor(contentHelper.Context).Content(contents);
        }

        public static AnyContent BeginAnchor(this IAnyContentMarker contentHelper)
        {
            return new Anchor(contentHelper.Context).BeginContent();
        }

        public static Anchor Link(this IAnyContentMarker contentHelper)
        {
            return Anchor(contentHelper);
        }

        public static Anchor Link(this IAnyContentMarker contentHelper, object content)
        {
            return Anchor(contentHelper, content);
        }

        public static Anchor Link(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return Anchor(contentHelper, contents);
        }

        public static AnyContent BeginLink(this IAnyContentMarker contentHelper)
        {
            return BeginAnchor(contentHelper);
        }
    }
}
