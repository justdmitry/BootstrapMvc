namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public class FormGroupLabel : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = GetNearestParent<IForm>();
            var formGroupContext = GetNearestParent<FormGroup, IForm>();

            var required = formGroupContext.IsRequired;
            var name = formGroupContext.FieldName;

            var tb = Helper.CreateTagBuilder("label");

            if (formContext?.Type == FormType.Horizontal)
            {
                tb.AddCssClass("col-form-label");
                tb.AddCssClass(formContext.LabelWidth.ToCssClass());
            }

            var controlSize = ((IControlSizable)formGroupContext)?.Size ?? ControlSize.Default;
            if (controlSize != ControlSize.Default)
            {
                tb.AddCssClass(controlSize.ToFormLabelCssClass());
            }

            if (!string.IsNullOrEmpty(name))
            {
                tb.MergeAttribute("for", name, true);
            }
            if (required)
            {
                tb.AddCssClass("required");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (formContext != null && formContext.Type == FormType.Inline)
            {
                return tb.GetEndTag() + " "; // trailing space is important for inline forms! Bootstrap does not provide spacing between groups in css!
            }

            return tb.GetEndTag();
        }
    }
}
