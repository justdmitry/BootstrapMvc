namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToType(this InputType type)
        {
            switch (type)
            {
                case InputType.Text:
                    return string.Empty;
                case InputType.DatetimeLocal:
                    return "datetime-local";
                default:
                    return type.ToString().ToLowerInvariant();
            }
        }
    }
}
