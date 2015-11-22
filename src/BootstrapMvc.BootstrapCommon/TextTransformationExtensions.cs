namespace BootstrapMvc
{
    public static class TextTransformationExtensions
    {
        public static string ToCssClass(this TextTransformation transformation)
        {
            switch (transformation)
            {
                case TextTransformation.Lowercase:
                    return "text-lowercase";
                case TextTransformation.Uppercase:
                    return "text-uppercase";
                case TextTransformation.Capitalize:
                    return "text-capitalize";
                default:
                    return string.Empty;
            }
        }
    }
}
