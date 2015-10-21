namespace BootstrapMvc.Paging
{
    using BootstrapMvc.Core;

    public class PaginatorContent : DisposableContent
    {
        public PaginatorContent(IBootstrapContext context, Paginator parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private Paginator Parent { get; set; }

        public IItemWriter<PaginatorItem, AnyContent> Item(object content)
        {
            return Context.Helper.CreateWriter<PaginatorItem, AnyContent>(Parent).Content(content);
        }

        public IItemWriter<PaginatorItem, AnyContent> ItemNext()
        {
            return Item("»");
        }

        public IItemWriter<PaginatorItem, AnyContent> ItemPrevious()
        {
            return Item("«");
        }
    }
}
