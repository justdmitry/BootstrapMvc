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
    }
}
