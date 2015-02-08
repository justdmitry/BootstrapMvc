using System;
using System.IO;
using System.Web;
using BootstrapMvc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvc = System.Web.Mvc;
using System.Collections.Generic;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public abstract class TestBase
    {
        protected MockRepository mocks;
        protected Mock<IBootstrapContext> contextMock;
        protected TextWriter writer;

        protected Stack<object> cachedData = new Stack<object>();

        protected BootstrapHelper bootstrap;

        [TestInitialize]
        public void Init()
        {
            writer = new StringWriter();

            mocks = new MockRepository(MockBehavior.Strict);

            contextMock = mocks.Create<IBootstrapContext>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
            contextMock.SetupGet(x => x.Writer).Returns(writer);
            contextMock.Setup(x => x.CreateTagBuilder(It.IsAny<string>())).Returns((string s) => new TagBuilder(s));

            contextMock.Setup(x => x.Push(It.IsAny<object>())).Callback((object v) =>
            {
                cachedData.Push(v);
            });

            contextMock.Setup(x => x.PopIfEqual(It.IsAny<object>())).Callback((object s) =>
            {
                var val = cachedData.Pop();
                if (!object.ReferenceEquals(s,val))
                {
                    throw new ApplicationException("Values does not match.");
                }
            });
            contextMock.Setup(x => x.PeekNearest<Form>()).Returns(PeekNearest<Form>);
            contextMock.Setup(x => x.PeekNearest<FormGroup>()).Returns(PeekNearest<FormGroup>);

            bootstrap = new BootstrapHelper(contextMock.Object);
        }

        private T PeekNearest<T>() where T : class
        {
            foreach(var item in cachedData)
            {
                if (item as T != null)
                {
                    return (T)item;
                }
            }
            return null;
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
