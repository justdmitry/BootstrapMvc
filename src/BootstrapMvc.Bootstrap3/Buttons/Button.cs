using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc.Buttons
{
    public class Button : AnyContentElement, IDropdownMenuParentMarker, ILink, IButtonSizable, IDisableable
    {
        public ButtonType TypeValue { get; set; }

        public ButtonSize SizeValue { get; set; }

        public bool BlockSizeValue { get; set; }

        public bool DisabledValue { get; set; }

        public string HrefValue { get; set; }

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
            var bg = context.PeekNearest<ButtonGroup>();
            if (bg == null)
            {
                WriteWhitespaceSuffix = true;
            }
            else
            {
                SizeValue = bg.SizeValue;
            }

            var withHref = !string.IsNullOrEmpty(HrefValue);
            var tb = context.CreateTagBuilder(withHref ? "a" : "button");

            tb.AddCssClass(TypeValue.ToCssClass());
            tb.AddCssClass(SizeValue.ToButtonCssClass());

            if (DisabledValue)
            {
                tb.AddCssClass("disabled");
            }
            if (BlockSizeValue)
            {
                tb.AddCssClass("btn-block");
            }
            if (withHref)
            {
                tb.MergeAttribute("href", HrefValue);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return withHref ? "</a>" : "</button>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
