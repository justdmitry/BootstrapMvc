namespace BootstrapMvc
{
    public static class DropdownDirectionExtensions
    {
        public static string ToCssClass(this DropdownDirection value)
        {
            switch (value)
            {
                case DropdownDirection.Up:
                    return "dropup";
                case DropdownDirection.Left:
                    return "dropleft";
                case DropdownDirection.Right:
                    return "dropright";
            }

            return string.Empty;
        }
    }
}
