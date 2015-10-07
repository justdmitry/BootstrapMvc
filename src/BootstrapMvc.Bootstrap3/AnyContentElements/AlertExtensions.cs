using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AlertExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Type<T>(this IWriter2<T, AnyContent> target, AlertType value) where T : Alert
        {
            target.Item.Type = value;
            return target;
        }

        public static IWriter2<T, AnyContent> Closable<T>(this IWriter2<T, AnyContent> target, bool value = true) where T : Alert
        {
            target.Item.Closable = value;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return contentHelper.Context.CreateWriter<Alert, AnyContent>().Type(type);
        }

        public static IWriter2<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, AlertType type, object content)
        {
            return contentHelper.Context.CreateWriter<Alert, AnyContent>().Type(type).Content(content);
        }

        public static IWriter2<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, object content, AlertType type)
        {
            return contentHelper.Context.CreateWriter<Alert, AnyContent>().Type(type).Content(content);
        }

        public static IWriter2<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, AlertType type, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<Alert, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginAlert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return Alert(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
