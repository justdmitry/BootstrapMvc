namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class LabelExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Type<T>(this IItemWriter<T, AnyContent> target, LabelType value) 
            where T : Label
        {
            target.Item.Type = value;
            return target;
        }

        #endregion

        public static string ToCssClass(this LabelType type)
        {
            switch (type)
            {
                case LabelType.DefaultGray:
                    return "label label-default";
                case LabelType.PrimaryBlue:
                    return "label label-primary";
                case LabelType.SuccessGreen:
                    return "label label-success";
                case LabelType.WarningOrange:
                    return "label label-warning";
                case LabelType.DangerRed:
                    return "label label-danger";
                case LabelType.InfoCyan:
                    return "label label-info";
            }
            return string.Empty;
        }

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
