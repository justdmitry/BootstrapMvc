namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DefinitionListTerm : AnyContentElement, IGridSizable
    {
        public GridSize Size { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("dt");

            if (!Size.IsEmpty())
            { 
                tb.AddCssClass(Size.ToCssClass());
            }
            else
            {
                var list = GetNearestParent<DefinitionList>();
                if (list != null && !list.TermSize.IsEmpty())
                {
                    tb.AddCssClass(list.TermSize.ToCssClass());
                }
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return "</dt>";
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
