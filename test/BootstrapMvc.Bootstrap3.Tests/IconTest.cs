using System;
using BootstrapMvc.Elements;
using Xunit;

namespace BootstrapMvc
{
    public class IconTest : TestBase
    {
        [Fact]
        public void Test_Icon_Normal()
        {
            var icon = new Icon() { TypeValue = IconType.Home };
            icon.WriteTo(writer, contextMock.Object);
            Assert.Equal(" <i class=\"glyphicon glyphicon-home\"></i> ", writer.ToString());
        }

        [Fact]
        public void Test_Icon_NoSpacing()
        {
            var icon = new Icon() { TypeValue = IconType.Home, NoSpacingValue = true };
            icon.WriteTo(writer, contextMock.Object);
            Assert.Equal("<i class=\"glyphicon glyphicon-home\"></i>", writer.ToString());
        }
    }
}
