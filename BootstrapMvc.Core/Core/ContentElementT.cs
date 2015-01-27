using System;

namespace BootstrapMvc.Core
{
    public abstract class ContentElement<T> : Element where T : DisposableContent
    {
        public ContentElement(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public virtual T BeginContent()
        {
            var writer = this.Context.Writer;
            var selfEnd = WriteSelfStart(writer);
            var retVal = CreateContent();
            retVal.WriteWhitespaceSuffix(false).Append(selfEnd);
            return retVal;
        }

        protected abstract T CreateContent();

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var selfEnd = WriteSelfStart(writer);
            selfEnd.WriteTo(writer);
        }

        protected abstract WritableBlock WriteSelfStart(System.IO.TextWriter writer);
    }
}
