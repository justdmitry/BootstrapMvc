using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class StaticValueExtensions
    {
        public static IWriter<StaticValue> StaticValue(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<StaticValue>();
        }
    }
}
