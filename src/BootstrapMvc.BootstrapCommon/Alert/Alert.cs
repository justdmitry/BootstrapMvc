namespace BootstrapMvc
{
    using BootstrapMvc.Core;

    public class Alert : AnyContentElement
    {
        public AlertType Type { get; set; }

        public bool Closable { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(Type.ToCssClass());
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
#if BOOTSTRAP3
                dsmb.MergeAttribute("aria-hidden", "true", true);
                dsmb.InnerHtml = "&times;";
#endif
#if BOOTSTRAP4
                dsmb.InnerHtml = "<span aria-hidden=\"true\">&times;</span>";
#endif
                dsmb.WriteFullTag(writer);
            }

            return tb.GetEndTag();
        }
    }
}
