namespace BootstrapMvc.Core
{
    using System;
    using System.Linq.Expressions;

    public interface IWritingHelper<TModel> : IWritingHelper
    {
        void FillControlContext<TProperty>(IControlContext target, Expression<Func<TModel, TProperty>> expression);

        IModelValidationResult ValidationResult { get; }
    }
}
