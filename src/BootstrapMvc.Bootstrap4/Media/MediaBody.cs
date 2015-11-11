namespace BootstrapMvc
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    public class MediaBody : AnyContentElement
    {
        protected override string WriteSelfStartTag(TextWriter writer)
        {
            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("media-body");

            tb.WriteStartTag(writer);

            var media = GetNearestParent<Media>();
            if (media != null)
            {
                media.BodyWasAlreadyWritten = true;
            }

            return tb.GetEndTag();
        }
    }
}
