using System;

namespace BootstrapMvc.Core
{
    public class AnyContentContext : DisposableContext, IAnyContentMarker
    {
        public AnyContentContext(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }
    }
}
