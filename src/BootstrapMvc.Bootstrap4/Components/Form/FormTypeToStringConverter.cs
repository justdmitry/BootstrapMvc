namespace BootstrapMvc
{
    using System;

    public static partial class FormTypeToStringConverter
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
    }
}
