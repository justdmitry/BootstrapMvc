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
            tb.MergeAttribute("role", "alert");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Closable)
            {
                var dsmb = Helper.CreateTagBuilder("button");
                dsmb.MergeAttribute("type", "button");
                dsmb.MergeAttribute("class", "close");
                dsmb.MergeAttribute("data-dismiss", "alert");
                dsmb.MergeAttribute("aria-hidden", "true");
                dsmb.InnerHtml = "&times;";
                dsmb.WriteFullTag(writer);
            }

            return tb.GetEndTag();
        }
    }
}
