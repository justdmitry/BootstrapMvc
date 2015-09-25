using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroup : AnyContentElement, IControlContextHolder
    {
        private IFormControl control = null;

        private bool valueRequired = false;

        private bool overrideRequired = false;

        public FormGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public FormGroupLabel LabelValue { get; set; }

        public IFormControl ControlValue
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
                var sizable = control as IGridSizable;
                WithSizedControlValue = sizable != null && !sizable.Size().IsEmpty();
            }
        }

        public IControlContext ControlContextValue { get; set; }

        public bool WithSizedControlValue { get; set; }

        public bool IsRequiredValue
        {
            get
            {
                if (overrideRequired)
                {
                    return valueRequired;
                }
                return ControlContextValue == null ? valueRequired : ControlContextValue.IsRequired;
            }
            set
            {
                valueRequired = value;
                overrideRequired = true;
            }
        }

        public void SetControlContext(IControlContext context)
        {
            this.ControlContextValue = context;
        }

        public AnyContent BeginControls()
        {
            this.WriteSelfStart(Context.Writer);
            var area = new FormGroupControls(Context).WithoutLabel(LabelValue == null).BeginContent();
            area.Disposing += (sender, args) => WriteSelfEnd(Context.Writer);
            return area;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var form = Context.PeekNearest<Form>();
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("form-group");
            if (ControlContextValue != null)
            {
                if (ControlContextValue.HasErrors)
                {
                    tb.AddCssClass("has-error");
                }
                else if (ControlContextValue.HasWarning)
                {
                    tb.AddCssClass("has-warning");
                }
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.Push(this);

            if (LabelValue != null)
            {
                LabelValue.WriteTo(writer);
            }

            if (ControlValue != null)
            {
                using (new FormGroupControls(Context).WithoutLabel(LabelValue == null).BeginContent())
                {
                    ControlValue.WriteTo(writer);
                }
            }

            if (form != null && form.TypeValue == FormType.Inline)
            {
                return "</div> "; // trailing space is important for inline forms! Bootstrap does not provide spacing between groups in css!
            }
            
            return "</div>";
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            base.WriteSelfEnd(writer);
            Context.PopIfEqual(this);
        }
    }
}
