using System;
using System.IO;
using Microsoft.Framework.WebEncoders;
using mvc = Microsoft.AspNet.Mvc.Rendering;

namespace BootstrapMvc.Core
{
    public class TagBuilder : mvc.TagBuilder, ITagBuilder
    {
        public TagBuilder(string tagName, IHtmlEncoder htmlEncoder)
            : base(tagName)
        {
            this.HtmlEncoder = htmlEncoder;
        }

        public IHtmlEncoder HtmlEncoder { get; set; }

        string ITagBuilder.InnerHtml
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetInnerText(string text)
        {
            throw new NotImplementedException();
        }

        public new void AddCssClass(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                base.AddCssClass(value);
            }
        }

        public string GetStartTag()
        {
            using (var sw = new StringWriter())
            {
                WriteStartTag(sw);
                return sw.ToString();
            }
        }

        public string GetEndTag()
        {
            using (var sw = new StringWriter())
            {
                WriteEndTag(sw);
                return sw.ToString();
            }
        }

        public string GetFullTag()
        {
            using (var sw = new StringWriter())
            {
                WriteFullTag(sw);
                return sw.ToString();
            }
        }

        public void WriteStartTag(TextWriter writer)
        {
            TagRenderMode = mvc.TagRenderMode.StartTag;
            WriteTo(writer, HtmlEncoder);
        }

        public void WriteEndTag(TextWriter writer)
        {
            TagRenderMode = mvc.TagRenderMode.EndTag;
            WriteTo(writer, HtmlEncoder);
        }

        public void WriteFullTag(TextWriter writer)
        {
            TagRenderMode = mvc.TagRenderMode.Normal;
            WriteTo(writer, HtmlEncoder);
        }
    }
}
