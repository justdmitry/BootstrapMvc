using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupControls : AnyContentElement
    {
        public FormGroupControls(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public bool WithoutLabelValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var form = Context.PeekNearest<Form>();
            var formGroup = Context.PeekNearest<FormGroup>();

            if (form != null && formGroup != null && form.TypeValue != FormType.Horizontal && !formGroup.WithStackedCheckboxValue && !formGroup.WithStackedRadioValue)
            {
                return string.Empty;
            }

            var tb = Context.CreateTagBuilder("div");
            if (form != null && form.TypeValue == FormType.Horizontal)
            {
                tb.AddCssClass(form.ControlsWidthValue.ToCssClass());
                if (WithoutLabelValue)
                {
                    tb.AddCssClass(form.ControlsWidthValue.Invert().ToOffsetCssClass());
                }
            }
            if (formGroup != null && formGroup.WithStackedCheckboxValue)
            {
                tb.AddCssClass("checkbox");
            }
            if (formGroup != null && formGroup.WithStackedRadioValue)
            {
                tb.AddCssClass("radio");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (formGroup != null && formGroup.WithSizedControlValue)
            {
                var tb2 = Context.CreateTagBuilder("div");
                tb2.AddCssClass("row");
                writer.Write(tb2.GetStartTag());

                return tb2.GetEndTag() + tb.GetEndTag();
            }
            else
            {
                return tb.GetEndTag();
            }
        }
    }
}
