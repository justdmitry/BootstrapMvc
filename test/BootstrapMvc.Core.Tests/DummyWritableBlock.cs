using System;

namespace BootstrapMvc.Core
{
    public class DummyWritableBlock : WritableBlock
    {
        public string Content { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write(Content);
        }
    }
}
