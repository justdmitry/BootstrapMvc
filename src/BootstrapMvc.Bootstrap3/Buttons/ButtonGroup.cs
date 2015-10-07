using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroup : ContentElement<ButtonGroupContent>, IButtonSizable
    {
        private WritableBlock content;

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

        protected override ButtonGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new ButtonGroupContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
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

            tb.WriteStartTag(writer);

            context.Push(this);

            if (content != null)
            {
                content.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</div>");
            context.PopIfEqual(this);
        }
    }
}
