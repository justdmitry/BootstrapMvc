using System;

namespace BootstrapMvc.Core
{
    public class DummyDisposableContent : DisposableContent
    {
        public DummyDisposableContent(IBootstrapContext context)
            : base(context)
        {
            WriteWhitespaceSuffix(false);
        }
    }
}
