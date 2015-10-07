using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static class HelpBlockExtensions
    {
        #region Generation

        public static IWriter2<HelpBlock, AnyContent> HelpBlock(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.Context.CreateWriter<HelpBlock, AnyContent>().Content(content);
        }

        public static IWriter2<HelpBlock, AnyContent> HelpBlock(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.Context.CreateWriter<HelpBlock, AnyContent>().Content(contents);
        }

        public static AnyContent BeginHelpBlock(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<HelpBlock, AnyContent>().BeginContent();
        }

        #endregion
    }
}
