using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AlertExtensions
    {
        #region Fluent

        public static IWriter<T> Type<T>(this IWriter<T> target, AlertType value) where T : Alert
        {
            target.Item.Type = value;
            return target;
        }

        public static IWriter<T> Closable<T>(this IWriter<T> target, bool value = true) where T : Alert
        {
            target.Item.Closable = value;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter<Alert> Alert(this IAnyContentMarker contentHelper, AlertType type)
        {
            return contentHelper.Context.CreateWriter<Alert>().Type(type);
        }

        public static IWriter<Alert> Alert(this IAnyContentMarker contentHelper, AlertType type, object content)
        {
            return contentHelper.Context.CreateWriter<Alert>().Type(type).Content(content);
        }

        public static IWriter<Alert> Alert(this IAnyContentMarker contentHelper, object content, AlertType type)
        {
            return contentHelper.Context.CreateWriter<Alert>().Type(type).Content(content);
        }

        public static IWriter<Alert> Alert(this IAnyContentMarker contentHelper, AlertType type, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<Alert>().Type(type).Content(contents);
        }

        //public static AnyContent BeginAlert(this IAnyContentMarker contentHelper, AlertType type)
        //{
        //    return Alert(contentHelper, type).BeginContent();
        //}

        #endregion
    }
}
