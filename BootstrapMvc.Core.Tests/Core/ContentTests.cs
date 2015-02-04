using System;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BootstrapMvc.Core
{
    [TestClass]
    public class ContentTests
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
        public void Test_Content_StringWithoutEncoding()
        {
            var sample = "<h1>Hello!</h1>";

            var sc = new Content(contextMock.Object).Value(sample, true);

            using (var sw = new StringWriter())
            {
                sc.WriteTo(sw);
                Assert.AreEqual(sample, sw.ToString());
            }
        }

        [TestMethod]
        public void Test_Content_StringWithEncoding()
        {
            var sample = "<h1>Hello!</h1>";
            var sampleEncoded = "&lt;h1&gt;Hello!&lt;/h1&gt;";

            var sc = new Content(contextMock.Object).Value(sample);

            using (var sw = new StringWriter())
            {
                sc.WriteTo(sw);
                Assert.AreEqual(sampleEncoded, sw.ToString());
            }
        }

        [TestMethod]
        public void Test_ContentKnows_WritableBlock()
        {
            var sample = "<test>";

            var obj = new DummyWritableBlock(contextMock.Object) { Content = sample };

            using (var sw = new StringWriter())
            {
                var sc = new Content(contextMock.Object).Value(obj);

                sc.WriteTo(sw);

                Assert.AreEqual(sample, sw.ToString());
            }
        }
        
        [TestMethod]
        public void Test_Content_Calls_ContextWrite()
        {
            var obj = new object();

            contextMock.Setup(x => x.Write(It.Is((object y) => object.ReferenceEquals(y, obj))));

            using (var sw = new StringWriter())
            {
                var sc = new Content(contextMock.Object).Value(obj);

                sc.WriteTo(sw);

                contextMock.Verify();
            }
        }

        private class AnyObjectToString
        {
            public string StringValue { get; set; }

            public override string ToString()
            {
                return StringValue;
            }
        }
    }
}
