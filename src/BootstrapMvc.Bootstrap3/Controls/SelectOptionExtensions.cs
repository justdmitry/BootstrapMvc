using System;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class SelectOptionExtensions
    {
        public static IWriter2<SelectOption, AnyContent> SelectOption(this IAnyContentMarker contentHelper, object value)
        {
            return SelectOption(contentHelper, value, value.ToString());
        }

        public static IWriter2<SelectOption, AnyContent> SelectOption(this IAnyContentMarker contentHelper, object value, string text)
        {
            return contentHelper.Context.CreateWriter<SelectOption, AnyContent>().Value(value.ToString()).Content(text);
        }
    }
}
