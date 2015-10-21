namespace BootstrapMvc.Core
{
    using System;

    public abstract class ContentElement<T> : Element 
        where T : DisposableContent
    {
        public virtual T BeginContent(System.IO.TextWriter writer, IBootstrapContext context)
        {
            WriteSelfStart(writer);
            if (context != null)
            {
                context.PushParent(this);
            }

            var retVal = CreateContentContext(context);
            retVal.OnDisposing(() => 
            {
                if (context != null)
                {
                    context.PopParent(this);
                }
                WriteSelfEnd(writer);
            });
            return retVal;
        }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            WriteSelfStart(writer);
            WriteSelfEnd(writer);
        }

        protected abstract T CreateContentContext(IBootstrapContext context);

        protected abstract void WriteSelfStart(System.IO.TextWriter writer);

        protected abstract void WriteSelfEnd(System.IO.TextWriter writer);
    }
}
