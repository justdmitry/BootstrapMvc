using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Paging
{
    public class PaginatorItem : AnyContentElement, ILink, IDisableable
    {
        public string HrefValue { get; set; }

        public bool DisabledValue { get; set; }

        public bool ActiveValue { get; set; }

        public void SetHref(string value)
        {
            HrefValue = value;
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var li = context.CreateTagBuilder("li");

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

            li.WriteStartTag(writer);

            var link = context.CreateTagBuilder(DisabledValue ? "span" : "a");
            if (!DisabledValue)
            {
                link.MergeAttribute("href", HrefValue);
            }

            link.WriteStartTag(writer);

            return link.GetEndTag() + li.GetEndTag();
        }
    }
}
