namespace BootstrapMvc.Panels
{
    using System;
    using BootstrapMvc.Core;

    public class Panel : ContentElement<PanelContent>
    {
        public PanelHeader PanelHeader { get; set; }

        public PanelBody PanelBody { get; set; }

        public PanelFooter PanelFooter { get; set; }

        public PanelType Type { get; set; }

        protected override PanelContent CreateContentContext(IBootstrapContext context)
        {
            return new PanelContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(Type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (PanelHeader != null)
            {
                PanelHeader.Parent = this;
                PanelHeader.WriteTo(writer);
            }
            if (PanelBody != null)
            {
                PanelBody.Parent = this;
                PanelBody.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            if (PanelFooter != null)
            {
                PanelFooter.Parent = this;
                PanelFooter.WriteTo(writer);
            }
            writer.Write("</div>");
        }
    }
}
