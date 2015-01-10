using System.Web;
using BootstrapMvc.Core;
using BootstrapMvc.Dropdown;

namespace BootstrapMvc.Buttons
{
    public class Button : AnyContentElement, IDropdownMenuParentMarker, ILink<Button>
    {
        private ButtonType type;

        private ButtonSize size;

        private bool blockSize;

        private bool disabled;

        private string href;

        public Button(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public Button Type(ButtonType value)
        {
            this.type = value;
            return this;
        }

        public Button Size(ButtonSize value)
        {
            this.size = value;
            return this;
        }

        public Button BlockSize(bool value = true)
        {
            this.blockSize = value;
            return this;
        }

        public Button Disabled(bool value = true)
        {
            this.disabled = value;
            return this;
        }

        public Button Href(string value)
        {
            this.href = value;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var withHref = !string.IsNullOrEmpty(href);
            var tb = Context.CreateTagBuilder(withHref ? "a" : "button");

            tb.AddCssClass(type.ToCssClass());
            tb.AddCssClass(size.ToButtonCssClass());

            if (disabled)
            {
                tb.AddCssClass("disabled");
            }
            if (blockSize)
            {
                tb.AddCssClass("btn-block");
            }
            if (withHref)
            {
                tb.MergeAttribute("href", href);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return withHref ? "</a>" : "</button>";
        }
    }
}
