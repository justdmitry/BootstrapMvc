using System;
using BootstrapMvc.Core;
using BootstrapMvc.Paging;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region Paginator

        public static Paginator Paginator(this IAnyContentMarker contentHelper)
        {
            return new Paginator(contentHelper.Context);
        }

        public static Paginator Paginator(this IAnyContentMarker contentHelper, PaginatorSize size)
        {
            return new Paginator(contentHelper.Context).Size(size);
        }

        public static PaginatorContent BeginPaginator(this IAnyContentMarker contentHelper)
        {
            return new Paginator(contentHelper.Context).BeginContent();
        }

        public static PaginatorContent BeginPaginator(this IAnyContentMarker contentHelper, PaginatorSize size)
        {
            return new Paginator(contentHelper.Context).Size(size).BeginContent();
        }

        #endregion
    }
}
