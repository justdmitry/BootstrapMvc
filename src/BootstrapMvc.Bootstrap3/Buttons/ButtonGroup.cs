using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroup : ContentElement<ButtonGroupContent>
    {
        private WritableBlock content;

        public ButtonGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public ButtonSize SizeValue { get; set; }

        public bool VerticalValue { get; set; }

        public bool DropUpValue { get; set; }

        public bool JustifiedValue { get; set; }

        public ButtonGroup AddButton(Button value)
        {
            if (value == null)
            {
                return this;
            } 
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

        protected override ButtonGroupContent CreateContentContext()
        {
            return new ButtonGroupContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("btn-group");
            tb.AddCssClass(SizeValue.ToButtonGroupCssClass());
            if (VerticalValue)
            {
                tb.AddCssClass("btn-group-vertical");
            }
            if (JustifiedValue)
            {
                tb.AddCssClass("btn-group-justified");
            }
            if (DropUpValue)
            {
                tb.AddCssClass("dropup");
            }
            tb.MergeAttribute("role", "group");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.Push(this);

            if (content != null)
            {
                content.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
            Context.PopIfEqual(this);
        }
    }
}
