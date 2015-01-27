using System;

namespace BootstrapMvc.Core
{
    public interface IControlContext
    {
        string Name { get; set; }

        object Value { get; set; }

        bool IsRequired { get; set; }

        string[] Errors { get; set; }

        bool HasErrors { get; set; }

        bool HasWarning { get; set; }
    }
}
