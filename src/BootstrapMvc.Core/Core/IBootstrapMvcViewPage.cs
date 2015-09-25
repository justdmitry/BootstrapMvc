using System;

namespace BootstrapMvc.Core
{
    public interface IBootstrapMvcViewPage
    {
        BootstrapHelper Bootstrap { get; }

        void Write(WritableBlock block);
    }
}
