namespace BootstrapMvc.Buttons
{
    using System;
    using BootstrapMvc.Core;
    using System.Collections.Generic;

    public class ButtonGroup : ContentElement<ButtonGroupContent>, IButtonSizable
    {
        private List<Button> buttons;

        public ButtonSize Size { get; set; }

        public bool Vertical { get; set; }

        public bool DropUp { get; set; }

        public bool Justified { get; set; }
        
        public void AddButton(Button value)
        {
            if (value == null)
            {
                return;
            }
            value.Parent = this;
            if (buttons == null)
            {
                buttons = new List<Button>();
            }
            buttons.Add(value);
        }

        protected override ButtonGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new ButtonGroupContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("btn-group");
            tb.AddCssClass(Size.ToButtonGroupCssClass());
            if (Vertical)
            {
                tb.AddCssClass("btn-group-vertical");
            }
            if (Justified)
            {
                tb.AddCssClass("btn-group-justified");
            }
            if (DropUp)
            {
                tb.AddCssClass("dropup");
            }
            tb.MergeAttribute("role", "group");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (buttons != null)
            {
                foreach (var button in buttons)
                {
                    button.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
        }
    }
}
