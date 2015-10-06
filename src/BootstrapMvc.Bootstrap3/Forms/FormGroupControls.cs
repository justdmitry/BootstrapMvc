using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupControls : AnyContentElement
    {
        public bool WithoutLabelValue { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var form = context.PeekNearest<Form<dynamic>>();
            var formGroup = context.PeekNearest<FormGroup>();

            if (form != null && form.TypeValue == FormType.Inline)
            {
                return string.Empty;
            }

            ITagBuilder tb = null;
            ITagBuilder tb2 = null;

            if (form != null && form.TypeValue == FormType.Horizontal)
            {
                tb = context.CreateTagBuilder("div");
                tb.AddCssClass(form.ControlsWidthValue.ToCssClass());
                if (WithoutLabelValue)
                {
                    tb.AddCssClass(form.ControlsWidthValue.Invert().ToOffsetCssClass());
                }

                ApplyCss(tb);
                ApplyAttributes(tb);

                tb.WriteStartTag(writer);
            }

            if (formGroup != null && formGroup.WithSizedControlValue)
            {
                tb2 = context.CreateTagBuilder("div");
                tb2.AddCssClass("row");
                tb2.WriteStartTag(writer);
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
