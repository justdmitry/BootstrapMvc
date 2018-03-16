namespace BootstrapMvc
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Tables;

    public static class TableHeaderExtensions
    {
        public static IItemWriter<T, TableSectionContent> Color<T>(this IItemWriter<T, TableSectionContent> target, TableHeaderColor color)
            where T : TableHeader
        {
            target.Item.Color = color;
            return target;
        }
    }
}
