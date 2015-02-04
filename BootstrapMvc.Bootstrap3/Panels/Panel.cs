using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class Panel : ContentElement<PanelContent>
    {
        private WritableBlock header;
        private WritableBlock body;
        private WritableBlock footer;

        private PanelType type;

        private WritableBlock endTag;

        public Panel(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        #region Fluent

        public Panel Type(PanelType type)
        {
            this.type = type;
            return this;
        }

        public Panel Header(PanelHeader value)
        {
            header = value;
            return this;
        }

        public Panel Header(object value)
        {
            header = new PanelHeader(Context).Content(value);
            return this;
        }

        public Panel Header(params object[] values)
        {
            header = new PanelHeader(Context).Content(values);
            return this;
        }

        public Panel Body(PanelBody value)
        {
            body = value;
            return this;
        }

        public Panel Body(object value)
        {
            body = new PanelBody(Context).Content(value);
            return this;
        }

        public Panel Body(params object[] values)
        {
            body = new PanelBody(Context).Content(values);
            return this;
        }

        public Panel Footer(PanelFooter value)
        {
            footer = value;
            return this;
        }

        public Panel Footer(object value)
        {
            footer = new PanelFooter(Context).Content(value);
            return this;
        }

        public Panel Footer(params object[] values)
        {
            footer = new PanelFooter(Context).Content(values);
            return this;
        }

        #endregion

        protected override PanelContent CreateContentContext()
        {
            return new PanelContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(type.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (header != null)
            {
                header.WriteTo(writer);
            }
            if (body != null)
            {
                body.WriteTo(writer);
            }

            var end = new Content(Context).Value(tb.GetEndTag(), true);
            if (footer == null)
            {
                endTag = end;
            }
            else
            {
                footer.Append(end);
                endTag = footer;
            }
        }


        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            endTag.WriteTo(writer);
        }
    }
}
