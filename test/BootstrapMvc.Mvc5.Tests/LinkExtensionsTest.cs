using System.Collections.Generic;
using System.Web.Routing;
using BootstrapMvc;
using BootstrapMvc.Core;
using Moq;
using Xunit;

namespace BootstrapMvc.Mvc5.Tests
{
    public class LinkExtensionsTest
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;
        private IDictionary<string, object> testDictionary;

        public LinkExtensionsTest()
        {
            mocks = new MockRepository(MockBehavior.Default);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock
                .Setup(x => x.CreateUrl(It.IsAny<IDictionary<string, object>>()))
                .Callback((IDictionary<string, object> z) => { testDictionary = z; });
            testDictionary = null;
        }

        [Fact]
        public void DictionaryOk()
        {
            var elm = new Writer<TestElement>() { Context = contextMock.Object, Item = new TestElement() };

            var dic = new RouteValueDictionary();
            dic.Add("x", "xx");

            elm.Href(dic);

            Assert.Equal(1, testDictionary.Count);
            Assert.Equal("xx", testDictionary["x"]);
        }

        [Fact]
        public void ActionControllerOk()
        {
            var elm = new Writer<TestElement>() { Context = contextMock.Object, Item = new TestElement() };
            elm.Href("action1", "controller1");

            Assert.Equal(2, testDictionary.Count);
            Assert.Equal("action1", testDictionary["action"]);
            Assert.Equal("controller1", testDictionary["controller"]);
        }

        [Fact]
        public void ActionControllerRouteValuesOk()
        {
            var obj = new { a = "aa" };
            var elm = new Writer<TestElement>() { Context = contextMock.Object, Item = new TestElement() };
            elm.Href("action1", "controller1", obj);

            Assert.Equal(3, testDictionary.Count);
            Assert.Equal("action1", testDictionary["action"]);
            Assert.Equal("controller1", testDictionary["controller"]);
            Assert.Equal("aa", testDictionary["a"]);
        }

        [Fact]
        public void NullController()
        {
            var elm = new Writer<TestElement>() { Context = contextMock.Object, Item = new TestElement() };
            elm.Href("action1", null);

            Assert.Equal(1, testDictionary.Count);
            Assert.False(testDictionary.ContainsKey("controller"));
        }

        private class TestElement : Element, ILink
        {
            public string HrefValue { get; set; }

            public void SetHref(string value)
            {
                HrefValue = value;
            }

            protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
            {
                writer.Write(string.Empty);
            }
        }
    }
}
