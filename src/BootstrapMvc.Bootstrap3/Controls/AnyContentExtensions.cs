using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class AnyContentExtensions
    {
        public static IWriter<TControl> ControlFor<TModel, TProperty, TControl>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, IWriter<TControl> control)
            where TControl : IFormControl
        {
            return ControlContextHolderExtensions.ControlContext(control, contentHelper.Context.GetControlContext(expression));
        }
    }
}
