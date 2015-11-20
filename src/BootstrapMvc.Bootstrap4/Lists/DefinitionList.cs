namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DefinitionList : ContentElement<DefinitionListContent>
    {
        public static GridSize TermSizeDefault = GridSize.Empty;

        public static GridSize DescriptionSizeDefault = GridSize.Empty;

        public bool Horizontal { get; set; }

        public GridSize TermSize { get; set; } = TermSizeDefault;

        public GridSize DescriptionSize { get; set; } = DescriptionSizeDefault;

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
