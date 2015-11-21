namespace BootstrapMvc
{
    using System;

    public class TableHeader : TableSection
    {
        public static TableHeaderStyles DefaultStyles { get; set; } = TableHeaderStyles.Default;

        public TableHeaderStyles Style { get; set; } = DefaultStyles;

        protected override string GetTagName()
        {
            return "thead";
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            AddCssClass(Style.ToCssClass());
            base.WriteSelfStart(writer);
        }
    }
}
