using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ControlsExtensions
    {
        public static T Disabled<T>(this T target, bool disabled = true) where T : Element, IFormControl
        {
            target.Attribute("disabled", disabled ? "disabled" : string.Empty);
            return target;
        }

        public static T Placeholder<T>(this T target, string placeholder) where T : Element, IPlaceholderTarget
        {
            target.Attribute("placeholder", placeholder);
            return target;
        }

        public static T Required<T>(this T target, bool required = true) where T : IControlContext
        {
            target.IsRequired = required;
            return target;
        }
    }
}
