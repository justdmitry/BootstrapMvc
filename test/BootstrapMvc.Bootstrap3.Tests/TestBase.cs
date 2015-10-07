using System;
using System.IO;
using System.Web;
using BootstrapMvc.Core;
using Moq;
using mvc = System.Web.Mvc;
using System.Collections.Generic;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public abstract class TestBase
    {
        protected MockRepository mocks;
        protected Mock<IBootstrapContext<dynamic>> contextMock;
        protected TextWriter writer;

        protected Stack<object> cachedData = new Stack<object>();

        public TestBase()
        {
            writer = new StringWriter();

            mocks = new MockRepository(MockBehavior.Strict);

            contextMock = mocks.Create<IBootstrapContext<dynamic>>();
            contextMock.Setup(x => x.HtmlEncode(It.IsAny<string>())).Returns((string s) => HttpUtility.HtmlEncode(s));
            contextMock.SetupGet(x => x.Writer).Returns(writer);
            contextMock.Setup(x => x.CreateTagBuilder(It.IsAny<string>())).Returns((string s) => new TagBuilder(s));

            contextMock.Setup(x => x.Push(It.IsAny<object>())).Callback((object v) =>
            {
                cachedData.Push(v);
            });

            contextMock.Setup(x => x.CreateWriter<Fieldset, AnyContent>())
                .Returns(() => new WriterEx<Fieldset, AnyContent>()
                {
                    Context = contextMock.Object,
                    Item = new Fieldset()
                });
            contextMock.Setup(x => x.CreateWriter<Legend, AnyContent>())
                .Returns(() => new WriterEx<Legend, AnyContent>()
                {
                    Context = contextMock.Object,
                    Item = new Legend()
                });
            contextMock.Setup(x => x.CreateWriter<FormGroup, AnyContent>())
                .Returns(() => new WriterEx<FormGroup, AnyContent>()
                {
                    Context = contextMock.Object,
                    Item = new FormGroup()
                });
            contextMock.Setup(x => x.CreateWriter<FormGroupLabel, AnyContent>())
                .Returns(() => new WriterEx<FormGroupLabel, AnyContent>()
                {
                    Context = contextMock.Object,
                    Item = new FormGroupLabel()
                });
            contextMock.Setup(x => x.CreateWriter<FormGroupControls, AnyContent>())
                .Returns(() => new WriterEx<FormGroupControls, AnyContent>()
                {
                    Context = contextMock.Object,
                    Item = new FormGroupControls()
                });

            contextMock.Setup(x => x.PopIfEqual(It.IsAny<object>())).Callback((object s) =>
            {
                var val = cachedData.Pop();
                if (!object.ReferenceEquals(s, val))
                {
                    throw new ApplicationException("Values does not match.");
                }
            });
            contextMock.Setup(x => x.PeekNearest<IFormContext>()).Returns(PeekNearest<IFormContext>);
            contextMock.Setup(x => x.PeekNearest<FormGroup>()).Returns(PeekNearest<FormGroup>);
        }

        private T PeekNearest<T>() where T : class
        {
            foreach (var item in cachedData)
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

            public void WriteStartTag(TextWriter writer)
            {
                writer.Write(GetStartTag());
            }

            public void WriteEndTag(TextWriter writer)
            {
                writer.Write(GetEndTag());
            }

            public void WriteFullTag(TextWriter writer)
            {
                writer.Write(GetFullTag());
            }
        }
    }
}
