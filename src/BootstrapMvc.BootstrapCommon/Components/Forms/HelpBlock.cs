namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public class HelpBlock : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
#if BOOTSTRAP3
            var tb = Helper.CreateTagBuilder("span");
            tb.AddCssClass("help-block");
#else
            var tb = Helper.CreateTagBuilder("p");
            tb.AddCssClass("form-text");
#endif

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
