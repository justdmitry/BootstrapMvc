namespace BootstrapMvc.Lists
{
    using System;
    using BootstrapMvc.Core;

    public class DefinitionList : ContentElement<DefinitionListContent>
    {
        public bool Horizontal { get; set; }

        protected override DefinitionListContent CreateContentContext(IBootstrapContext context)
        {
            return new DefinitionListContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("dl");
            if (Horizontal)
            {
                tb.AddCssClass("dl-horizontal");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</dl>");
        }
    }
}
