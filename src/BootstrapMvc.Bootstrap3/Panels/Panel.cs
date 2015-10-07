using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class Panel : ContentElement<PanelContent>
    {
        private string endTag;

        public PanelHeader PanelHeaderValue { get; set; }

        public PanelBody PanelBodyValue { get; set; }

        public PanelFooter PanelFooterValue { get; set; }

        public PanelType TypeValue { get; set; }

        protected override PanelContent CreateContentContext(IBootstrapContext context)
        {
            return new PanelContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass(TypeValue.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (PanelHeaderValue != null)
            {
                PanelHeaderValue.WriteTo(writer, context);
            }
            if (PanelBodyValue != null)
            {
                PanelBodyValue.WriteTo(writer, context);
            }

            endTag = tb.GetEndTag();
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            if (PanelFooterValue != null)
            {
                PanelFooterValue.WriteTo(writer, context);
            }
            writer.Write(endTag);
        }
    }
}
