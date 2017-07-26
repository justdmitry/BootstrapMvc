namespace BootstrapMvc
{
    using System;
    using System.Linq.Expressions;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class HiddenValueExtensions
    {
        public static IItemWriter<HiddenValue> HiddenFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var fg = contentHelper.CreateWriter<HiddenValue>();
            contentHelper.Context.Helper.FillControlContext(fg.Item, expression);
            return fg;
        }
    }
}
