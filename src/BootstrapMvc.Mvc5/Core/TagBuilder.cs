using System;
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
    }
}
