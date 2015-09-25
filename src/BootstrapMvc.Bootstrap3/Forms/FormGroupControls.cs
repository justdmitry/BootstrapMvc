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

            if (form != null && form.TypeValue == FormType.Inline)
            {
                return string.Empty;
            }

            ITagBuilder tb = null;
            ITagBuilder tb2 = null;

            if (form != null && form.TypeValue == FormType.Horizontal)
            {
                tb = Context.CreateTagBuilder("div");
                tb.AddCssClass(form.ControlsWidthValue.ToCssClass());
                if (WithoutLabelValue)
                {
                    tb.AddCssClass(form.ControlsWidthValue.Invert().ToOffsetCssClass());
                }

                ApplyCss(tb);
                ApplyAttributes(tb);

                writer.Write(tb.GetStartTag());
            }

            if (formGroup != null && formGroup.WithSizedControlValue)
            {
                tb2 = Context.CreateTagBuilder("div");
                tb2.AddCssClass("row");
                writer.Write(tb2.GetStartTag());
            }

            if (tb != null && tb2 != null)
            {
                return tb2.GetEndTag() + tb.GetEndTag();
            }
            if (tb2 != null)
            {
                return tb2.GetEndTag();
            }
            if (tb != null)
            {
                return tb.GetEndTag();
            }
            return string.Empty;
        }
    }
}
