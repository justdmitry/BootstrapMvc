namespace BootstrapMvc.ListGroups
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    public class ListGroupLinkItem : AnyContentElement, IListGroupElement, ILink
    {
        public ListGroupItemType Type { get; set; }

        public bool Active { get; set; }

        public bool Disabled { get; set; }

        public string Href { get; set; }

        protected override string WriteSelfStartTag(TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("a");

            tb.MergeAttribute("href", Href, true);

            tb.AddCssClass("list-group-item");

#if BOOTSTRAP4
            tb.AddCssClass("list-group-item-action");
#endif

            tb.AddCssClass(Type.ToCssClass());

            if (Active)
            {
                tb.AddCssClass("active");
            }

            if (Disabled)
            {
                tb.AddCssClass("disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }

        void IActivable.SetActive(bool active)
        {
            Active = active;
        }

        bool IActivable.Active()
        {
            return Active;
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }

        void ILink.SetHref(string value)
        {
            Href = value;
        }
    }
}
