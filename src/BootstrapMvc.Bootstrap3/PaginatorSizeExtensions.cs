namespace BootstrapMvc
{
    public static partial class PaginatorSizeExtensions
    {
        public static string ToCssClass(this PaginatorSize size)
        {
            switch (size)
            {
                case PaginatorSize.Large:
                    return "pagination-lg";
                case PaginatorSize.Small:
                    return "pagination-sm";
                default:
                    return string.Empty;
            }
        }
    }
}
