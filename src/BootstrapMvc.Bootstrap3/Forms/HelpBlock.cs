using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class HelpBlock : AnyContentElement
    {
        public HelpBlock(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("span");
            tb.AddCssClass("help-block");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
