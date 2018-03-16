namespace BootstrapMvc.Tables
{
    using System;

    public class TableFooter : TableSection
    {
        protected override string GetTagName()
        {
            return "tfoot";
        }
    }
}
