using System;

namespace BootstrapMvc.Core
{
    public interface IModelValidationError
    {
        string Message { get; }

        bool IsWarning { get; }
    }
}
