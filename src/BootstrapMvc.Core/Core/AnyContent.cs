using System;

namespace BootstrapMvc.Core
{
    public class AnyContent : DisposableContent, IAnyContentMarker
    {
        public IBootstrapContext Context { get; private set; }

        public AnyContent(IBootstrapContext context)
        {
            this.Context = context;
        }
    }
}
