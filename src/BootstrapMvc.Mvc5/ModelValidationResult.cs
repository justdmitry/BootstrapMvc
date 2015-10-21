namespace BootstrapMvc.Mvc5
{
    using Core;
    using System;
    using System.Collections.Generic;

    public class ModelValidationResult : IModelValidationResult
    {
        public bool IsValid { get; set; }

        public IEnumerable<IModelValidationError> ModelErrors { get; set; }

        public IDictionary<string, IEnumerable<IModelValidationError>> PropertyErrors { get; set; }
    }
}
