using BootstrapMvc.Core;
using BootstrapMvc.Controls;
using System.Globalization;

namespace BootstrapMvc
{
    public static class InputExtensions
    {
        public static Input InputInt(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Number).Size(0, 2, 2, 2); 
        }

        public static Input InputInt(this IAnyContentMarker contextHelper, int min, int max)
        {
            return InputInt(contextHelper)
                .Attribute("min", min.ToString(CultureInfo.InvariantCulture))
                .Attribute("max", max.ToString(CultureInfo.InvariantCulture));
        }

        public static Input InputDate(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Date).Size(0, 3, 3, 3);
        }

        public static Input InputDateTime(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Datetime).Size(0, 6, 5, 5);
        }

        public static Input InputDateTimeLocal(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.DatetimeLocal).Size(0, 5, 4, 4);
        }

        public static Input InputEmail(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Email);
        }

        public static Input InputTel(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Tel);
        }

        public static Input InputUrl(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Url);
        }
    }
}
