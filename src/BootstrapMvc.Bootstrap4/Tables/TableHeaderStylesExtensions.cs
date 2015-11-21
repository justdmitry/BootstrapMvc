namespace BootstrapMvc
{
    using System;

    public static class TableHeaderStylesExtensions
    {
        public static string ToCssClass(this TableHeaderStyles styles)
        {
            switch (styles)
            {
                case TableHeaderStyles.Default:
                    return "thead-default";
                case TableHeaderStyles.Inverse:
                    return "thead-inverse";
                case TableHeaderStyles.None:
                default:
                    return string.Empty;
            }
        }
    }
}
