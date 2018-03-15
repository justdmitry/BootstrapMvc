namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class BadgeExtensions
    {
        public static IItemWriter<T, AnyContent> Pill<T>(this IItemWriter<T, AnyContent> target, bool value = true)
            where T : Badge
        {
            target.Item.Pill = value;
            return target;
        }

        public static IItemWriter<T, AnyContent> WithWhitespacePrefix<T>(this IItemWriter<T, AnyContent> target, bool value = true)
            where T : Badge
        {
            target.Item.WithWhitespacePrefix = value;
            return target;
        }

        #region Generation

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, Color8 type)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type);
        }

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, Color8 type, object content)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type).Content(content);
        }

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, Color8 type, params object[] contents)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginBadge(this IAnyContentMarker contentHelper, Color8 type)
        {
            return Badge(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
