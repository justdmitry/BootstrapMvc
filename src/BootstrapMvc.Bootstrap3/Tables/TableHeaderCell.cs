namespace BootstrapMvc.Tables
{
    using System;
    using BootstrapMvc.Core;

    public class TableHeaderCell : TableCell
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("th");
            if (Color != TableRowCellColor.DefaultNone)
            {
                tb.AddCssClass(Color.ToCssClass());
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
