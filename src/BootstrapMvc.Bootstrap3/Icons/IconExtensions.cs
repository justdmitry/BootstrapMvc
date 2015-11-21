namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static partial class IconExtensions
    {
        #region Fluent

        public static IItemWriter<T> Type<T>(this IItemWriter<T> target, IconType value) where T : Icon
        {
            target.Item.Type = value;
            return target;
        }

        public static IItemWriter<T> NoSpacing<T>(this IItemWriter<T> target, bool value = true) where T :Icon
        {
            target.Item.NoSpacing = value;
            return target;
        }

        #endregion

        public static IItemWriter<Icon> Icon(this IAnyContentMarker contentHelper, IconType type)
        {
            return contentHelper.CreateWriter<Icon>().Type(type);
        }
    }
}
