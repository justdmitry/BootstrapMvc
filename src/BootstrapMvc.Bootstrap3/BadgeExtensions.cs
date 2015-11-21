namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class BadgeExtensions
    {
        #region Generation

        public static IItemWriter<Badge, AnyContent> Badge(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.CreateWriter<Badge, AnyContent>().Content(content);
        }

        #endregion
    }
}
