namespace BootstrapMvc
{
    using System;

    public interface IGridSizable
    {
        void SetSize(GridSize value);

        GridSize GetSize();
    }
}
