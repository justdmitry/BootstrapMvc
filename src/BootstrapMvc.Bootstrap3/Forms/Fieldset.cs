namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public class Fieldset : AnyContentElement, IDisableable
    {
        public Legend Legend { get; set; }

        public bool Disabled { get; set; }

        protected override AnyContent CreateContentContext(IBootstrapContext context)
        {
            return new AnyContent(context);
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("fieldset");

            if (Disabled)
            {
                tb.MergeAttribute("disabled", "disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Legend != null)
            {
                Legend.Parent = this;
                Legend.WriteTo(writer);
            }

            return "</fieldset>";
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
