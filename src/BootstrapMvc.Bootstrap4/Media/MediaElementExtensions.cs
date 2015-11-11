namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class MediaElementExtensions
    {
        /// <summary>
        /// Adds 'media-object' class (use for elements, placed inside <see cref="Media"/>'s media)
        /// </summary>
        public static IItemWriter<T> MediaObject<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("media-object");
            return target;
        }

        /// <summary>
        /// Adds 'media-object' class (use for elements, placed inside <see cref="Media"/>'s media)
        /// </summary>
        public static IItemWriter<T, TContent> MediaObject<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("media-object");
            return target;
        }

        /// <summary>
        /// Adds 'media-heading' class (use for elements, placed inside <see cref="Media"/>'s content header)
        /// </summary>
        public static IItemWriter<T> MediaHeading<T>(this IItemWriter<T> target)
            where T : Element
        {
            target.Item.AddCssClass("media-heading");
            return target;
        }

        /// <summary>
        /// Adds 'media-heading' class (use for elements, placed inside <see cref="Media"/>'s content header)
        /// </summary>
        public static IItemWriter<T, TContent> MediaHeading<T, TContent>(this IItemWriter<T, TContent> target)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            target.Item.AddCssClass("media-heading");
            return target;
        }
    }
}
