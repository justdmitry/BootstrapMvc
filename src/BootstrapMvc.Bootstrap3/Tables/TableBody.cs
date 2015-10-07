using System;

namespace BootstrapMvc.Tables
{
    public class TableBody : TableSection
    {
        protected override string GetTagName()
        {
            return "tbody";
        }
    }
}
