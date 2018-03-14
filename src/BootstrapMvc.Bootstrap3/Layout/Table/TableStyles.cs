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
#if BOOTSTRAP3
        Condensed = 0x8,
#endif
#if BOOTSTRAP4
        Small = 0x8,

        [Obsolete("Use 'Small'")]
        Condensed = Small,

        Inverse = 0x16,

        Reflow = 0x32,

        Responsive = 0x64,
#endif
    }
}
