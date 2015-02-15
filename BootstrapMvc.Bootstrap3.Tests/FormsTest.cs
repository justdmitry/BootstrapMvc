using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapMvc.Forms;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;
using System.IO;
using Moq;
using System.Web.Mvc;
using BootstrapMvc;
using System.Web;

namespace BootstrapMvc
{
    [TestClass]
    public class FormsTest : TestBase
    {
        [TestMethod]
        public void Test_Form_Horizontal()
        {
            using (var form = bootstrap.Form(FormType.Horizontal).BeginContent())
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(bootstrap.Input(InputType.Number)).WriteTo(writer);
                    form.Group().Control(bootstrap.Checkbox("label 2")).WriteTo(writer);
                }
            }
            var expected = @"
<form class='form-horizontal' method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label class='col-sm-4 col-md-4 col-lg-4 control-label'>label 1</label>
<div class='col-sm-8 col-md-8 col-lg-8'><input class='form-control' type='number'></input></div></div>
<div class='form-group'><div class='checkbox col-xs-offset-0 col-sm-offset-4 col-md-offset-4 col-lg-offset-4 col-sm-8 col-md-8 col-lg-8'><label><input type='checkbox'></input>label 2</label></div></div>
</fieldset></form>";
            Assert.AreEqual(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }

        [TestMethod]
        public void Test_Form_Inline()
        {
            using (var form = bootstrap.Form(FormType.Inline).BeginContent())
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(bootstrap.Input(InputType.Number)).WriteTo(writer);
                    form.Group().Control(bootstrap.Checkbox("label 2")).WriteTo(writer);
                }
            }
            var expected = @"
<form class='form-inline' method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label>label 1</label><input class='form-control' type='number'></input></div>
<div class='form-group'><div class='checkbox'><label><input type='checkbox'></input>label 2</label></div></div>
</fieldset></form>";
            Assert.AreEqual(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }

        [TestMethod]
        public void Test_Form_Default()
        {
            using (var form = bootstrap.Form(FormType.DefaultNone).BeginContent())
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(bootstrap.Input(InputType.Number)).WriteTo(writer);
                    form.Group().Control(bootstrap.Checkbox("label 2")).WriteTo(writer);
                }
            }
            var expected = @"
<form method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label>label 1</label><input class='form-control' type='number'></input></div>
<div class='form-group'><div class='checkbox'><label><input type='checkbox'></input>label 2</label></div></div>
</fieldset></form>";
            Assert.AreEqual(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }
    }
}
