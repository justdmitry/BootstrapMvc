using System;
using System.IO;

namespace BootstrapMvc.Core
{
    public abstract partial class WritableBlock : IWritable
    {
        private WritableBlock next = null;

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

        public void WriteTo(TextWriter writer, IBootstrapContext context)
        {
            WriteSelf(writer, context);
            if (WriteWhitespaceSuffix)
            {
                writer.Write(" ");
            }
            if (next != null)
            {
                next.WriteTo(writer, context);
            }
        }

        protected abstract void WriteSelf(TextWriter writer, IBootstrapContext context);
    }
}
