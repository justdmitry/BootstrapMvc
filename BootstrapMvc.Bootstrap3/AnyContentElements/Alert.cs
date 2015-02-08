using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Alert : AnyContentElement
    {
        public Alert(IBootstrapContext context) 
            : base(context)
        {
            // Nothing
        }

        public AlertType TypeValue { get; set; }

        public bool ClosableValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(TypeValue.ToCssClass());
            if (ClosableValue)
            {
                tb.AddCssClass("alert-dismissable");
            }
            tb.MergeAttribute("role", "alert");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (ClosableValue)
            {
                var dsmb = Context.CreateTagBuilder("button");
                dsmb.MergeAttribute("type", "button");
                dsmb.MergeAttribute("class", "close");
                dsmb.MergeAttribute("data-dismiss", "alert");
                dsmb.MergeAttribute("aria-hidden", "true");
                dsmb.InnerHtml = "&times;";
                writer.Write(dsmb.GetFullTag());
            }

            return tb.GetEndTag();
        }
    }
}
