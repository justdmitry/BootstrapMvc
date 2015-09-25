using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public interface IModelValidationResult
    {
        bool IsValid { get; }

        IEnumerable<IModelValidationError> ModelErrors { get; }

        IDictionary<string, IEnumerable<IModelValidationError>> PropertyErrors { get; }
    }
}
