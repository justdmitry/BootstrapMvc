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

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = Form.GetCurrentContext(Context);

            if (formContext.FormType != FormType.Horizontal)
            {
                // Do nothing!
                return string.Empty;
            }

            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass(formContext.ControlsWidth.ToCssClass());

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
