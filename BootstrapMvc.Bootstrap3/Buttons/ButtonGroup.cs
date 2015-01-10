using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroup : ContentElement<ButtonGroupContent>
    {
        private ButtonSize size;

        private bool vertical;

        private bool dropUp;

        private bool justified;

        private WritableBlock content;

        public ButtonGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public ButtonGroup Size(ButtonSize value)
        {
            this.size = value;
            return this;
        }

        public ButtonGroup Vertical(bool vertical = true)
        {
            this.vertical = vertical;
            return this;
        }

        public ButtonGroup DropUp(bool dropUp = true)
        {
            this.dropUp = dropUp;
            return this;
        }

        public ButtonGroup Justified(bool justified = true)
        {
            this.justified = justified;
            return this;
        }

        #endregion

        public ButtonGroup AddButton(Button value)
        {
            if (value == null)
            {
                return this;
            } 
            value.WriteWhitespaceSuffix(false);
            if (content == null)
            {
                content = value;
            }
            else
            {
                content.Append(value);
            }
            return this;
        }

        public ButtonGroup AddButton(params Button[] values)
        {
            if (values == null || values.Length == 0)
            {
                return this;
            }
            foreach (var value in values)
            {
                value.WriteWhitespaceSuffix(false);
                if (content == null)
                {
                    content = value;
                }
                else
                {
                    content.Append(value);
                }
            }
            return this;
        }

        protected override ButtonGroupContent CreateContent()
        {
            return new ButtonGroupContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("btn-group");
            tb.AddCssClass(size.ToButtonGroupCssClass());
            if (vertical)
            {
                tb.AddCssClass("btn-group-vertical");
            }
            if (justified)
            {
                tb.AddCssClass("btn-group-justified");
            }
            if (dropUp)
            {
                tb.AddCssClass("dropup");
            }
            tb.MergeAttribute("role", "group");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (content != null)
            {
                content.WriteTo(writer);
            }

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
