namespace BootstrapMvc
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    public class Media : ContentElement<MediaContent>
    {
        public MediaObject Object { get; set; }

        public MediaBody Body { get; set; }

        /// <summary>
        /// Service property for detecting 'after-body' objects
        /// </summary>
        public bool BodyWasAlreadyWritten { get; set; } = false;

        protected override MediaContent CreateContentContext(IBootstrapContext context)
        {
            return new MediaContent(context, this);
        }

        protected override void WriteSelfStart(TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("media");

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Object != null && Object.Align == MediaObjectAlign.Left)
            {
                Object.WriteTo(writer);
            }

            if (Body != null)
            {
                Body.WriteTo(writer);
            }
        }

        protected override void WriteSelfEnd(TextWriter writer)
        {
            if (Object != null && Object.Align == MediaObjectAlign.Right)
            {
                Object.WriteTo(writer);
            }

            writer.Write("</div>");
        }
    }
}
