using System;

namespace BootstrapMvc.Core
{
    public class OrdinaryElement : AnyContentElement
    {
        private string tagName;

        public OrdinaryElement(string tagName)
        {
            this.tagName = tagName;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder(tagName);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
