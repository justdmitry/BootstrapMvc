namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;

    public static class RadioExtensions
    {
        public static IItemWriter<Radio> Radio(this IAnyContentMarker contentHelper, object value, string text)
        {
            return contentHelper.CreateWriter<Radio>().Text(text).Value(value.ToString());
        }
    }
}
