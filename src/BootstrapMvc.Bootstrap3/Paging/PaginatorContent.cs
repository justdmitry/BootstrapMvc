using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class PaginatorContent : DisposableContent
    {
        public PaginatorContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<PaginatorItem, AnyContent> Item(object content)
        {
            return Context.CreateWriter<PaginatorItem, AnyContent>().Content(content);
        }

        public IWriter2<PaginatorItem, AnyContent> ItemNext()
        {
            return Item("»");
        }

        public IWriter2<PaginatorItem, AnyContent> ItemPrevious()
        {
            return Item("«");
        }
    }
}
