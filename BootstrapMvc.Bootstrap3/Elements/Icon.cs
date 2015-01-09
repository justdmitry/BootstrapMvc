using BootstrapMvc;
using BootstrapMvc.Core;

namespace BootstrapMvc.Elements
{
    public class Icon : Element
    {
        private IconType type;

        private bool noSpacing = false;

        public Icon(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Icon Type(IconType value)
        {
            this.type = value;
            return this;
        }

        public Icon NoSpacing(bool noSpacing = true)
        {
            this.noSpacing = noSpacing;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("i");
            tb.AddCssClass(type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            if (!noSpacing)
            {
                writer.Write(" ");
            }

            writer.Write(tb.GetFullTag());

            if (!noSpacing)
            {
                writer.Write(" ");
            }
        }
    }
}
