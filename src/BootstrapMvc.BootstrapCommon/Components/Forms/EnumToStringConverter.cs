namespace BootstrapMvc
{
    using System;

    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this FormType type)
        {
            switch (type)
            {
                case FormType.Inline:
                    return "form-inline";
                case FormType.Horizontal:
                    return "form-horizontal";
                default:
                    return string.Empty;
            }
        }

        public static string ToEnctype(this FormEnctype enctype)
        {
            switch (enctype)
            {
                case FormEnctype.UrlEncoded:
                    return "application/x-www-form-urlencoded";
                case FormEnctype.Multipart:
                    return "multipart/form-data";
                case FormEnctype.TextPlain:
                    return "text/plain";
            }
            return string.Empty;
        }
    }
}
