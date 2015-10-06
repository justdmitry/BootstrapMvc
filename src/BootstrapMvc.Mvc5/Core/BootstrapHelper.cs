using System;

namespace BootstrapMvc.Core
{
    public class BootstrapHelper : IAnyContentMarker
    {
        public BootstrapHelper(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; protected set; }
    }
}