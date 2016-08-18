namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class LabelExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Type<T>(this IItemWriter<T, AnyContent> target, LabelType value) where T : Label
        {
            target.Item.Type = value;
            return target;
        }

#if BOOTSTRAP4
        public static IItemWriter<T, AnyContent> Pill<T>(this IItemWriter<T, AnyContent> target, bool value = true) where T : Label
        {
            target.Item.Pill = value;
            return target;
        }
#endif

        #endregion

        #region Generation

        public static IItemWriter<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type)
        {
            return contentHelper.CreateWriter<Label, AnyContent>().Type(type);
        }

        public static IItemWriter<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type, object content)
        {
            return contentHelper.CreateWriter<Label, AnyContent>().Type(type).Content(content);
        }

        public static IItemWriter<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type, params object[] contents)
        {
            return contentHelper.CreateWriter<Label, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginLabel(this IAnyContentMarker contentHelper, LabelType type)
        {
            return Label(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
