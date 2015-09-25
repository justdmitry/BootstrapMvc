using System;
using System.Collections.Generic;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class ControlContextHolderExtensions
    {
        public static T ControlContext<T>(T target, IControlContext context) where T : IControlContextHolder
        {
            target.SetControlContext(context);
            return target;
        }
    }
}
