using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroup : AnyContentElement
    {
        private IFormControl control = null;

        public FormGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public FormGroupLabel LabelValue { get; set; }

        public IFormControl ControlValue
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
                var sizable = control as IGridSizable;
                WithSizedControlValue = sizable != null && !sizable.Size().IsEmpty();
                var checkbox = control as Checkbox;
                WithStackedCheckboxValue = checkbox != null && !checkbox.InlineValue;
                var radio = control as Radio;
                WithStackedRadioValue = radio != null && !radio.InlineValue;
            }
        }

        public IControlContext ControlContextValue { get; set; }

        public bool WithStackedCheckboxValue { get; set; }

        public bool WithStackedRadioValue { get; set; }

        public bool WithSizedControlValue { get; set; }

        public AnyContent BeginControls()
        {
            if (LabelValue == null && !WithStackedCheckboxValue && !WithStackedRadioValue)
            {
                LabelValue = new FormGroupLabel(Context);
                LabelValue.Content(string.Empty);
            }
            this.WriteSelfStart(Context.Writer);
            var area = new FormGroupControls(Context).WithoutLabel(LabelValue == null).BeginContent();
            area.Disposing += (sender, args) => WriteSelfEnd(Context.Writer);
            return area;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("form-group");
            if (ControlContextValue != null)
            {
                if (ControlContextValue.HasErrors)
                {
                    tb.AddCssClass("has-error");
                }
                else if (ControlContextValue.HasWarning)
                {
                    tb.AddCssClass("has-warning");
                }
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.Push(this);

            if (LabelValue != null)
            {
                LabelValue.WriteTo(writer);
            }

            if (ControlValue != null)
            {
                using (new FormGroupControls(Context).BeginContent())
                {
                    ControlValue.WriteTo(writer);
                }
            }

            return "</div>";
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            base.WriteSelfEnd(writer);
            Context.PopIfEqual(this);
        }
    }
}
