namespace BootstrapMvc
{
    using System;

    public static class ButtonSizeExtensions
    {
        public static string ToButtonCssClass(this ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Large:
                    return "btn-lg";
                case ButtonSize.Small:
                    return "btn-sm";
                case ButtonSize.ExtraSmall:
                    return "btn-xs";
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
                case ButtonSize.ExtraSmall:
                    return "btn-group-xs";
            }
            return string.Empty;
        }
    }
}
