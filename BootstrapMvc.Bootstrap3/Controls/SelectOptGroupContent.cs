using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public class SelectOptGroupContent : DisposableContext
    {
        public SelectOptGroupContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public SelectOption Option(object value)
        {
            return Option(value, value.ToString());
        }

        public SelectOption Option(object value, string text)
        {
            var res = new SelectOption(Context);
            res.Value(value).Content(text);
            return res;
        }
    }
}
