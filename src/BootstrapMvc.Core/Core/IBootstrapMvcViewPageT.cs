using System;

namespace BootstrapMvc.Core
{
    public interface IBootstrapMvcViewPage<TModel>
    {
        BootstrapHelper<TModel> Bootstrap { get; }

        void Write(WritableBlock block);
    }
}
