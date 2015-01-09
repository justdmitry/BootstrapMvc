using System;
using mvc = System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class TagBuilder : mvc.TagBuilder, ITagBuilder
    {
        public TagBuilder (string tagName)
            : base (tagName)
        {
            // Nothing
        }

        public string GetStartTag()
        {
            return base.ToString(mvc.TagRenderMode.StartTag);
        }

        public string GetEndTag()
        {
            return base.ToString(mvc.TagRenderMode.EndTag);
        }

        public string GetFullTag()
        {
            return base.ToString(mvc.TagRenderMode.Normal);
        }
    }
}
