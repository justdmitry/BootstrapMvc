using System;

namespace BootstrapMvc.Core
{
    public interface IControlContext
    {
        string Name { get; }

        object Value { get; }

        bool IsRequired { get; }

        string[] Errors { get; }

        bool HasErrors { get; }

        bool HasWarning { get; }
    }
}
