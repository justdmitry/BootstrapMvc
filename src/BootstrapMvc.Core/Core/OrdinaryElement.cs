namespace BootstrapMvc.Core
{
    using System;

    public class OrdinaryElement : AnyContentElement
    {
        public string TagName { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder(TagName);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
