using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Buttons
{
    public class ButtonToolbar : ContentElement<ButtonToolbarContent>
    {
        private WritableBlock content;

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

        protected override ButtonToolbarContent CreateContentContext(IBootstrapContext context)
        {
            return new ButtonToolbarContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("div");
            tb.AddCssClass("btn-toolbar");
            tb.MergeAttribute("role", "toolbar");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (content != null)
            {
                content.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</div>");
        }
    }
}
