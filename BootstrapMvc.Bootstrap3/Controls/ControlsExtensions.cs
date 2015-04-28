using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ControlsExtensions
    {
        public static T Required<T>(this T target, bool required = true) where T : IControlContext
        {
            target.IsRequired = required;
            return target;
        }
    }
}
