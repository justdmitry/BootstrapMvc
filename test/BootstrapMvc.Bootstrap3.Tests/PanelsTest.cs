using System;
using BootstrapMvc.Panels;
using Xunit;

namespace BootstrapMvc
{
    public class PanelTest : TestBase
    {
        [Fact]
        public void Test_Panel_Normal()
        {
            var panel = new Panel()
            {
                TypeValue = PanelType.DangerRed,
                PanelFooterValue = (PanelFooter)new PanelFooter().AddContent("some footer"),
                PanelBodyValue = (PanelBody)new PanelBody().AddContent("some body"),
                PanelHeaderValue = (PanelHeader)new PanelHeader().AddContent("some header")
            };
            panel.WriteTo(writer, contextMock.Object);
            Assert.Equal(
                "<div class=\"panel panel-danger\"><div class=\"panel-heading\">some header</div><div class=\"panel-body\">some body</div><div class=\"panel-footer\">some footer</div></div>", 
                writer.ToString());
        }

        [Fact]
        public void Test_Panel_Content()
        {
            var panel = new Panel()
            {
                TypeValue = PanelType.DangerRed,
                PanelFooterValue = (PanelFooter)new PanelFooter().AddContent("some footer"),
                PanelHeaderValue = (PanelHeader)new PanelHeader().AddContent("some header")
            };
            using (panel.BeginContent(writer, contextMock.Object))
            {
                new PanelBody().AddContent("some body").WriteTo(writer, contextMock.Object);
            }
            Assert.Equal(
                "<div class=\"panel panel-danger\"><div class=\"panel-heading\">some header</div><div class=\"panel-body\">some body</div><div class=\"panel-footer\">some footer</div></div>",
                writer.ToString());
        }
    }
}
