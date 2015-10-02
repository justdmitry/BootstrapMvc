using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class BadgeExtensions
    {
        #region Generation

        public static IWriter2<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Context.CreateWriter<Badge, AnyContent>().Content(content);
        }

        #endregion
    }
}
