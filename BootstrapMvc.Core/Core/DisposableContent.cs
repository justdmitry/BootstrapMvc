using System;

namespace BootstrapMvc.Core
{
    public abstract class DisposableContent : Content, IDisposable
    {
        private bool disposed = false;

        public DisposableContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                WriteTo(Context.Writer);
            }
            disposed = true;
        }
    }
}
