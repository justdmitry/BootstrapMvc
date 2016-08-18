namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;

    public static class StaticValueExtensions
    {
        public static IItemWriter<StaticValue> StaticValue(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<StaticValue>();
        }
    }
}
