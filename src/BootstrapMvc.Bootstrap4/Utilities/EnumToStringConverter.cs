namespace BootstrapMvc
{
    public static partial class EnumToStringConverter
    {
        public static string ToCssClass(this BorderType type)
        {
            switch (type)
            {
                case BorderType.None:
                    return "border-0";
                case BorderType.Top:
                    return "border-top";
                case BorderType.Right:
                    return "border-right";
                case BorderType.Bottom:
                    return "border-bottom";
                case BorderType.Left:
                    return "border-left";
                case BorderType.All:
                    return "border";
                case BorderType.ExceptTop:
                    return "border-top-0";
                case BorderType.ExceptRight:
                    return "border-right-0";
                case BorderType.ExceptBottom:
                    return "border-bottom-0";
                case BorderType.ExceptLeft:
                    return "border-left-0";
            }

            return string.Empty;
        }

        public static string ToCssClass(this BorderRadius radius)
        {
            switch (radius)
            {
                case BorderRadius.None:
                    return "rounded-0";
                case BorderRadius.All:
                    return "rounded";
                case BorderRadius.Top:
                    return "rounded-top";
                case BorderRadius.Right:
                    return "rounded-right";
                case BorderRadius.Bottom:
                    return "rounded-bottom";
                case BorderRadius.Left:
                    return "rounded-left";
                case BorderRadius.Circle:
                    return "rounded-circle";
            }

            return string.Empty;
        }

        public static string ToCssClassSubstring(this SpacingSide side)
        {
            switch (side)
            {
                case SpacingSide.Top:
                    return "t";
                case SpacingSide.Right:
                    return "r";
                case SpacingSide.Bottom:
                    return "b";
                case SpacingSide.Left:
                    return "l";
                case SpacingSide.LeftRight:
                    return "x";
                case SpacingSide.TopBottom:
                    return "y";
                case SpacingSide.All:
                    return string.Empty;
            }

            return string.Empty;
        }
    }
}
