namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public class HelpBlock : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("span");
            tb.AddCssClass("help-block");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
