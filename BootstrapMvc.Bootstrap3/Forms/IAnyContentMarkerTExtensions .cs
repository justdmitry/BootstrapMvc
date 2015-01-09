using System;
using System.Linq.Expressions;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerTExtensions
    {
        public static FormGroup FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return new FormGroup(contentHelper.Context).ControlContext(contentHelper.Context.GetControlContext(expression));
        }
    }
}
