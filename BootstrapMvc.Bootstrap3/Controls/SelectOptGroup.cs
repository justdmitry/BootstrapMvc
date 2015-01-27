using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public class SelectOptGroup : ContentElement<SelectOptGroupContent>, ISelectItem
    {
        private string label;
        private bool disabled;

        public SelectOptGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public SelectOptGroup Label(string value)
        {
            this.label = value;
            return this;
        }

        public SelectOptGroup Disabled(bool disabled = true)
        {
            this.disabled = disabled;
            return this;
        }

        #endregion

        protected override SelectOptGroupContent CreateContent()
        {
            return new SelectOptGroupContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("optgroup");

            tb.MergeAttribute("label", label);

            if (disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
