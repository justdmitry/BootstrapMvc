using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupControls : AnyContentElement
    {
        private bool withoutLabel = false;

        public FormGroupControls(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public FormGroupControls WithoutLabel(bool value = true)
        {
            withoutLabel = value;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = Form.GetCurrentContext(Context);
            var groupContext = FormGroup.GetCurrentContext(Context);

            if (formContext.FormType != FormType.Horizontal && !groupContext.WithStackedCheckbox && !groupContext.WithStackedRadio)
            {
                return string.Empty;
            }

            var tb = Context.CreateTagBuilder("div");
            if (formContext.FormType == FormType.Horizontal)
            {
                tb.AddCssClass(formContext.ControlsWidth.ToCssClass());
                if (withoutLabel)
                {
                    tb.AddCssClass(formContext.ControlsWidth.Invert().ToOffsetCssClass());
                }
            }
            if (groupContext.WithStackedCheckbox)
            {
                tb.AddCssClass("checkbox");
            }
            if (groupContext.WithStackedRadio)
            {
                tb.AddCssClass("radio");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (groupContext.WithSizedControls)
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
