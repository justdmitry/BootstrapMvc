namespace BootstrapMvc
{
    using System;

    public static partial class FormEnctypeToStringConverter
    {
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
