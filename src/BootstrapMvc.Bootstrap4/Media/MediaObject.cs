namespace BootstrapMvc
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    public class MediaObject : AnyContentElement, ILink
    {
        public MediaObjectAlign Align { get; set; } = MediaObjectAlign.Left;

        public MediaObjectVerticalAlign VerticalAlign { get; set; } = MediaObjectVerticalAlign.Top;

        public string Href { get; set; }
        
        protected override string WriteSelfStartTag(TextWriter writer)
        {
            var media = GetNearestParent<Media>();
            if (media != null && media.BodyWasAlreadyWritten)
            {
                Align = MediaObjectAlign.Right;
            }

            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass(Align.ToCssClass());
            tb.AddCssClass(VerticalAlign.ToCssClass());

            tb.WriteStartTag(writer);

            var a = string.IsNullOrEmpty(Href) ? null : Helper.CreateTagBuilder("a");

            if (a != null)
            {
                a.MergeAttribute("href", Href, true);
                a.WriteStartTag(writer);
            }

            return ((a == null) ? string.Empty : a.GetEndTag()) + tb.GetEndTag();
        }

        void ILink.SetHref(string value)
        {
            Href = value;
        }
    }
}
