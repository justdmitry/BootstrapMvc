namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class HelpBlockExtensions
    {
        #region Generation

        public static IItemWriter<HelpBlock, AnyContent> HelpBlock(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.CreateWriter<HelpBlock, AnyContent>().Content(content);
        }

        public static IItemWriter<HelpBlock, AnyContent> HelpBlock(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.CreateWriter<HelpBlock, AnyContent>().Content(contents);
        }

        public static AnyContent BeginHelpBlock(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<HelpBlock, AnyContent>().BeginContent();
        }

        #endregion
    }
}
