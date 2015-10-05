using System;

namespace BootstrapMvc.Tables
{
    public class TableHeader : TableSection
    {
        protected override string GetTagName()
        {
            return "thead";
        }
    }
}
