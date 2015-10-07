using System.Globalization;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class InputExtensions
    {
        #region Input

        public static IWriter<T> Type<T>(this IWriter<T> target, InputType value)
            where T : Input
        {
            target.Item.TypeValue = value;
            return target;
        }

        #endregion

        #region Generating

        public static IWriter<Input> Input(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Input>();
        }

        public static IWriter<Input> Input(this IAnyContentMarker contentHelper, InputType type)
        {
            return Input(contentHelper).Type(type);
        }
        
        public static IWriter<Input> InputInt(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Number).Size(0, 2, 2, 2); 
        }

        public static IWriter<Input> InputInt(this IAnyContentMarker contextHelper, int min, int max)
        {
            return InputInt(contextHelper)
                .Attribute("min", min.ToString(CultureInfo.InvariantCulture))
                .Attribute("max", max.ToString(CultureInfo.InvariantCulture));
        }

        public static IWriter<Input> InputDate(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Date).Size(0, 3, 3, 3);
        }

        public static IWriter<Input> InputDateTime(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Datetime).Size(0, 6, 5, 5);
        }

        public static IWriter<Input> InputDateTimeLocal(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.DatetimeLocal).Size(0, 5, 4, 4);
        }

        public static IWriter<Input> InputEmail(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Email);
        }

        public static IWriter<Input> InputTel(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Tel);
        }

        public static IWriter<Input> InputUrl(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Url);
        }

        public static IWriter<Input> InputFile(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.File);
        }

        #endregion
    }
}
