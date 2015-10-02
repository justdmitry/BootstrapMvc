using System;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc
{
    public static partial class IconExtensions
    {
        #region Fluent

        public static IWriter<T> Type<T>(this IWriter<T> target, IconType value) where T : Icon
        {
            target.Item.TypeValue = value;
            return target;
        }

        public static IWriter<T> NoSpacing<T>(this IWriter<T> target, bool value = true) where T :Icon
        {
            target.Item.NoSpacingValue = value;
            return target;
        }

        #endregion

        public static IWriter<Icon> Icon(this IAnyContentMarker contentHelper, IconType type)
        {
            return contentHelper.Context.CreateWriter<Icon>().Type(type);
        }
    }
}
