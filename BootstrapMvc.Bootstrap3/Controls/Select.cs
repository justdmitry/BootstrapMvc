using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Select : ContentElement<SelectContent>, IFormControl, IPlaceholderTarget, IGridSizable
    {
        private string endTag;

        public Select(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IControlContext ControlContextValue { get; set; }

        public IEnumerable<ISelectItem> ItemsValue { get; set; }

        public GridSize SizeValue { get; set; }

        void IFormControl.SetControlContext(IControlContext context)
        {
            ControlContextValue = context;
        }

        void IGridSizable.SetSize(GridSize value)
        {
            SizeValue = value;
        }

        GridSize IGridSizable.Size()
        {
            return SizeValue;
        }

        protected override SelectContent CreateContentContext()
        {
            return new SelectContent(Context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var formGroup = Context.PeekNearest<FormGroup>();
            if (ControlContextValue == null)
            {
                ControlContextValue = formGroup.ControlContextValue;
            }

            ITagBuilder div = null;

            if (!SizeValue.IsEmpty())
            {
                if (formGroup != null && formGroup.WithSizedControlValue)
                {
                    div = Context.CreateTagBuilder("div");
                    div.AddCssClass(SizeValue.ToCssClass());
                    writer.Write(div.GetStartTag());
                }
                else
                {
                    throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                }
            }

            object value = null;

            var tb = Context.CreateTagBuilder("select");
            tb.AddCssClass("form-control");

            if (ControlContextValue != null)
            {
                tb.MergeAttribute("id", ControlContextValue.Name);
                tb.MergeAttribute("name", ControlContextValue.Name);
                if (ControlContextValue.IsRequired)
                {
                    tb.MergeAttribute("required", "required");
                }
                value = ControlContextValue.Value;
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

            endTag = tb.GetEndTag() + (div == null ? string.Empty : div.GetEndTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
