namespace BootstrapMvc.Mvc5
{
    using Core;
    using System;

    public class ModelValidationError : IModelValidationError
    {
        public ModelValidationError(string message)
            : this(message, false)
        {
            // Nothing
        }

        public ModelValidationError (string message, bool isWarning)
        {
            this.Message = message;
            this.IsWarning = isWarning;
        }

        public string Message { get; protected set; }

        public bool IsWarning { get; protected set; }
    }
}
