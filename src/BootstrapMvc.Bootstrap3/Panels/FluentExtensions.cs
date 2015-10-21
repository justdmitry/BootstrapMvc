namespace BootstrapMvc
{
    using Core;
    using BootstrapMvc.Panels;

    public static partial class FluentExtensions
    {
        public static TWriter Type<TWriter, TItem>(this TWriter target, PanelType value)
            where TWriter: IItemWriter<TItem>
            where TItem: Panel
        {
            target.Item.Type = value;
            return target;
        }
    }
}
