using System;
using BootstrapMvc.Core;
using System.Collections.Generic;

namespace BootstrapMvc.Controls
{
    public class SelectOptGroup : ContentElement<SelectOptGroupContent>, ISelectItem, IDisableable
    {
        public bool DisabledValue { get; set; }

        public string LabelValue { get; set; }

        public IEnumerable<ISelectItem> ItemsValue { get; set; }

        protected override SelectOptGroupContent CreateContentContext(IBootstrapContext context)
        {
            return new SelectOptGroupContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("optgroup");

            tb.MergeAttribute("label", LabelValue);

            if (DisabledValue)
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
                    item.WriteTo(writer, context);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</optgroup>");
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }
    }
}
