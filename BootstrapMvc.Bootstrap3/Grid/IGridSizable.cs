using System;

namespace BootstrapMvc
{
    public interface IGridSizable
    {
        void SetSize(GridSize value);

        GridSize Size();
    }
}
