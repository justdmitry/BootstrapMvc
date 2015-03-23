using BootstrapMvc.Controls;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region Form

        //// Failed to write all pairs as single generic method(s). Feel free to improve.

        public static Form Method(this Form target, SubmitMethod value)
        {
            target.MethodValue = value;
            return target;
        }

        public static Form<T> Method<T>(this Form<T> target, SubmitMethod value)
        {
            target.MethodValue = value;
            return target;
        }

        public static Form Type(this Form target, FormType value)
        {
            target.TypeValue = value;
            return target;
        }

        public static Form<T> Type<T>(this Form<T> target, FormType value)
        {
            target.TypeValue = value;
            return target;
        }

        public static Form Enctype(this Form target, FormEnctype value)
        {
            target.EnctypeValue = value;
            return target;
        }

        public static Form<T> Enctype<T>(this Form<T> target, FormEnctype value)
        {
            target.EnctypeValue = value;
            return target;
        }

        public static Form LabelWidth(this Form target, GridSize value)
        {
            target.LabelWidthValue = value;
            return target;
        }

        public static Form<T> LabelWidth<T>(this Form<T> target, GridSize value)
        {
            target.LabelWidthValue = value;
            return target;
        }

        public static Form ControlsWidth(this Form target, GridSize value)
        {
            target.ControlsWidthValue = value;
            return target;
        }

        public static Form<T> ControlsWidth<T>(this Form<T> target, GridSize value)
        {
            target.ControlsWidthValue = value;
            return target;
        }

        #endregion

        #region Fieldset

        public static Fieldset Legend(this Fieldset target, Legend value)
        {
            target.LegendValue = value;
            return target;
        }

        public static Fieldset Disabled(this Fieldset target, bool value = true)
        {
            target.DisabledValue = value;
            return target;
        }

        #endregion

        #region FormGroup

        public static FormGroup Label(this FormGroup target, object content)
        {
            var labelContent = content as FormGroupLabel;
            target.LabelValue = labelContent ?? (FormGroupLabel)new FormGroupLabel(target.Context).Content(content);
            return target;
        }

        public static FormGroup Label(this FormGroup target, params object[] contents)
        {
            target.LabelValue = (FormGroupLabel)new FormGroupLabel(target.Context).Content(contents);
            return target;
        }

        public static FormGroup Control(this FormGroup target, IFormControl value)
        {
            target.ControlValue = value;
            return target;
        }

        public static FormGroup Required(this FormGroup target, bool value = true)
        {
            target.IsRequiredValue = value;
            return target;
        }

        public static FormGroup WithSizedControls(this FormGroup target, bool value = true)
        {
            target.WithSizedControlValue = value;
            return target;
        }

        #endregion

        #region FormGroupControls
        public static FormGroupControls WithoutLabel(this FormGroupControls target, bool value = true)
        {
            target.WithoutLabelValue = value;
            return target;
        }

        #endregion

        #region ValudationSummary

        public static ValidationSummary<TModel> HidePropertyErrors<TModel>(this ValidationSummary<TModel> target, bool hide = true)
        {
            target.HidePropertyErrorsValue = hide;
            return target;
        }

        #endregion
    }
}
