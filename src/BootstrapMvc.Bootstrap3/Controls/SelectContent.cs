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

        public IWriter2<SelectOptGroup, SelectOptGroupContent> OptGroup(string label)
        {
            return Context.CreateWriter<SelectOptGroup, SelectOptGroupContent>().Label(label);
        }
    }
}
