using System;
using System.Linq.Expressions;

namespace BootstrapMvc.Core
{
    public interface IBootstrapContext<TModel> : IBootstrapContext
    {
        IControlContext GetControlContext<TProperty>(Expression<Func<TModel, TProperty>> expression);

        IModelValidationResult ValidationResult { get; }
    }
}
