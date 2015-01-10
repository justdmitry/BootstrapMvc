using System;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BootstrapMvc.Core
{
    [TestClass]
    public class DisposableContentTest
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
        public void Test_DisposableContent_Writes_On_Dispose()
        {
            var sample = "test-string";

            using (var sw = new StringWriter())
            {
                contextMock.Setup(x => x.Writer).Returns(sw);

                using (var obj = new DummyDisposableContent(contextMock.Object))
                {
                    obj.Value(sample);
                }

                Assert.AreEqual(sample, sw.ToString());
            }
        }
    }
}
