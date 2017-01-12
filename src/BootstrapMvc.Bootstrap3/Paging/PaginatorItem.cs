namespace BootstrapMvc.Paging
{
    using System;
    using BootstrapMvc.Core;

    public class PaginatorItem : AnyContentElement, ILink, IDisableable, IActivable
    {
        public string Href { get; set; }

        public bool Disabled { get; set; }

        public bool Active { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var li = Helper.CreateTagBuilder("li");

            if (Disabled)
            {
                li.AddCssClass("disabled");
            }
            else
            {
                if (Active)
                {
                    li.AddCssClass("active");
                }
            }

            li.WriteStartTag(writer);

            var link = Helper.CreateTagBuilder(Disabled ? "span" : "a");
            if (!Disabled)
            {
                link.MergeAttribute("href", Href, true);
            }

            link.WriteStartTag(writer);

            return link.GetEndTag() + li.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            Href = value;
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }

        void IActivable.SetActive(bool active)
        {
            Active = active;
        }

        bool IActivable.Active()
        {
            return Active;
        }
    }
}
