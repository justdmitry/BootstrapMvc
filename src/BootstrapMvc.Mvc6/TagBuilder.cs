namespace BootstrapMvc.Mvc6
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.Encodings.Web;

    using mvc = Microsoft.AspNetCore.Mvc.Rendering;

    using BootstrapMvc.Core;

    public class TagBuilder : mvc.TagBuilder, ITagBuilder
    {
        public TagBuilder(string tagName, HtmlEncoder htmlEncoder)
            : base(tagName)
        {
            this.HtmlEncoder = htmlEncoder;
        }

        public HtmlEncoder HtmlEncoder { get; set; }

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
            ValidateAttributes();
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
            ValidateAttributes();
            TagRenderMode = mvc.TagRenderMode.Normal;
            WriteTo(writer, HtmlEncoder);
        }

        public void SetInnerText(string text)
        {
            InnerHtml.Clear();
            if (!string.IsNullOrEmpty(text))
            {
                InnerHtml.Append(text);
            }
        }

        // workaround for https://github.com/aspnet/Mvc/issues/4710
        protected void ValidateAttributes()
        {
            var empty = Attributes.Where(x => x.Value == null).ToArray();
            foreach(var attr in empty)
            {
                Attributes[attr.Key] = string.Empty;
            }
        }
    }
}
