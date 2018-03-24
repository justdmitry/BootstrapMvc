namespace BootstrapMvc
{
    using System;
    using System.Globalization;
    using BootstrapMvc.Core;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Forms;

    public static class InputExtensions
    {
        public static IItemWriter<T> Type<T>(this IItemWriter<T> target, InputType value)
            where T : Input
        {
            target.Item.Type = value;
            return target;
        }

        public static IItemWriter<T> Plaintext<T>(this IItemWriter<T> target, bool value = true)
            where T : Input
        {
            target.Item.Disabled = value;
            target.Item.Plaintext = value;
            return target;
        }

        #region Generating

        public static IItemWriter<Input> Input(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Input>();
        }

        public static IItemWriter<Input> Input(this IAnyContentMarker contentHelper, InputType type)
        {
            return Input(contentHelper).Type(type);
        }

        /// <summary>
        /// Synonym for Input().Plaintext()
        /// </summary>
        public static IItemWriter<Input> StaticValue(this IAnyContentMarker contentHelper)
        {
            return Input(contentHelper).Plaintext(true);
        }

        public static IItemWriter<Input> InputInt(this IAnyContentMarker contextHelper)
        {
#if BOOTSTRAP4
            return contextHelper.Input(InputType.Number).Size(FormDefaults.InputNumberSize);
#else
            return contextHelper.Input(InputType.Number).Size(new GridSize(0, 2, 2, 2));
#endif
        }

        public static IItemWriter<Input> InputInt(this IAnyContentMarker contextHelper, int min, int max)
        {
            return InputInt(contextHelper)
                .Attribute("min", min.ToString(CultureInfo.InvariantCulture))
                .Attribute("max", max.ToString(CultureInfo.InvariantCulture));
        }

        public static IItemWriter<Input> InputDate(this IAnyContentMarker contextHelper)
        {
#if BOOTSTRAP4
            return contextHelper.Input(InputType.Date).Size(FormDefaults.InputDateSize);
#else
            return contextHelper.Input(InputType.Date).Size(new GridSize(0, 3, 3, 3));
#endif
        }

        [Obsolete("No more \"type=datetime\" in HTML 5.1, use InputDateTimeLocal()")]
        public static IItemWriter<Input> InputDateTime(this IAnyContentMarker contextHelper)
        {
#if BOOTSTRAP4
            return contextHelper.Input(InputType.Datetime).Size(FormDefaults.InputDateTimeSize);
#else
            return contextHelper.Input(InputType.Datetime).Size(new GridSize(0, 6, 5, 5));
#endif
        }

        public static IItemWriter<Input> InputDateTimeLocal(this IAnyContentMarker contextHelper)
        {
#if BOOTSTRAP4
            return contextHelper.Input(InputType.DatetimeLocal).Size(FormDefaults.InputDateTimeSize);
#else
            return contextHelper.Input(InputType.DatetimeLocal).Size(new GridSize(0, 6, 5, 5));
#endif
        }

        public static IItemWriter<Input> InputTime(this IAnyContentMarker contextHelper)
        {
#if BOOTSTRAP4
            return contextHelper.Input(InputType.Time).Size(FormDefaults.InputTimeSize);
#else
            return contextHelper.Input(InputType.Time).Size(new GridSize(0, 3, 3, 3));
#endif
        }

        public static IItemWriter<Input> InputEmail(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Email);
        }

        public static IItemWriter<Input> InputTel(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Tel);
        }

        public static IItemWriter<Input> InputUrl(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.Url);
        }

        public static IItemWriter<Input> InputFile(this IAnyContentMarker contextHelper)
        {
            return contextHelper.Input(InputType.File);
        }

        #endregion
    }
}
