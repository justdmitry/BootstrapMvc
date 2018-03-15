namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Alert : AnyContentElement, IColor8Type
    {
        public Color8 Type { get; set; }

        public bool Closable { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("alert");
            tb.AddCssClass("alert-" + Type.ToCssClassSubstring());
            if (Closable)
            {
                tb.AddCssClass("alert-dismissable");
            }

            tb.MergeAttribute("role", "alert", true);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Closable)
            {
                var dsmb = Helper.CreateTagBuilder("button");
                dsmb.MergeAttribute("type", "button", true);
                dsmb.MergeAttribute("class", "close", true);
                dsmb.MergeAttribute("data-dismiss", "alert", true);
                dsmb.MergeAttribute("aria-label", "Close", true);
                dsmb.InnerHtml = "<span aria-hidden=\"true\">&times;</span>";
                dsmb.WriteFullTag(writer);
            }

            return tb.GetEndTag();
        }
    }
}
