using System;

namespace BootstrapMvc
{
    /// <summary>
    /// Control, how date values are handled in input controls
    /// </summary>
    public enum DateInputMode
    {
        /// <summary>
        /// Values are converted ToString() and regular text fields are used
        /// </summary>
        Text,

        /// <summary>
        /// New HTML5 input types are used (date, etc), values are in RFC-3339 (<see cref="http://www.w3.org/TR/html-markup/datatypes.html#common.data.datetime">here</see>)
        /// </summary>
        Html5
    }
}
