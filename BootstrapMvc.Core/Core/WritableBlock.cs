using System;
using System.IO;

namespace BootstrapMvc.Core
{
    public abstract class WritableBlock : IWritable
    {
        private WritableBlock next = null;

        private bool writeWhitespaceSuffix = false;

        public WritableBlock(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        #region Fluent

        public WritableBlock Append(WritableBlock value)
        {
            if (next == null)
            {
                next = value;
                return value;
            }
            return next.Append(value);
        }

        public WritableBlock WriteWhitespaceSuffix(bool write = true)
        {
            this.writeWhitespaceSuffix = write;
            return this;
        }

        #endregion

        public void WriteTo(TextWriter writer)
        {
            BeforeWrite();
            WriteSelf(writer);
            AfterWrite();
            if (writeWhitespaceSuffix)
            {
                writer.Write(" ");
            }
            if (next != null)
            {
                next.WriteTo(writer);
            }
        }

        protected abstract void WriteSelf(TextWriter writer);

        protected virtual void BeforeWrite()
        {
            // Nothing
        }

        protected virtual void AfterWrite()
        {
            // Nothing
        }
    }
}
