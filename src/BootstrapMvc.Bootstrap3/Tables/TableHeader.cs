namespace BootstrapMvc
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
