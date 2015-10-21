namespace BootstrapMvc.Core
{
    using System;
    using System.Collections.Generic;

    public interface IModelValidationResult
    {
        bool IsValid { get; }

        IEnumerable<IModelValidationError> ModelErrors { get; }

        IDictionary<string, IEnumerable<IModelValidationError>> PropertyErrors { get; }
    }
}
