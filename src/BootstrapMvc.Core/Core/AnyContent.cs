namespace BootstrapMvc.Core
{
    using System;

    public class AnyContent : DisposableContent, IAnyContentMarker
    {
        public AnyContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }
    }
}
