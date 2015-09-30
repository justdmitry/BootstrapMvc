using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc.Buttons
{
    public class Button : AnyContentElement, IDropdownMenuParentMarker, ILink
    {
        public Button(IBootstrapContext context)
            : base(context)
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
        }

        public ButtonType TypeValue { get; set; }

        public ButtonSize SizeValue { get; set; }

        public bool BlockSizeValue { get; set; }

        public bool DisabledValue { get; set; }

        public string HrefValue { get; set; }
        
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var withHref = !string.IsNullOrEmpty(HrefValue);
            var tb = Context.CreateTagBuilder(withHref ? "a" : "button");

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

            writer.Write(tb.GetStartTag());

            return withHref ? "</a>" : "</button>";
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
