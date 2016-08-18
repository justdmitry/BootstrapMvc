namespace BootstrapMvc
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Tables;

    public static class TableHeaderExtensions
    {
        public static IItemWriter<T, TableSectionContent> Style<T>(this IItemWriter<T, TableSectionContent> target, TableHeaderStyle value)
            where T : TableHeader
        {
            target.Item.Style = value;
            return target;
        }
    }
}
