namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;

    public static class TextareaExtensions
    {
        #region Fluent

        public static IItemWriter<T> Rows<T>(this IItemWriter<T> target, int value)
            where T : Textarea
        {
            target.Item.Rows = value;
            return target;
        }

        #endregion

        #region Generating

        public static IItemWriter<Textarea> Textarea(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Textarea>();
        }

        #endregion
    }
}
