namespace BootstrapMvc.Tables
{
    using System;
    using System.IO;

    public partial class TableHeader
    {
        public TableHeaderStyle Style { get; set; }

        protected override void WriteSelfStart(TextWriter writer)
        {
            AddCssClass(Style.ToCssClass());

            base.WriteSelfStart(writer);
        }
    }
}
