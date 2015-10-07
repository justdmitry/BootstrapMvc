using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public abstract class DisposableContent : IDisposable
    {
        private List<Action> disposingCallbacks;

        private bool disposed = false;

        public void OnDisposing(Action action)
        {
            if (disposingCallbacks == null)
            {
                disposingCallbacks = new List<Action>(5);
            }
            disposingCallbacks.Add(action);
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
                if (disposingCallbacks != null)
                {
                    foreach(var callback in disposingCallbacks)
                    {
                        callback();
                    }
                }
            }
            disposed = true;
        }
    }
}
