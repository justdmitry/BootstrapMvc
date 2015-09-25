using System;

namespace BootstrapMvc.Core
{
    public class DummyWritableBlock : WritableBlock
    {
        public DummyWritableBlock(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public string Content { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            writer.Write(Content);
        }
    }
}
