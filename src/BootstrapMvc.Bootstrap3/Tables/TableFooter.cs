using System;

namespace BootstrapMvc.Tables
{
    public class TableFooter : TableSection
    {
        protected override string GetTagName()
        {
            return "tfoot";
        }
    }
}
