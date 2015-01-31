using System;
using BootstrapMvc;

namespace BootstrapMvc.Controls
{
    public interface ISizableControl
    {
        void SetSize(GridSize size);

        GridSize GetSize();
    }
}
