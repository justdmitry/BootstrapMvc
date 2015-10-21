namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;
    using System.Collections.Generic;

    public class SelectOptGroup : ContentElement<SelectOptGroupContent>, ISelectItem, IDisableable
    {
        public bool Disabled { get; set; }

        public string Label { get; set; }

        public IEnumerable<ISelectItem> ItemsValue { get; set; }

        protected override SelectOptGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new SelectOptGroupContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("optgroup");

            tb.MergeAttribute("label", Label);

            if (Disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (ItemsValue != null)
            {
                foreach (var item in ItemsValue)
                {
                    item.Parent = this;
                    item.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</optgroup>");
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }
    }
}
