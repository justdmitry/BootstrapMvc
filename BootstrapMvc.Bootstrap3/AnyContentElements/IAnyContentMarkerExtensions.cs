using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
    {
        #region Label

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type)
        {
            return new Label(contentHelper.Context).Type(type);
        }

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type, object content)
        {
            var lbl = new Label(contentHelper.Context).Type(type);
            lbl.Content(content);
            return lbl;
        }

        public static Label Label(this IAnyContentMarker contentHelper, LabelType type, params object[] contents)
        {
            var lbl = new Label(contentHelper.Context).Type(type);
            lbl.Content(contents);
            return lbl;
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
            var lbl = new Alert(contentHelper.Context).Type(type);
            lbl.Content(content);
            return lbl;
        }

        public static Alert Alert(this IAnyContentMarker contentHelper, object content, AlertType type)
        {
            var lbl = new Alert(contentHelper.Context).Type(type);
            lbl.Content(content);
            return lbl;
        }

        public static Alert Alert(this IAnyContentMarker contentHelper, AlertType type, params object[] contents)
        {
            var lbl = new Alert(contentHelper.Context).Type(type);
            lbl.Content(contents);
            return lbl;
        }

        public static AnyContent BeginAlert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return Alert(contentHelper, type).BeginContent();
        }

        #endregion

        public static Badge Badge(this IAnyContentMarker contentHelper, object content)
        {
            var b = new Badge(contentHelper.Context);
            b.Content(content);
            return b;
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper)
        {
            var obj = new Anchor(contentHelper.Context);
            return obj;
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper, object content)
        {
            var obj = new Anchor(contentHelper.Context);
            obj.Content(content);
            return obj;
        }

        public static Anchor Anchor(this IAnyContentMarker contentHelper, params object[] contents)
        {
            var obj = new Anchor(contentHelper.Context);
            obj.Content(contents);
            return obj;
        }

        public static AnyContent BeginAnchor(this IAnyContentMarker contentHelper)
        {
            var obj = new Anchor(contentHelper.Context);
            return obj.BeginContent();
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
