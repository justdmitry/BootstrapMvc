using System;

namespace BootstrapMvc.Core
{
    public class OrdinaryElement : AnyContentElement
    {
        public string TagName { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder(TagName);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
