using System;
using System.Globalization;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Textarea : Element, IFormControl, IPlaceholderTarget, IGridSizable
    {
        private static readonly byte RowsDefault = 3;

        public Textarea(IBootstrapContext context)
            : base(context)
        {
            RowsValue = RowsDefault;
        }

        public IControlContext ControlContextValue { get; set; }

        public GridSize SizeValue { get; set; }

        public int RowsValue { get; set; }

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

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var formGroup = Context.PeekNearest<FormGroup>();
            if (formGroup != null && ControlContextValue == null)
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

            var tb = Context.CreateTagBuilder("textarea");
            tb.AddCssClass("form-control");
            if (RowsValue != 0)
            {
                tb.MergeAttribute("rows", RowsValue.ToString(CultureInfo.InvariantCulture));
            }
            if (ControlContextValue != null)
            {
                tb.MergeAttribute("id", ControlContextValue.Name);
                tb.MergeAttribute("name", ControlContextValue.Name);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (ControlContextValue != null && ControlContextValue.Value != null)
            {
                writer.Write(Context.HtmlEncode(ControlContextValue.Value.ToString()));
            }

            writer.Write(tb.GetEndTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
