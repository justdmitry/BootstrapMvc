using System;
using System.IO;
using System.Web;
using BootstrapMvc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvc = System.Web.Mvc;
using System.Collections.Generic;

namespace BootstrapMvc
{
    public abstract class TestBase
    {
        protected MockRepository mocks;
        protected Mock<IBootstrapContext> contextMock;
        protected TextWriter writer;

        protected Dictionary<string, Stack<object>> cachedData = new Dictionary<string,Stack<object>>();

        [TestInitialize]
        public void Init()
        {
            writer = new StringWriter();

            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
            contextMock.SetupGet(x => x.Writer).Returns(writer);
            contextMock.Setup(x => x.CreateTagBuilder(It.IsAny<string>())).Returns((string s) => new TagBuilder(s));

            contextMock.Setup(x => x.PushValue(It.IsAny<string>(), It.IsAny<object>())).Callback((string s, object v) =>
            {
                if (!cachedData.ContainsKey(s))
                {
                    cachedData.Add(s, new Stack<object>());
                }
                cachedData[s].Push(v);
            });

            contextMock.Setup(x => x.PopValue(It.IsAny<string>())).Returns((string s) => cachedData[s].Pop());
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
