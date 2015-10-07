using System;
using BootstrapMvc.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootstrapMvc
{
    [TestClass]
    public class IconTest : TestBase
    {
        [TestMethod]
        public void Test_Icon_Normal()
        {
            var icon = new Icon(contextMock.Object).Type(IconType.Home);
            icon.WriteTo(writer);
            Assert.AreEqual(" <i class=\"glyphicon glyphicon-home\"></i> ", writer.ToString());
        }

        [TestMethod]
        public void Test_Icon_NoSpacing()
        {
            var icon = new Icon(contextMock.Object).Type(IconType.Home).NoSpacing();
            icon.WriteTo(writer);
            Assert.AreEqual("<i class=\"glyphicon glyphicon-home\"></i>", writer.ToString());
        }
    }
}
