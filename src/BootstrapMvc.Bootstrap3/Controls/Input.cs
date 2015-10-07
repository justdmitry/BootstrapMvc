using System;
using BootstrapMvc;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;
using BootstrapMvc.Grid;

namespace BootstrapMvc.Controls
{
    public class Input : Element, IFormControl, IPlaceholderTarget, IGridSizable
    {
        public static DateInputMode DateInputMode { get; set; }

        public IControlContext ControlContextValue { get; set; }

        public InputType TypeValue { get; set; }

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

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var form = context.PeekNearest<IFormContext>();
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

            var input = context.CreateTagBuilder("input");
            input.AddCssClass("form-control");
            var actualType = TypeValue;
            if (actualType != InputType.File && ControlContextValue != null)
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
                    if (TypeValue == InputType.Date || TypeValue == InputType.Datetime || TypeValue == InputType.DatetimeLocal || TypeValue == InputType.Time)
                    {
                        var valueDateTime = value as DateTime?;
                        var valueDateTimeOffset = value as DateTimeOffset?;
                        var valueTimeSpan = value as TimeSpan?;
                        if (valueDateTimeOffset.HasValue)
                        {
                            valueDateTime = valueDateTimeOffset.Value.DateTime;
                        }
                        if (valueDateTime.HasValue)
                        {
                            valueTimeSpan = valueDateTime.Value.TimeOfDay;
                        }
                        var asHtml5 = (DateInputMode == BootstrapMvc.DateInputMode.Html5);
                        if (!asHtml5)
                        {
                            actualType = InputType.Text;
                        }
                        switch(TypeValue)
                        {
                            case InputType.Date:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = asHtml5
                                        ? valueDateTime.Value.ToString("yyyy-MM-dd")
                                        : valueDateTime.Value.ToString("d");
                                }
                                break;
                            case InputType.DatetimeLocal:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = asHtml5
                                        ? valueDateTime.Value.ToString("o")
                                        : valueDateTime.Value.ToString();
                                }
                                break;
                            case InputType.Datetime:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = asHtml5 
                                        ? valueDateTimeOffset.Value.ToString("o") 
                                        : valueDateTimeOffset.Value.ToString();
                                }
                                break;
                            case InputType.Time:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = valueTimeSpan.ToString();
                                }
                                break;
                        }
                    }
                    input.MergeAttribute("value", valueString);
                }
            }

            if (actualType != InputType.Text)
            {
                input.MergeAttribute("type", actualType.ToType());
            }
            if (DisabledValue)
            {
                input.MergeAttribute("disabled", "disabled");
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
