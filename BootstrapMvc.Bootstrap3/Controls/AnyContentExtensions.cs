using System;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;
using System.Linq.Expressions;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
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

        public static Select Select(this IAnyContentMarker contentHelper)
        {
            return new Select(contentHelper.Context);
        }

        public static SelectOptGroup SelectOptGroup(this IAnyContentMarker contentHelper, string label)
        {
            return new SelectOptGroup(contentHelper.Context).Label(label);
        }

        public static SelectOption SelectOption(this IAnyContentMarker contentHelper, object value)
        {
            return SelectOption(contentHelper, value, value.ToString());
        }

        public static SelectOption SelectOption(this IAnyContentMarker contentHelper, object value, string text)
        {
            return new SelectOption(contentHelper.Context).Value(value).Content(text);
        }
    }
}
