namespace BootstrapMvc.Buttons
{
    using BootstrapMvc.Core;
    using BootstrapMvc.Dropdown;

    public class Button : AnyContentElement, IDropdownMenuParentMarker, ILink, IButtonSizable, IDisableable, IColor8Type
    {
        public Color8 Type { get; set; }

        public ButtonSize Size { get; set; }

        public bool BlockSize { get; set; }

        public bool Outline { get; set; }

        public bool Disabled { get; set; }

        public string Href { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var buttonGroupContext = GetNearestParent<ButtonGroup>();

            if (buttonGroupContext == null)
            {
                WithWhitespaceSuffix = true;
            }

            var withHref = !string.IsNullOrEmpty(Href);
            var tb = Helper.CreateTagBuilder(withHref ? "a" : "button");

            var typeClass = "btn btn-" + Type.ToCssClassSubstring();

            if (Outline)
            {
                typeClass = typeClass.Replace("btn-", "btn-outline-");
            }

            tb.AddCssClass(typeClass);

            tb.AddCssClass(Size.ToButtonCssClass());

            if (Disabled)
            {
                tb.AddCssClass("disabled");
                tb.MergeAttribute("aria-disabled", "true", true);
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

        void ILink.SetHref(string value)
        {
            Href = value;
        }
    }
}
