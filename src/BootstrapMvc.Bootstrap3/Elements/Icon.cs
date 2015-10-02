using BootstrapMvc;
using BootstrapMvc.Core;

namespace BootstrapMvc.Elements
{
    public class Icon : Element
    {
        public IconType TypeValue { get; set; }

        public bool NoSpacingValue { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("i");
            tb.AddCssClass(TypeValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            if (!NoSpacingValue)
            {
                writer.Write(" ");
            }

            tb.WriteFullTag(writer);

            if (!NoSpacingValue)
            {
                writer.Write(" ");
            }
        }
    }
}
