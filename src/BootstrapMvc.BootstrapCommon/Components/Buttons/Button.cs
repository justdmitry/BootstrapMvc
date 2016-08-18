namespace BootstrapMvc.Buttons
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Dropdown;

    public class Button : AnyContentElement, IDropdownMenuParentMarker, ILink, IButtonSizable, IDisableable
    {
        public ButtonType Type { get; set; }

        public ButtonSize Size { get; set; }

        public bool BlockSize { get; set; }

#if BOOTSTRAP4
        public bool Outline { get; set; }
#endif

        public bool Disabled { get; set; }

        public string Href { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var buttonGroupContext = GetNearestParent<ButtonGroup>();

            if (buttonGroupContext == null)
            {
                WithWhitespaceSuffix = true;
            }
            else
            {
                Size = buttonGroupContext.Size;
            }

            var withHref = !string.IsNullOrEmpty(Href);
            var tb = Helper.CreateTagBuilder(withHref ? "a" : "button");

            var typeClass = Type.ToCssClass();
#if BOOTSTRAP4
            if (Outline) 
            {
                typeClass = typeClass.Replace("btn-", "btn-outline-");
            }
#endif
            tb.AddCssClass(typeClass);

            tb.AddCssClass(Size.ToButtonCssClass());

            if (Disabled)
            {
                tb.AddCssClass("disabled");
            }
            if (BlockSize)
            {
                tb.AddCssClass("btn-block");
            }
            if (withHref)
            {
                tb.MergeAttribute("href", Href, true);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return withHref ? "</a>" : "</button>";
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
