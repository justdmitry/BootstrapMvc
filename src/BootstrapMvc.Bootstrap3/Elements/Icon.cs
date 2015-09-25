using BootstrapMvc;
using BootstrapMvc.Core;

namespace BootstrapMvc.Elements
{
    public class Icon : Element
    {
        public Icon(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IconType TypeValue { get; set; }

        public bool NoSpacingValue { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("i");
            tb.AddCssClass(TypeValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            if (!NoSpacingValue)
            {
                writer.Write(" ");
            }

            writer.Write(tb.GetFullTag());

            if (!NoSpacingValue)
            {
                writer.Write(" ");
            }
        }
    }
}
