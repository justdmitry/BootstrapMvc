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

        public IControlContext ControlContextValue { get; set; }

        public IEnumerable<ISelectItem> ItemsValue { get; set; }

        public GridSize SizeValue { get; set; }

        public bool DisabledValue { get; set; }

        void IControlContextHolder.SetControlContext(IControlContext context)
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

        void IDisableable.SetDisabled(bool disabled)
        {
            DisabledValue = disabled;
        }

        bool IDisableable.Disabled()
        {
            return DisabledValue;
        }

        protected override SelectContent CreateContentContext(IBootstrapContext context)
        {
            return new SelectContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var form = context.PeekNearest<IFormContext>();
            var formGroup = context.PeekNearest<FormGroup>();
            if (ControlContextValue == null)
            {
                ControlContextValue = formGroup.ControlContextValue;
            }

            ITagBuilder div = null;

            if (!SizeValue.IsEmpty())
            {
                // Inline forms does not support sized controls (we need 'some other' sizing rules?)
                if (form != null && form.TypeValue != FormType.Inline)
                {
                    if (formGroup != null && formGroup.WithSizedControlValue)
                    {
                        div = context.CreateTagBuilder("div");
                        div.AddCssClass(SizeValue.ToCssClass());
                        writer.Write(div.GetStartTag());
                    }
                    else
                    {
                        throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                    }

                }
            }

            object value = null;

            var tb = context.CreateTagBuilder("select");
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
            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            context.Push(this);

            if (ItemsValue != null)
            {
                foreach (var item in ItemsValue)
                {
                    item.WriteTo(writer, context);
                }
            }

            endTag = tb.GetEndTag() + (div == null ? string.Empty : div.GetEndTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write(endTag);
            context.PopIfEqual(this);
        }
    }
}
