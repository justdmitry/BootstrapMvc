using System;

namespace BootstrapMvc.Core
{
    public abstract class DisposableContent : IDisposable
    {
        public event EventHandler Disposing;

        private bool disposed = false;

        public DisposableContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                if (Disposing != null)
                {
                    Disposing(this, EventArgs.Empty);
                }
            }
            disposed = true;
        }
    }
}
