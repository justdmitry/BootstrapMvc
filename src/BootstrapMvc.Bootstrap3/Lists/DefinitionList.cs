using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class DefinitionList : ContentElement<DefinitionListContent>
    {
        public DefinitionList(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public bool HorizontalValue { get; set; }

        protected override DefinitionListContent CreateContentContext()
        {
            return new DefinitionListContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("dl");
            if (HorizontalValue)
            {
                tb.AddCssClass("dl-horizontal");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</dl>");
        }
    }
}
