namespace BootstrapMvc
{
    using System;

    public enum InputType
    {
        Text,
        Default = Text,
        Color,
        Date,
        [Obsolete("No more \"type=datetime\" in HTML 5.1, use DatetimeLocal")]
        Datetime,
        DatetimeLocal,
        Email,
        Month,
        Number,
        Password,
        Search,
        Tel,
        Time,
        Url,
        Week,
        File
    }
}
