using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using BootstrapMvc.Core;
using Moq;
using Xunit;

namespace BootstrapMvc.Mvc5.Tests
{
    public class BootstrapContextTests
    {
        private MockRepository mocks;
        private ViewContext viewContext;

        public BootstrapContextTests()
        {
            mocks = new MockRepository(MockBehavior.Strict);
            var httpMock = mocks.Create<HttpContextBase>();
            
            httpMock.SetupGet(x => x.Items).Returns(new Dictionary<string, object>());
            viewContext = new ViewContext();
            viewContext.RequestContext = new System.Web.Routing.RequestContext();
            viewContext.RequestContext.HttpContext = httpMock.Object;
        }

        [Fact]
        public void PeekNearest_Ok()
        {
            var obj = new BootstrapContext(viewContext, null, null, null);
            var obj1 = new Class1();
            var obj2 = new Class2();
            var obj3 = new Class1();

            obj.Push(obj1);
            obj.Push(obj2);
            obj.Push(obj3);

            Assert.Same(obj2, obj.PeekNearest<Class2>());
        }

        [Fact]
        public void Pop_Ok()
        {
            var obj = new BootstrapContext(viewContext, null, null, null);
            var obj1 = new Class1();
            var obj2 = new Class2();
            var obj3 = new Class1();

            obj.Push(obj1);
            obj.Push(obj2);
            obj.Push(obj3);

            // this throws error
            try
            {
                obj.PopIfEqual(obj2);
                Assert.True(false, "Should not got there :(");
            } catch (ArgumentException)
            {
                // It,s Ok
            }

            // obj3 is still at last positon
            obj.PopIfEqual(obj3);


            // and now can POP obj2
            obj.PopIfEqual(obj2);

            // and obj1 is last one
            obj.PopIfEqual(obj1);

            // nothing more
            Assert.Null(obj.PeekNearest<object>());
        }


        private class Class1
        {
            // Nothing
        }

        private class Class2
        {
            // Nothing
        }
    }
}
