using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class Label : AnyContentElement
    {
        private LabelType type;
        
        public Label(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Label Type(LabelType value)
        {
            this.type = value;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("span");
            tb.AddCssClass(type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
