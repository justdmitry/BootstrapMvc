namespace BootstrapMvc
{
    using System;

    public enum ButtonType
    {
#if BOOTSTRAP3
        DefaultGray,
#endif
#if BOOTSTRAP4
        SecondaryWhite,

        [Obsolete("Use SecondaryWhite instead")]
        DefaultGray = SecondaryWhite,
#endif
        PrimaryBlue,
        InfoCyan,
        SuccessGreen,
        WarningOrange,
        DangerRed,
        Link,
    }
}
