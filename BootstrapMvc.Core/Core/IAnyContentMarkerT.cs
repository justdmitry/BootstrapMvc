using System;

namespace BootstrapMvc.Core
{
    public interface IAnyContentMarker<T> : IAnyContentMarker
    {
        new IBootstrapContext<T> Context { get; }
    }
}
