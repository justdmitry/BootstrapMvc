namespace BootstrapMvc
{
    using System;

    public enum ButtonSize
    {
        Default,
        Large,
        Small,
#if BOOTSTRAP3
        ExtraSmall
#endif
    }
}
