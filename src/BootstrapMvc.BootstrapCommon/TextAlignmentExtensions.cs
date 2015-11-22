namespace BootstrapMvc
{
    using System;
    
    public static class TextAlignmentExtensions
    {
        public static string ToCssClass(this TextAlignment alignment)
        {
            switch (alignment)
            {
                case TextAlignment.Left:
                    return "text-left";
                case TextAlignment.Center:
                    return "text-center";
                case TextAlignment.Right:
                    return "text-right";
                case TextAlignment.Justify:
                    return "text-justify";
                case TextAlignment.NoWrap:
                    return "text-nowrap";
                default:
                    return string.Empty;
            }
        }
    }
}
