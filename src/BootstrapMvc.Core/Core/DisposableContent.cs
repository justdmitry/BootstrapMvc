using System;

namespace BootstrapMvc.Core
{
    public abstract class DisposableContent : IDisposable
    {
        public Action OnDisposing { get; set; }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                if (OnDisposing != null)
                {
                    OnDisposing();
                }
            }
            disposed = true;
        }
    }
}
