using System;
using BootstrapMvc;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;
using BootstrapMvc.Grid;

namespace BootstrapMvc.Controls
{
    public class Input : Element, IFormControl, IPlaceholderTarget, IGridSizable
    {
        public Input(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public IControlContext ControlContextValue { get; set; }

        public InputType TypeValue { get; set; }

        public GridSize SizeValue { get; set; }

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

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var form = Context.PeekNearest<Form>();
            var formGroup = Context.PeekNearest<FormGroup>();
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
                        div = Context.CreateTagBuilder("div");
                        div.AddCssClass(SizeValue.ToCssClass());
                        writer.Write(div.GetStartTag());
                    }
                    else
                    {
                        throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                    }
                }
            }

            var input = Context.CreateTagBuilder("input");
            input.AddCssClass("form-control");
            if (TypeValue != InputType.Text)
            {
                input.MergeAttribute("type", TypeValue.ToType());
            }
            if (ControlContextValue != null)
            {
                input.MergeAttribute("id", ControlContextValue.Name);
                input.MergeAttribute("name", ControlContextValue.Name);
                if (ControlContextValue.IsRequired)
                {
                    input.MergeAttribute("required", "required");
                }
                var value = ControlContextValue.Value;
                if (value != null)
                {
                    var valueString = value.ToString();
                    if (TypeValue == InputType.Date)
                    {
                        valueString = ((DateTime)value).ToShortDateString();
                    }
                    input.MergeAttribute("value", valueString);
                }
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
