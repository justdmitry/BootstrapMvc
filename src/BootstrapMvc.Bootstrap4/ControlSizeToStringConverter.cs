namespace BootstrapMvc
{
    public static partial class ControlSizeToStringConverter
    {
        public static string ToButtonCssClass(this ControlSize size)
        {
            switch (size)
            {
                case ControlSize.Large:
                    return "btn-lg";
                case ControlSize.Small:
                    return "btn-sm";
            }

            return string.Empty;
        }

        public static string ToButtonGroupCssClass(this ControlSize size)
        {
            switch (size)
            {
                case ControlSize.Large:
                    return "btn-group-lg";
                case ControlSize.Small:
                    return "btn-group-sm";
            }

            return string.Empty;
        }

        public static string ToFormControlCssClass(this ControlSize size)
        {
            switch (size)
            {
                case ControlSize.Large:
                    return "form-control-lg";
                case ControlSize.Small:
                    return "form-control-sm";
            }

            return string.Empty;
        }

        public static string ToFormLabelCssClass(this ControlSize size)
        {
            switch (size)
            {
                case ControlSize.Large:
                    return "col-form-label-lg";
                case ControlSize.Small:
                    return "col-form-label-sm";
            }

            return string.Empty;
        }
    }
}
