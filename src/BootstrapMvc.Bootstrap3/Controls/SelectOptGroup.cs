using System;
using BootstrapMvc.Core;
using System.Collections.Generic;

namespace BootstrapMvc.Controls
{
    public class SelectOptGroup : ContentElement<SelectOptGroupContent>, ISelectItem
    {
        public SelectOptGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public bool DisabledValue { get; set; }

        public string LabelValue { get; set; }

        public IEnumerable<ISelectItem> ItemsValue { get; set; }

        protected override SelectOptGroupContent CreateContentContext()
        {
            return new SelectOptGroupContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("optgroup");

            tb.MergeAttribute("label", LabelValue);

            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (ItemsValue != null)
            {
                foreach (var item in ItemsValue)
                {
                    item.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</optgroup>");
        }
    }
}
