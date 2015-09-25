using System;

namespace BootstrapMvc.Core
{
    public class AnyContent : DisposableContent, IAnyContentMarker
    {
        public AnyContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }
    }
}
