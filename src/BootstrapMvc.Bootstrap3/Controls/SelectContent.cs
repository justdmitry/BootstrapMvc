using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public class SelectContent : SelectOptGroupContent
    {
        public SelectContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public SelectOptGroup OptGroup(string label)
        {
            var res = new SelectOptGroup(Context).Label(label);
            return res;
        }
    }
}
