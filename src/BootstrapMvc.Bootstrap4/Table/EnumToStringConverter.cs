namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this TableHeaderStyle style)
        {
            switch (style)
            {
                case TableHeaderStyle.Inverse:
                    return "thead-inverse";
                case TableHeaderStyle.DefaultGray:
                    return "thead-default";
                case TableHeaderStyle.None:
                default:
                    return string.Empty;
            }
        }
    }
}
