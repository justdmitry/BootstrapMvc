namespace BootstrapMvc.Tables
{
    using System;

    public class TableHeader : TableSection
    {
        protected override string GetTagName()
        {
            return "thead";
        }
    }
}
