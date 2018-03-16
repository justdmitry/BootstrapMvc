namespace BootstrapMvc
{
    using System;

    [Flags]
    public enum TableStyles : byte
    {
        Default = 0x0,
        Striped = 0x1,
        Bordered = 0x2,
        Hover = 0x4,
        Small = 0x8,
        Dark = 0x16,
    }
}
