using System;
using System.IO;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BootstrapMvc.Core
{
    [TestClass]
    public class ContentElementTests
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;

        [TestInitialize]
        public void Initialize()
        {
            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
        }

        [TestMethod]
        public void Test_Writes_Ok()
        {
            using (var sw = new StringWriter())
            {
                contextMock.SetupGet(x => x.Writer).Returns(sw);
                using (var cnt = new DummyContentElement(contextMock.Object).BeginContent())
                {
                    cnt.Value("-value-");
                }
                Assert.AreEqual("start-value-end ", sw.ToString());
            }
        }

        private class DummyDisposableContent : DisposableContent
        {
            public DummyDisposableContent(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }
        }

        private class DummyContentElement : ContentElement<DummyDisposableContent>
        {
            public DummyContentElement(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }

            protected override DummyDisposableContent CreateContent()
            {
                return new DummyDisposableContent(Context);
            }

            protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
            {
                writer.Write("start");
                return new Content(Context).Value("end");
            }
        }
    }
}
