using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class DefinitionList : ContentElement<DefinitionListContent>
    {
        public bool HorizontalValue { get; set; }

        protected override DefinitionListContent CreateContentContext(IBootstrapContext context)
        {
            return new DefinitionListContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("dl");
            if (HorizontalValue)
            {
                tb.AddCssClass("dl-horizontal");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</dl>");
        }
    }
}
