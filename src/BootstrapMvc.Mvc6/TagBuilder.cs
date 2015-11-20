using System;
using System.IO;
using Microsoft.Extensions.WebEncoders;
using mvc = Microsoft.AspNet.Mvc.Rendering;
using BootstrapMvc.Core;

namespace BootstrapMvc.Mvc6
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
                return InnerHtml.ToString();
            }

            set
            {
                InnerHtml.Clear();
                if (!string.IsNullOrEmpty(value)) {
                    InnerHtml.AppendHtml(value);
                }
            }
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

        public void SetInnerText(string text)
        {
            InnerHtml.Clear();
            if (!string.IsNullOrEmpty(text))
            {
                InnerHtml.Append(new mvc.HtmlString(text));
            }
        }
    }
}
