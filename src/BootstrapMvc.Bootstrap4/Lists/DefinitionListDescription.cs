namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DefinitionListDescription : AnyContentElement, IGridSizable
    {
        public GridSize Size { get; set; }

        public GridSize Offset { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("dd");

            if (!Size.IsEmpty())
            { 
                tb.AddCssClass(Size.ToCssClass());
            }
            else
            {
                var list = GetNearestParent<DefinitionList>();
                if (list != null && !list.DescriptionSize.IsEmpty())
                {
                    tb.AddCssClass(list.DescriptionSize.ToCssClass());
                }
            }
            if (!Offset.IsEmpty())
            {
                tb.AddCssClass(Offset.ToOffsetCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return "</dd>";
        }

        GridSize IGridSizable.GetSize()
        {
            return Size;
        }

        void IGridSizable.SetSize(GridSize value)
        {
            Size = value;
        }
    }
}
