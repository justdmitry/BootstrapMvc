using System;

namespace BootstrapMvc.Core
{
    public class OrdinaryElement : AnyContentElement
    {
        private string tagName;

        public OrdinaryElement(IBootstrapContext context, string tagName)
            : base(context)
        {
            this.tagName = tagName;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder(tagName);

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
