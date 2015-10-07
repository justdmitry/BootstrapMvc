using System;
using BootstrapMvc.Core;
using BootstrapMvc.Controls;

namespace BootstrapMvc
{
    public static class TextareaExtensions
    {
        #region Fluent

        public static IWriter<T> Rows<T>(this IWriter<T> target, int value)
            where T : Textarea
        {
            target.Item.RowsValue = value;
            return target;
        }

        #endregion

        #region Generating

        public static IWriter<Textarea> Textarea(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<Textarea>();
        }

        #endregion
    }
}
