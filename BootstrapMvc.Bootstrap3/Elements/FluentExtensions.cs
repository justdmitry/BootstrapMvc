using BootstrapMvc.Elements;
using System;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region Icon

        public static Icon Type(this Icon target, IconType value)
        {
            target.TypeValue = value;
            return target;
        }

        public static Icon NoSpacing(this Icon target, bool value = true)
        {
            target.NoSpacingValue = value;
            return target;
        }

        #endregion
    }
}
