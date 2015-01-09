using System;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class BootstrapContext<TModel> : BootstrapContext
    {
        public BootstrapContext(ViewContext viewContext, UrlHelper urlHelper, ViewDataDictionary<TModel> viewData)
            :base(viewContext, urlHelper, viewData)
        {
            this.ViewData = viewData;
        }

        public new ViewDataDictionary<TModel> ViewData { get; protected set; }
    }
}
