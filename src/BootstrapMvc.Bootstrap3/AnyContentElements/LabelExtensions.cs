using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class LabelExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> Type<T>(this IWriter2<T, AnyContent> target, LabelType value) where T : Label
        {
            target.Item.TypeValue = value;
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type)
        {
            return contentHelper.Context.CreateWriter<Label, AnyContent>().Type(type);
        }

        public static IWriter2<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type, object content)
        {
            return contentHelper.Context.CreateWriter<Label, AnyContent>().Type(type).Content(content);
        }

        public static IWriter2<Label, AnyContent> Label(this IAnyContentMarker contentHelper, LabelType type, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<Label, AnyContent>().Type(type).Content(contents);
        }

        public static AnyContent BeginLabel(this IAnyContentMarker contentHelper, LabelType type)
        {
            return Label(contentHelper, type).BeginContent();
        }

        #endregion
    }
}
