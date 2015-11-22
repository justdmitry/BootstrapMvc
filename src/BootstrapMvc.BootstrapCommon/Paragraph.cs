namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class Paragraph : OrdinaryElement
    {
        public bool Lead { get; set; }

        public Paragraph()
        {
            TagName = "p";
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            if (Lead)
            {
                AddCssClass("lead");
            }

            return base.WriteSelfStartTag(writer);
        }
    }
}
