using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class CheckboxExtensions
    {
        public static IWriter<Checkbox> Checkbox(this IAnyContentMarker contentHelper, string text)
        {
            return contentHelper.Context.CreateWriter<Checkbox>().Text(text);
        }
    }
}
