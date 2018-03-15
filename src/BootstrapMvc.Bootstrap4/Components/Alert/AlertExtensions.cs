namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class AlertExtensions
    {
        public static IItemWriter<T, AnyContent> Closable<T>(this IItemWriter<T, AnyContent> target, bool value = true)
            where T : Alert
        {
            target.Item.Closable = value;
            return target;
        }

        #region Generation

        public static IItemWriter<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, Color8 type)
        {
            return contentHelper.CreateWriter<Alert, AnyContent>().Type(type);
        }

        public static IItemWriter<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, Color8 type, object content)
        {
            return contentHelper.CreateWriter<Alert, AnyContent>().Type(type).Content(content);
        }

        public static IItemWriter<Alert, AnyContent> Alert(this IAnyContentMarker contentHelper, Color8 type, params object[] contents)
        {
            return contentHelper.CreateWriter<Alert, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginAlert(this IAnyContentMarker contentHelper, Color8 type)
        {
            return Alert(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
