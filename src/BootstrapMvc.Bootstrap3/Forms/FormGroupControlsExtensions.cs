using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class FormGroupControlsExtensions
    {
        #region Fluent

        public static IWriter2<T, AnyContent> WithoutLabel<T>(this IWriter2<T, AnyContent> target, bool value = true)
            where T : FormGroupControls
        {
            target.Item.WithoutLabelValue = value;
            return target;
        }

        #endregion
    }
}
