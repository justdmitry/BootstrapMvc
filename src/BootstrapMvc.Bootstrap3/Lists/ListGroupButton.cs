namespace BootstrapMvc.Lists
{
    using BootstrapMvc.Core;

    public class ListGroupButton : AnyContentElement, IDisableable
    {
        public bool Disabled { get; set; }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {

            var tb = Helper.CreateTagBuilder("button");

            if (Disabled)
            {
                tb.AddCssClass("disabled");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            return tb.GetEndTag();
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
