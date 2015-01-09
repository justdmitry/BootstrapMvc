using System;
using System.Linq.Expressions;

namespace BootstrapMvc.Core
{
    public interface IBootstrapContext<TModel> : IBootstrapContext
    {
        TModel Model { get; }

        IControlContext GetControlContext<TProperty>(Expression<Func<TModel, TProperty>> expression);
    }
}
