using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class PaginatorContent : DisposableContent
    {
        public PaginatorContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public PaginatorItem Item(object content)
        {
            return new PaginatorItem(Context).Content(content);
        }

        public PaginatorItem ItemNext()
        {
            return new PaginatorItem(Context).Content("»");
        }

        public PaginatorItem ItemPrevious()
        {
            return new PaginatorItem(Context).Content("«");
        }
    }
}
