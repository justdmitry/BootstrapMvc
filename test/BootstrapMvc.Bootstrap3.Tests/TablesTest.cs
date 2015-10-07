using System;
using BootstrapMvc.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootstrapMvc
{
    [TestClass]
    public class TablesTest : TestBase
    {
        [TestMethod]
        public void Test_Table_Normal()
        {
            var tbody = bootstrap.TableBody().Rows(
                new TableRow(contextMock.Object).Cells("A11", "B11"), 
                new TableRow(contextMock.Object).Cells("A21", "B21"));
            var tfoot = bootstrap.TableFooter().Rows(bootstrap.TableRow().Cells("F1", "F2"));
            var thead = bootstrap.TableHeader().Rows(bootstrap.TableRow().HeaderCells("B02", "B01"));

            var table = bootstrap.Table(TableStyles.Bordered)
                .Caption("Hello")
                .Header(thead)
                .Footer(tfoot);
            using (table.BeginContent())
            {
                tbody.WriteTo(writer);
            }

            Assert.AreEqual(
                "<table class=\"table table-bordered\"><caption>Hello</caption><thead><tr><th>B02</th><th>B01</th></tr></thead><tbody><tr><td>A11</td><td>B11</td></tr><tr><td>A21</td><td>B21</td></tr></tbody><tfoot><tr><td>F1</td><td>F2</td></tr></tfoot></table>", 
                writer.ToString());
        }
    }
}
