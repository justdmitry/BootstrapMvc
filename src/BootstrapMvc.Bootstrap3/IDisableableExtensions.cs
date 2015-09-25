using System;

namespace BootstrapMvc
{
    public static class IDisableableExtensions
    {
        public static T Disabled<T>(this T target, bool disabled = true) where T : IDisableable
        {
            target.SetDisabled(disabled);
            return target;
        }
    }
}
