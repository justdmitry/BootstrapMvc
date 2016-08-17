namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class BadgeExtensions
    {
        [Obsolete("Use Label with Pill property instead")]
        public static IItemWriter<Label, AnyContent> Badge(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.CreateWriter<Label, AnyContent>().Type(LabelType.DefaultGray).Pill().Content(content);
        }
    }
}
