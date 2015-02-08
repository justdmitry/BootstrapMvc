using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BootstrapMvc.Core
{
    [TestClass]
    public class DisposableContentTests
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;

        [TestInitialize]
        public void Initialize()
        {
            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
        }

        [TestMethod]
        public void Raises_Disposing_Event()
        {
            var raised = false;

            var obj = new DummyDisposableContent(contextMock.Object);
            obj.Disposing += (s, a) => { raised = true; };
            using (obj)
            {
                Assert.IsFalse(raised);
            }
            Assert.IsTrue(raised);
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
