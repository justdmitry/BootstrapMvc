using System;

namespace BootstrapMvc.Core
{
    public abstract class ContentElement<T> : Element where T : DisposableContent
    {
        public virtual T BeginContent(System.IO.TextWriter writer, IBootstrapContext context)
        {
            WriteSelfStart(writer, context);
            var retVal = CreateContentContext(context);
            retVal.OnDisposing(() => WriteSelfEnd(writer, context));
            return retVal;
        }

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            WriteSelfStart(writer, context);
            WriteSelfEnd(writer, context);
        }        

        protected abstract T CreateContentContext(IBootstrapContext context);

        protected abstract void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context);

        protected abstract void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context);
    }
}
