using System;

namespace BootstrapMvc
{
    [Flags]
    public enum TableStyles
    {
        Default = 0x0,
        Striped = 0x1,
        Bordered = 0x2,
        Hover = 0x4,
        Condensed = 0x8
    }
}
