using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Alert : AnyContentElement
    {
        private AlertType type;

        private bool closable;

        public Alert(IBootstrapContext context) 
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Alert Type(AlertType value)
        {
            this.type = value;
            return this;
        }

        public Alert Closable(bool closable = true)
        {
            this.closable = closable;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(type.ToCssClass());
            if (closable)
            {
                tb.AddCssClass("alert-dismissable");
            }
            tb.MergeAttribute("role", "alert");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (closable)
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
