namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class BadgeExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Type<T>(this IItemWriter<T, AnyContent> target, BadgeType value) where T : Badge
        {
            target.Item.Type = value;
            return target;
        }

#if BOOTSTRAP4
        public static IItemWriter<T, AnyContent> Pill<T>(this IItemWriter<T, AnyContent> target, bool value = true) where T : Badge
        {
            target.Item.Pill = value;
            return target;
        }
#endif

        #endregion

        #region Generation

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, BadgeType type)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type);
        }

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, BadgeType type, object content)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type).Content(content);
        }

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, BadgeType type, params object[] contents)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginBadge(this IAnyContentMarker contentHelper, BadgeType type)
        {
            return Badge(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
