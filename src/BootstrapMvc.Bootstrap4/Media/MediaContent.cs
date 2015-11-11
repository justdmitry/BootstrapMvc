namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class MediaContent : DisposableContent
    {
        public MediaContent(IBootstrapContext context, Media parent)
        {
            Context = context;
            Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private Media Parent { get; set; }

        public IItemWriter<MediaObject, AnyContent> Object(MediaObjectVerticalAlign verticalAlign = MediaObjectVerticalAlign.Top)
        {
            return Context.Helper.CreateWriter<MediaObject, AnyContent>(Parent).VerticalAlign(verticalAlign);
        }

        public AnyContent BeginObject(MediaObjectVerticalAlign verticalAlign = MediaObjectVerticalAlign.Top)
        {
            return Object(verticalAlign).BeginContent();
        }

        public IItemWriter<MediaBody, AnyContent> Body()
        {
            return Context.Helper.CreateWriter<MediaBody, AnyContent>(Parent);
        }

        public AnyContent BeginBody()
        {
            return Body().BeginContent();
        }
    }
}
