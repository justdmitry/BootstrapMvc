namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;

    public static class CheckboxExtensions
    {
        public static IItemWriter<Checkbox> Checkbox(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Checkbox>();
        }

        public static IItemWriter<Checkbox> Checkbox(this IAnyContentMarker contentHelper, string text)
        {
            return contentHelper.CreateWriter<Checkbox>().Text(text);
        }
    }
}
