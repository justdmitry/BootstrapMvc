namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class MediaExtensions
    {
        #region Fluid

        public static IItemWriter<T, MediaContent> Object<T>(this IItemWriter<T, MediaContent> target, object value)
            where T : Media
        {
            var writer = value as IItemWriter<MediaObject>;
            if (writer != null)
            {
                target.Item.Object = writer.Item;
                return target;
            }

            var obj = value as MediaObject;
            if (obj != null)
            {
                target.Item.Object = obj;
                return target;
            }

            target.Item.Object = target.Helper.CreateWriter<MediaObject, AnyContent>(target.Item).Content(value).Item;
            return target;
        }

        public static IItemWriter<T, MediaContent> Body<T>(this IItemWriter<T, MediaContent> target, object value)
            where T : Media
        {
            var writer = value as IItemWriter<MediaBody>;
            if (writer != null)
            {
                target.Item.Body = writer.Item;
                return target;
            }

            var obj = value as MediaBody;
            if (obj != null)
            {
                target.Item.Body = obj;
                return target;
            }

            target.Item.Body = target.Helper.CreateWriter<MediaBody, AnyContent>(target.Item).Content(value).Item;
            return target;
        }

        #endregion

        public static string ToCssClass(this MediaObjectAlign align)
        {
            switch (align)
            {
                case MediaObjectAlign.Left:
                    return "media-left";
                case MediaObjectAlign.Right:
                    return "media-right";
                default:
                    return string.Empty;
            }
        }

        public static string ToCssClass(this MediaObjectVerticalAlign align)
        {
            switch (align)
            {
                case MediaObjectVerticalAlign.Top:
                    return string.Empty;
                case MediaObjectVerticalAlign.Middle:
                    return "media-middle";
                case MediaObjectVerticalAlign.Bottom:
                    return "media-bottom";
                default:
                    return string.Empty;
            }
        }

        public static IItemWriter<Media, MediaContent> Media(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Media, MediaContent>();
        }

        public static MediaContent BeginMedia(this IAnyContentMarker contentHelper)
        {
            return Media(contentHelper).BeginContent();
        }

        public static IItemWriter<MediaObject, AnyContent> MediaObject(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<MediaObject, AnyContent>();
        }

        public static IItemWriter<MediaObject, AnyContent> MediaObject(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return MediaObject(contentHelper).Content(contents);
        }

        public static AnyContent BeginMediaObject(this IAnyContentMarker contentHelper)
        {
            return MediaObject(contentHelper).BeginContent();
        }

        public static IItemWriter<MediaBody, AnyContent> MediaBody(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<MediaBody, AnyContent>();
        }

        public static IItemWriter<MediaBody, AnyContent> MediaBody(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return MediaBody(contentHelper).Content(contents);
        }

        public static AnyContent BeginMediaBody(this IAnyContentMarker contentHelper)
        {
            return MediaBody(contentHelper).BeginContent();
        }
    }
}
