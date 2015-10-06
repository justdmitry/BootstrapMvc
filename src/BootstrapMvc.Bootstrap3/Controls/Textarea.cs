using System;
using System.Globalization;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Textarea : Element, IFormControl, IPlaceholderTarget, IGridSizable
    {
        public static readonly byte RowsDefault = 3;

        public IControlContext ControlContextValue { get; set; }

        public GridSize SizeValue { get; set; }

        public int RowsValue { get; set; } = RowsDefault;

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

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var form = context.PeekNearest<Form<dynamic>>();
            var formGroup = context.PeekNearest<FormGroup>();
            if (formGroup != null && ControlContextValue == null)
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

            var tb = context.CreateTagBuilder("textarea");
            tb.AddCssClass("form-control");
            if (RowsValue != 0)
            {
                tb.MergeAttribute("rows", RowsValue.ToString(CultureInfo.InvariantCulture));
            }
            if (ControlContextValue != null)
            {
                tb.MergeAttribute("id", ControlContextValue.Name);
                tb.MergeAttribute("name", ControlContextValue.Name);
                if (ControlContextValue.IsRequired)
                {
                    tb.MergeAttribute("required", "required");
                }
            }
            if (DisabledValue)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (ControlContextValue != null && ControlContextValue.Value != null)
            {
                writer.Write(context.HtmlEncode(ControlContextValue.Value.ToString()));
            }

            writer.Write(tb.GetEndTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
