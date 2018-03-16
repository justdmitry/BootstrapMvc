namespace BootstrapMvc.Tables
{
    using System;

    public class TableBody : TableSection
    {
        protected override string GetTagName()
        {
            return "tbody";
        }
    }
}
