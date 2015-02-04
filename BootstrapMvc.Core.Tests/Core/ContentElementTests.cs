using System;
using System.IO;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    [TestClass]
    public class ContentElementTests
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;

        private Stack<DisposableContext> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<DisposableContext>();

            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
            contextMock.Setup(x => x.Push(It.IsAny<DisposableContext>())).Callback((DisposableContext x) => stack.Push(x));
            contextMock.Setup(x => x.Pop()).Returns(() => stack.Pop());
        }

        [TestMethod]
        public void Test_Writes_Ok()
        {
            using (var sw = new StringWriter())
            {
                contextMock.SetupGet(x => x.Writer).Returns(sw);
                using (var cnt = new DummyContentElement(contextMock.Object).BeginContent())
                {
                    sw.Write("-value-");
                }
                Assert.AreEqual("start-value-end", sw.ToString());
            }
        }

        private class DummyDisposableContext : DisposableContext
        {
            public DummyDisposableContext(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }
        }

        private class DummyContentElement : ContentElement<DummyDisposableContext>
        {
            public DummyContentElement(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }

            protected override DummyDisposableContext CreateContentContext()
            {
                return new DummyDisposableContext(Context);
            }

            protected override void WriteSelfStart(System.IO.TextWriter writer)
            {
                writer.Write("start");
            }

            protected override void WriteSelfEnd(TextWriter writer)
            {
                writer.Write("end");
            }
        }
    }
}
