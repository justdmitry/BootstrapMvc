namespace BootstrapMvc.Elements
{
    using BootstrapMvc;
    using BootstrapMvc.Core;

    public class Icon : Element
    {
        public IconType Type { get; set; }

        public bool NoSpacing { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("i");
            tb.AddCssClass(Type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            if (!NoSpacing)
            {
                writer.Write(" ");
            }

            tb.WriteFullTag(writer);

            if (!NoSpacing)
            {
                writer.Write(" ");
            }
        }
    }
}
