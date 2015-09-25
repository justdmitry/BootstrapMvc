using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class PaginatorItem : AnyContentElement, ILink
    {
        public PaginatorItem(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public string HrefValue { get; set; }

        public bool DisabledValue { get; set; }

        public bool ActiveValue { get; set; }

        public void SetHref(string value)
        {
            HrefValue = value;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var li = Context.CreateTagBuilder("li");

            if (DisabledValue)
            {
                li.AddCssClass("disabled");
            }
            else
            {
                if (ActiveValue)
                {
                    li.AddCssClass("active");
                }
            }

            writer.Write(li.GetStartTag());

            var link = Context.CreateTagBuilder(DisabledValue ? "span" : "a");
            if (!DisabledValue)
            {
                link.MergeAttribute("href", HrefValue);
            }

            writer.Write(link.GetStartTag());

            return link.GetEndTag() + li.GetEndTag();
        }
    }
}
