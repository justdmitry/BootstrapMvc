using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonToolbar : ContentElement<ButtonToolbarContent>
    {
        private WritableBlock content;

        public ButtonToolbar(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public ButtonToolbar AddButtonGroup(ButtonGroup value)
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

        public ButtonToolbar AddButtonGroup(params ButtonGroup[] values)
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

        protected override ButtonToolbarContent CreateContentContext()
        {
            return new ButtonToolbarContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("btn-toolbar");
            tb.MergeAttribute("role", "toolbar");

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (content != null)
            {
                content.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</div>");
        }
    }
}
