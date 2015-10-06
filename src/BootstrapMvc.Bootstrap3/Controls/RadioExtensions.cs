using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class RadioExtensions
    {
        public static IWriter<Radio> Radio(this IAnyContentMarker contentHelper, object value, string text)
        {
            return contentHelper.Context.CreateWriter<Radio>().Text(text).Value(value.ToString());
        }
    }
}
