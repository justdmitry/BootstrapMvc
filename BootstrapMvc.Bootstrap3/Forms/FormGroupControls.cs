using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupControls : AnyContentElement
    {
        private bool withCheckbox = false;

        private bool withRadio = false;

        private bool withoutLabel = false;

        public FormGroupControls(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public FormGroupControls WithCheckbox(bool value = true)
        {
            withCheckbox = value;
            return this;
        }

        public FormGroupControls WithRadio(bool value = true)
        {
            withRadio = value;
            return this;
        }

        public FormGroupControls WithoutLabel(bool value = true)
        {
            withoutLabel = value;
            return this;
        }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = Form.GetCurrentContext(Context);

            if (formContext.FormType != FormType.Horizontal && !withCheckbox && !withRadio)
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
            if (withCheckbox)
            {
                tb.AddCssClass("checkbox");
            }
            if (withRadio)
            {
                tb.AddCssClass("radio");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
