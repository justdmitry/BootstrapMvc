namespace BootstrapMvc.Tables
{
    using System;
    using System.IO;

    public partial class TableHeader : TableSection
    {
        public TableHeaderColor Color { get; set; } = TableHeaderColor.None;

        protected override string GetTagName()
        {
            return "thead";
        }

        protected override void WriteSelfStart(TextWriter writer)
        {
            switch (Color)
            {
                case TableHeaderColor.Light:
                    base.AddCssClass("thead-light");
                    break;
                case TableHeaderColor.Dark:
                    base.AddCssClass("thead-dark");
                    break;
            }

            base.WriteSelfStart(writer);
        }
    }
}
