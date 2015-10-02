using System;
using System.IO;
using System.Web;

namespace BootstrapMvc.Core
{
    public abstract partial class WritableBlock : IHtmlString
    {
        public string ToHtmlString()
        {
            using (var sw = new StringWriter())
            {
                this.WriteSelf(sw);
                return sw.ToString();
            }
        }
    }
}
