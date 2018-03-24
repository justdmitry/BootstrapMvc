namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public class HelpText : AnyContentElement
    {
        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = GetNearestParent<IForm>();

            var inline = formContext?.Type == FormType.Inline;

            var tb = Helper.CreateTagBuilder("small");

            if (!inline)
            {
                tb.AddCssClass("form-text");
            }

            tb.AddCssClass("text-muted");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
        }
    }
}
