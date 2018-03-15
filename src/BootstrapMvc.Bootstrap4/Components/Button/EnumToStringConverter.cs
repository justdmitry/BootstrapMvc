namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToButtonCssClass(this ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-lg";
                case ButtonSize.Small:
                    return "btn-sm";
            }

            return string.Empty;
        }

        public static string ToButtonGroupCssClass(this ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-group-lg";
                case ButtonSize.Small:
                    return "btn-group-sm";
            }

            return string.Empty;
        }
    }
}
