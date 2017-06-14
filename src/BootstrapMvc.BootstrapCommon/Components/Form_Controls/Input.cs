namespace BootstrapMvc.Controls
{
    using System;
    using System.Globalization;
    using BootstrapMvc;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public class Input : Element, IFormControl, IPlaceholderTarget, IGridSizable
    {
        public static DateInputMode DateInputModeDefault { get; set; } = DateInputMode.Text;

        public static string TextDateInputModeDateFormat { get; set; } = "d";

        public static string TextDateInputModeDateTimeLocalFormat { get; set; } = "G";

        public DateInputMode DateInputMode { get; set; } = DateInputModeDefault;

        public InputType Type { get; set; }

        public GridSize Size { get; set; }

        public bool Disabled { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var formContext = GetNearestParent<IForm>();
            var formGroupContext = GetNearestParent<FormGroup>();
            var controlContext = GetNearestParent<IControlContext>();

            ITagBuilder div = null;

            if (!Size.IsEmpty())
            {
                // Inline forms does not support sized controls (we need 'some other' sizing rules?)
                if (formContext != null && formContext.Type != FormType.Inline)
                {
                    if (formGroupContext != null && formGroupContext.WithSizedControl)
                    {
                        div = Helper.CreateTagBuilder("div");
                        div.AddCssClass(Size.ToCssClass());
                        div.WriteStartTag(writer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                    }
                }
            }

            var input = Helper.CreateTagBuilder("input");
#if BOOTSTRAP3
            input.AddCssClass("form-control");
#endif
#if BOOTSTRAP4
            if (Type == InputType.File)
            {
                input.AddCssClass("form-control-file");
            }
            else
            {
                input.AddCssClass("form-control");
            }

            if (controlContext != null)
            {
                if (controlContext.HasErrors)
                {
                    input.AddCssClass("form-control-danger");
                }
                else if (controlContext.HasWarning)
                {
                    input.AddCssClass("form-control-warning");
                }
            }
#endif
            var actualType = Type;
            if (actualType != InputType.File && controlContext != null)
            {
                input.MergeAttribute("id", controlContext.FieldName, true);
                input.MergeAttribute("name", controlContext.FieldName, true);
                if (controlContext.IsRequired)
                {
                    input.MergeAttribute("required", "required", true);
                }

                var value = controlContext.FieldValue;
                if (value != null)
                {
                    var valueString = value.ToString();
                    if (actualType == InputType.Datetime)
                    {
                        actualType = InputType.DatetimeLocal;
                    }

                    if (actualType == InputType.Date || actualType == InputType.DatetimeLocal || actualType == InputType.Time)
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

                        switch(Type)
                        {
                            case InputType.Date:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = asHtml5
                                        ? valueDateTime.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                                        : valueDateTime.Value.ToString(TextDateInputModeDateFormat);
                                }
                                break;
                            case InputType.DatetimeLocal:
                                if (valueDateTime.HasValue)
                                {
                                    valueString = asHtml5
                                        ? valueDateTime.Value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
                                        : valueDateTime.Value.ToString(TextDateInputModeDateTimeLocalFormat);
                                }
                                break;
                            case InputType.Time:
                                if (valueTimeSpan.HasValue)
                                {
                                    valueString = DateTime.MinValue.Add(valueTimeSpan.Value).ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                                }
                                break;
                        }
                    }
                    input.MergeAttribute("value", valueString, true);
                }
            }

            if (actualType != InputType.Text)
            {
                input.MergeAttribute("type", actualType.ToType(), true);
            }

            if (Disabled)
            {
                input.MergeAttribute("disabled", "disabled", true);
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            input.WriteFullTag(writer);

            if (div != null)
            {
                div.WriteEndTag(writer);
            }
        }

        void IGridSizable.SetSize(GridSize value)
        {
            Size = value;
        }

        GridSize IGridSizable.GetSize()
        {
            return Size;
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
