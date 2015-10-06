using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class HelpBlock : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("span");
            tb.AddCssClass("help-block");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
