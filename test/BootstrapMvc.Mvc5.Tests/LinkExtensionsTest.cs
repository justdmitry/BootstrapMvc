using System.Collections.Generic;
using System.Web.Routing;
using BootstrapMvc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BootstrapMvc.Mvc5.Tests
{
    [TestClass]
    public class LinkExtensionsTest
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;
        private IDictionary<string, object> testDictionary;

        [TestInitialize]
        public void Setup()
        {
            mocks = new MockRepository(MockBehavior.Default);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock
                .Setup(x => x.CreateUrl(It.IsAny<IDictionary<string, object>>()))
                .Callback((IDictionary<string, object> z) => { testDictionary = z; });
            testDictionary = null;
        }

        [TestMethod]
        public void DictionaryOk()
        {
            var elm = new TestElement(contextMock.Object);

            var dic = new RouteValueDictionary();
            dic.Add("x", "xx");

            elm.Href(dic);

            Assert.AreEqual(1, testDictionary.Count);
            Assert.AreEqual("xx", testDictionary["x"]);
        }

        [TestMethod]
        public void ActionControllerOk()
        {
            var elm = new TestElement(contextMock.Object);
            elm.Href("action1", "controller1");

            Assert.AreEqual(2, testDictionary.Count);
            Assert.AreEqual("action1", testDictionary["action"]);
            Assert.AreEqual("controller1", testDictionary["controller"]);
        }

        [TestMethod]
        public void ActionControllerRouteValuesOk()
        {
            var obj = new { a = "aa" };
            var elm = new TestElement(contextMock.Object);
            elm.Href("action1", "controller1", obj);

            Assert.AreEqual(3, testDictionary.Count);
            Assert.AreEqual("action1", testDictionary["action"]);
            Assert.AreEqual("controller1", testDictionary["controller"]);
            Assert.AreEqual("aa", testDictionary["a"]);
        }

        [TestMethod]
        public void NullController()
        {
            var elm = new TestElement(contextMock.Object);
            elm.Href("action1", null);

            Assert.AreEqual(1, testDictionary.Count);
            Assert.IsFalse(testDictionary.ContainsKey("controller"));
        }

        private class TestElement : Element, ILink
        {
            public TestElement(IBootstrapContext context)
                : base(context)
            {
                // Nothing
            }

            public string HrefValue { get; set; }

            public void SetHref(string value)
            {
                HrefValue = value;
            }

            protected override void WriteSelf(System.IO.TextWriter writer)
            {
                writer.Write(string.Empty);
            }
        }
    }
}
