namespace BootstrapMvc.Buttons
{
    using System;
    using System.Collections.Generic;
    using BootstrapMvc.Core;

    public class ButtonToolbar : ContentElement<ButtonToolbarContent>
    {
        /// <summary>
        /// Default spacing between ButtonGroups inside toolbar (default 2)
        /// </summary>
        public static byte GroupSpacingDefault { get; set; } = 2;

        /// <summary>
        /// Spacing between ButtonGroups inside toolbar
        /// </summary>
        public byte GroupSpacing { get; set; } = GroupSpacingDefault;

        internal byte ButtonGroupsWritten { get; set; } = 0;

        private List<ButtonGroup> buttons;

        public void AddButtonGroup(ButtonGroup value)
        {
            if (value == null)
            {
                return;
            }

            value.Parent = this;

            if (buttons == null)
            {
                buttons = new List<ButtonGroup>();
            }

            buttons.Add(value);
        }

        public void AddButtonGroup(params ButtonGroup[] values)
        {
            foreach(var value in values)
            {
                AddButtonGroup(value);
            }
        }

        protected override ButtonToolbarContent CreateContentContext(IBootstrapContext context)
        {
            return new ButtonToolbarContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("btn-toolbar");
            tb.MergeAttribute("role", "toolbar", true);

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            ButtonGroupsWritten = 0;

            if (buttons != null)
            {
                foreach(var button in buttons)
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
