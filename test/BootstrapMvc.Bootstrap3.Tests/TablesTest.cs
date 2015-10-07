using System;
using BootstrapMvc.Tables;
using Xunit;

namespace BootstrapMvc
{
    public class TablesTest : TestBase
    {
        [Fact]
        public void Test_Table_Normal()
        {
            var tbody = new TableBody()
                .AddRow(new TableRow()
                    .AddCell((TableCell)new TableCell().AddContent("A11"))
                    .AddCell((TableCell)new TableCell().AddContent("B11")))
                .AddRow(new TableRow()
                    .AddCell((TableCell)new TableCell().AddContent("A21"))
                    .AddCell((TableCell)new TableCell().AddContent("B21")));
            var tfoot = new TableFooter()
                .AddRow(new TableRow()
                    .AddCell((TableCell)new TableCell().AddContent("F1"))
                    .AddCell((TableCell)new TableCell().AddContent("F2")));
            var thead = new TableHeader()
                .AddRow(new TableRow()
                    .AddCell((TableHeaderCell)new TableHeaderCell().AddContent("B02"))
                    .AddCell((TableHeaderCell)new TableHeaderCell().AddContent("B01")));

            var table = new Table()
            {
                StyleValue = TableStyles.Bordered,
                CaptionValue = (TableCaption)new TableCaption().AddContent("Hello"),
                HeaderValue = (TableHeader)thead,
                FooterValue = (TableFooter)tfoot
            };
            using (table.BeginContent(writer, contextMock.Object))
            {
                tbody.WriteTo(writer, contextMock.Object);
            }

            Assert.Equal(
                "<table class=\"table table-bordered\"><caption>Hello</caption><thead><tr><th>B02</th><th>B01</th></tr></thead><tbody><tr><td>A11</td><td>B11</td></tr><tr><td>A21</td><td>B21</td></tr></tbody><tfoot><tr><td>F1</td><td>F2</td></tr></tfoot></table>",
                writer.ToString());
        }
    }
}
