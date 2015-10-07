using System;
using BootstrapMvc.Core;
using Xunit;

namespace BootstrapMvc.Mvc5
{
    public class TagBuilderTests
    {
        [Fact]
        public void Test_EmptyCssClassesNotAdded()
        {
            var tb = new TagBuilder("test");
            tb.AddCssClass(string.Empty);
            tb.InnerHtml = "aaa";

            Assert.Equal("<test>aaa</test>", tb.GetFullTag());
        }

        [Fact]
        public void Test_GetStartEndFullTag()
        {
            var tb = new TagBuilder("test");
            tb.MergeAttribute("a", "b");
            tb.InnerHtml = "aaa";

            Assert.Equal("<test a=\"b\">", tb.GetStartTag());
            Assert.Equal("</test>", tb.GetEndTag());
            Assert.Equal("<test a=\"b\">aaa</test>", tb.GetFullTag());
        }
    }
}
