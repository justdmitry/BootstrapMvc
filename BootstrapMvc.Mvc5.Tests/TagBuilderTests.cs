using System;
using BootstrapMvc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootstrapMvc.Mvc5
{
    [TestClass]
    public class TagBuilderTests
    {
        [TestMethod]
        public void Test_EmptyCssClassesNotAdded()
        {
            var tb = new TagBuilder("test");
            tb.AddCssClass(string.Empty);
            tb.InnerHtml = "aaa";

            Assert.AreEqual("<test>aaa</test>", tb.GetFullTag());
        }

        [TestMethod]
        public void Test_GetStartEndFullTag()
        {
            var tb = new TagBuilder("test");
            tb.MergeAttribute("a", "b");
            tb.InnerHtml = "aaa";

            Assert.AreEqual("<test a=\"b\">", tb.GetStartTag());
            Assert.AreEqual("</test>", tb.GetEndTag());
            Assert.AreEqual("<test a=\"b\">aaa</test>", tb.GetFullTag());
        }
    }
}
