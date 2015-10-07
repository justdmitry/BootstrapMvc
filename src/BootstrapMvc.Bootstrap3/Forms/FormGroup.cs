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

        public AnyContent BeginControls(IBootstrapContext context)
        {
            this.WriteSelfStart(context.Writer, context);
            var area = context.CreateWriter<FormGroupControls, AnyContent>().WithoutLabel(LabelValue == null).BeginContent();
            area.OnDisposing(() => WriteSelfEnd(context.Writer, context));
            return area;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var form = context.PeekNearest<IFormContext>();
            var tb = context.CreateTagBuilder("div");
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

            tb.WriteStartTag(writer);

            context.Push(this);

            if (LabelValue != null)
            {
                LabelValue.WriteTo(writer, context);
            }

            if (ControlValue != null)
            {
                using (context.CreateWriter<FormGroupControls, AnyContent>().WithoutLabel(LabelValue == null).BeginContent(writer))
                {
                    ControlValue.WriteTo(writer, context);
                }
            }

            if (form != null && form.TypeValue == FormType.Inline)
            {
                return "</div> "; // trailing space is important for inline forms! Bootstrap does not provide spacing between groups in css!
            }
            
            return "</div>";
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            base.WriteSelfEnd(writer, context);
            context.PopIfEqual(this);
        }
    }
}
