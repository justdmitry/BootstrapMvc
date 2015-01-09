using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
    {
        public static Checkbox Checkbox(this IAnyContentMarker contentHelper, string text)
        {
            return new Checkbox(contentHelper.Context).Text(text);
        }

        public static Radio Radio(this IAnyContentMarker contentHelper, object value, string text)
        {
            return new Radio(contentHelper.Context).Text(text).Value(value.ToString());
        }

        public static Input Input(this IAnyContentMarker contentHelper)
        {
            return new Input(contentHelper.Context);
        }

        public static Input Input(this IAnyContentMarker contentHelper, InputType type)
        {
            return new Input(contentHelper.Context).Type(type);
        }

        public static StaticValue StaticValue(this IAnyContentMarker contentHelper)
        {
            return new StaticValue(contentHelper.Context);
        }

        public static Textarea Textarea(this IAnyContentMarker contentHelper)
        {
            return new Textarea(contentHelper.Context);
        }
    }
}
