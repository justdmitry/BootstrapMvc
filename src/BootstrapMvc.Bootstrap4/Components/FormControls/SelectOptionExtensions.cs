namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;

    public static class SelectOptionExtensions
    {
        public static IItemWriter<SelectOption, AnyContent> SelectOption(this IAnyContentMarker contentHelper, object value)
        {
            return SelectOption(contentHelper, value, value.ToString());
        }

        public static IItemWriter<SelectOption, AnyContent> SelectOption(this IAnyContentMarker contentHelper, object value, string text)
        {
            return contentHelper.CreateWriter<SelectOption, AnyContent>().Value(value.ToString()).Content(text);
        }
    }
}
