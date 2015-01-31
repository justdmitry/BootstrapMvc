using System;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class FormControlExtensions
    {
        public static T For<T>(this T target, IControlContext controlContext) where T : IFormControl
        {
            target.SetControlContext(controlContext);
            return target;
        }
        
        public static T Size<T>(this T target, GridSize size) where T : Element, ISizableControl
        {
            target.SetSize(size);
            return target;
        }
    }
}
