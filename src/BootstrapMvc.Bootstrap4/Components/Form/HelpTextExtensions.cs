namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public static class HelpTextExtensions
    {
        public static IItemWriter<HelpText, AnyContent> HelpText(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.CreateWriter<HelpText, AnyContent>().Content(contents);
        }

        public static AnyContent BeginHelpText(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<HelpText, AnyContent>().BeginContent();
        }
    }
}
