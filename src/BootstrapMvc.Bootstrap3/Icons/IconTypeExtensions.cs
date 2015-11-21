namespace BootstrapMvc
{
    using System;

    public static class IconTypeExtensions
    {
        public static string ToCssClass(this IconType type)
        {
            return "glyphicon glyphicon-" + type.ToString().Replace('_', '-').ToLowerInvariant();
        }
    }
}
