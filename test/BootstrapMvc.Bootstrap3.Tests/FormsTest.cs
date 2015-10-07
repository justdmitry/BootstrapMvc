using BootstrapMvc.Forms;
using BootstrapMvc.Controls;
using Xunit;

namespace BootstrapMvc
{
    public class FormsTest : TestBase
    {
        [Fact]
        public void Test_Form_Horizontal()
        {
            using (var form = new Form<dynamic>() { TypeValue = FormType.Horizontal }.BeginContent(writer, contextMock.Object))
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(new Input() { TypeValue = InputType.Number }).WriteTo(writer, contextMock.Object);
                    form.Group().Control(new Checkbox() { TextValue = "label 2" }).WriteTo(writer, contextMock.Object);
                }
            }
            var expected = @"
<form class='form-horizontal' method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label class='col-sm-4 col-md-4 col-lg-4 control-label'>label 1</label>
<div class='col-sm-8 col-md-8 col-lg-8'><input class='form-control' type='number'></input></div></div>
<div class='form-group'><div class='col-xs-offset-0 col-sm-offset-4 col-md-offset-4 col-lg-offset-4 col-sm-8 col-md-8 col-lg-8'><div class='checkbox'><label><input type='checkbox'></input> label 2</label></div></div></div>
</fieldset></form>";
            Assert.Equal(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }

        [Fact]
        public void Test_Form_Inline()
        {
            using (var form = new Form<dynamic>() { TypeValue = FormType.Inline }.BeginContent(writer, contextMock.Object))
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(new Input() { TypeValue = InputType.Number }).WriteTo(writer, contextMock.Object);
                    form.Group().Control(new Checkbox() { TextValue = "label 2" }).WriteTo(writer, contextMock.Object);
                }
            }
            var expected = @"
<form class='form-inline' method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label>label 1</label> <input class='form-control' type='number'></input></div>
 <div class='form-group'><div class='checkbox'><label><input type='checkbox'></input> label 2</label></div></div>
 </fieldset></form>";
            Assert.Equal(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }

        [Fact]
        public void Test_Form_Default()
        {
            using (var form = new Form<dynamic>() { TypeValue = FormType.DefaultNone }.BeginContent(writer, contextMock.Object))
            {
                using (form.BeginFieldset("Legend text"))
                {
                    form.Group("label 1").Control(new Input() { TypeValue = InputType.Number }).WriteTo(writer, contextMock.Object);
                    form.Group().Control(new Checkbox() { TextValue = "label 2" }).WriteTo(writer, contextMock.Object);
                }
            }
            var expected = @"
<form method='post'>
<fieldset><legend>Legend text</legend>
<div class='form-group'><label>label 1</label><input class='form-control' type='number'></input></div>
<div class='form-group'><div class='checkbox'><label><input type='checkbox'></input> label 2</label></div></div>
</fieldset></form>";
            Assert.Equal(expected.Replace('\'', '"').Replace("\r\n", ""), writer.ToString());
        }
    }
}
