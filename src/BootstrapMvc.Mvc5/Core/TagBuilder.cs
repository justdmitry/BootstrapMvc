using System;
using System.IO;
using mvc = System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class TagBuilder : mvc.TagBuilder, ITagBuilder
    {
        public TagBuilder(string tagName)
            : base(tagName)
        {
            // Nothing
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
            return ToString(mvc.TagRenderMode.StartTag);
        }

        public string GetEndTag()
        {
            return ToString(mvc.TagRenderMode.EndTag);
        }

        public string GetFullTag()
        {
            return ToString(mvc.TagRenderMode.Normal);
        }

        public void WriteStartTag(TextWriter writer)
        {
            writer.Write(GetStartTag());
        }

        public void WriteEndTag(TextWriter writer)
        {
            writer.Write(GetEndTag());
        }

        public void WriteFullTag(TextWriter writer)
        {
            writer.Write(GetFullTag());
        }
    }
}
