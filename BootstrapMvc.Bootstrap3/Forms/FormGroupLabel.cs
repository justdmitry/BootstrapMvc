using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroupLabel : AnyContentElement
    {
        public FormGroupLabel(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = Form.GetCurrentContext(Context);
            var groupContext = FormGroup.GetCurrentContext(Context);
            var controlContext = groupContext.ControlContext;

            var required = controlContext == null ? false : controlContext.IsRequired;
            var name = controlContext == null ? null : controlContext.Name;

            var tb = Context.CreateTagBuilder("label");

            if (formContext.FormType == FormType.Horizontal)
            {
                tb.AddCssClass("control-label");
                tb.AddCssClass(formContext.LabelWidth.ToCssClass());
            }

            if (!string.IsNullOrEmpty(name))
            {
                tb.MergeAttribute("for", name);
            }
            if (required)
            {
                tb.AddCssClass("required");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return tb.GetEndTag();
        }
    }
}
