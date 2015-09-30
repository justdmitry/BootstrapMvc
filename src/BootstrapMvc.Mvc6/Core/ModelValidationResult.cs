using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public class ModelValidationResult : IModelValidationResult
    {
        public bool IsValid { get; set; }

        public IEnumerable<IModelValidationError> ModelErrors { get; set; }

        public IDictionary<string, IEnumerable<IModelValidationError>> PropertyErrors { get; set; }
    }
}
