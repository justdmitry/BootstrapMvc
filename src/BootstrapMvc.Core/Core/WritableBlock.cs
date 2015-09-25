using System;
using System.IO;

namespace BootstrapMvc.Core
{
    public abstract class WritableBlock : IWritable
    {
        private WritableBlock next = null;

        public WritableBlock(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public bool WriteWhitespaceSuffix { get; set; }

        public void AppendNextBlock(WritableBlock value)
        {
            if (next == null)
            {
                next = value;
            }
            else
            {
                next.AppendNextBlock(value);
            }
        }

        public void WriteTo(TextWriter writer)
        {
            WriteSelf(writer);
            if (WriteWhitespaceSuffix)
            {
                writer.Write(" ");
            }
            if (next != null)
            {
                next.WriteTo(writer);
            }
        }

        protected abstract void WriteSelf(TextWriter writer);
    }
}
