using System;

namespace BootstrapMvc.Core
{
    public abstract class DisposableContext : IDisposable
    {
        private bool disposed = false;

        public DisposableContext(IBootstrapContext context)
        {
            this.Context = context;
            context.Push(this);
        }

        public IBootstrapContext Context { get; private set; }

        public Action<DisposableContext> DisposeCallback { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                var last = Context.Pop();
                if (!object.ReferenceEquals(this, last))
                {
                    throw new ApplicationException("Context stack ruined/wasted: object references mismatch.");
                }
                if (DisposeCallback != null)
                {
                    DisposeCallback(this);
                }
            }
            disposed = true;
        }
    }
}
