using System;
using System.IO;
using System.Web;
using BootstrapMvc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvc = System.Web.Mvc;

namespace BootstrapMvc
{
    public abstract class TestBase
    {
        protected MockRepository mocks;
        protected Mock<IBootstrapContext> contextMock;
        protected TextWriter writer;

        [TestInitialize]
        public void Init()
        {
            writer = new StringWriter();

            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
            contextMock.SetupGet(x => x.Writer).Returns(writer);
            contextMock.Setup(x => x.CreateTagBuilder(It.IsAny<string>())).Returns((string s) => new TagBuilder(s));
        }

        protected class TagBuilder : mvc.TagBuilder, ITagBuilder
        {
            public TagBuilder(string tagName)
                : base(tagName)
            {
                // Nothing
            }

            public string GetStartTag()
            {
                return ToString(mvc.TagRenderMode.StartTag);
            }

            public string GetEndTag()
            {
                return ToString(mvc.TagRenderMode.EndTag);
            }

            public string GetFullTag()
            {
                return ToString(mvc.TagRenderMode.Normal);
            }
        }
    }
}
