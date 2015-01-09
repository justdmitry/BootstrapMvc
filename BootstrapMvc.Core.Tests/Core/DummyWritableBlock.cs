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

        public bool AfterWriteCalled { get; set; }

        public bool BeforeWriteCalled { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            writer.Write(Content);
        }

        protected override void BeforeWrite()
        {
            BeforeWriteCalled = true;
        }

        protected override void AfterWrite()
        {
            AfterWriteCalled = true;
        }
    }
}
