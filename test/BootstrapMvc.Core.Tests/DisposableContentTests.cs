using System;
using Moq;
using Xunit;

namespace BootstrapMvc.Core
{
    public class DisposableContentTests
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;

        public DisposableContentTests()
        {
            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
        }

        [Fact]
        public void Raises_Disposing_Event()
        {
            var raised = false;

            var obj = new DummyDisposableContent(contextMock.Object);
            obj.Disposing += (s, a) => { raised = true; };
            using (obj)
            {
                Assert.False(raised);
            }
            Assert.True(raised);
        }

        private class DummyDisposableContent : DisposableContent
        {
            public DummyDisposableContent(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }
        }
    }
}
