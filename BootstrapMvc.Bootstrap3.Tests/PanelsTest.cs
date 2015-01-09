using System;
using BootstrapMvc.Panels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootstrapMvc
{
    [TestClass]
    public class PanelTest : TestBase
    {
        [TestMethod]
        public void Test_Panel_Normal()
        {
            var panel = new Panel(contextMock.Object)
                .Type(PanelType.DangerRed)
                .Footer("some footer").Body("some body").Header("some header");
            panel.WriteTo(writer);
            Assert.AreEqual(
                "<div class=\"panel panel-danger\"><div class=\"panel-heading\">some header</div> <div class=\"panel-body\">some body</div> <div class=\"panel-footer\">some footer</div> </div> ", 
                writer.ToString());
        }

        [TestMethod]
        public void Test_Panel_Content()
        {
            var panel = new Panel(contextMock.Object)
                .Type(PanelType.DangerRed)
                .Footer("some footer").Header("some header");
            using (panel.BeginContent())
            {
                new PanelBody(contextMock.Object).Content("some body").WriteTo(writer);
            }
            Assert.AreEqual(
                "<div class=\"panel panel-danger\"><div class=\"panel-heading\">some header</div> <div class=\"panel-body\">some body</div> <div class=\"panel-footer\">some footer</div> </div> ",
                writer.ToString());
        }
    }
}
