namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;

    public class StaticValue : Element, IFormControl
    {
        public bool Disabled { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var controlContext = GetNearestParent<IControlContext>();

            var input = Helper.CreateTagBuilder("p");
            input.AddCssClass("form-control-static");
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.FieldName, true);
                var value = controlContext.FieldValue;
                if (value != null)
                {
                    input.InnerHtml = Helper.HtmlEncode(value.ToString());
                }
            }
            if (Disabled)
            {
                // nothing - already read-only :)
            }

            ApplyCss(input);
            ApplyAttributes(input);

            input.WriteFullTag(writer);
        }

        void IDisableable.SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        bool IDisableable.Disabled()
        {
            return Disabled;
        }
    }
}
