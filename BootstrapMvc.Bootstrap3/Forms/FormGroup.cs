using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroup : AnyContentElement
    {
        private static readonly string ControlContextContextKey = "BootstrapMvc.FormGroup";

        private IControlContext controlContext;

        private FormGroupLabel label = null;

        private ControlBase control = null;

        private bool withCheckbox = false;

        private bool withRadio = false;

        public FormGroup(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public static IControlContext TryGetCurrentControlContext(IBootstrapContext context)
        {
            IControlContext val;
            context.TryPeekValue<IControlContext>(ControlContextContextKey, out val);
            return val;
        }

        #region Fluent

        public FormGroup ControlContext(IControlContext context)
        {
            controlContext = context;
            return this;
        }

        public FormGroup Label(object content)
        {
            var labelContent = content as FormGroupLabel;
            label = labelContent ?? (FormGroupLabel)new FormGroupLabel(Context).Content(content);
            return this;
        }

        public FormGroup Label(params object[] contents)
        {
            label = (FormGroupLabel)new FormGroupLabel(Context).Content(contents);
            return this;
        }

        public FormGroup Control(ControlBase control)
        {
            this.control = control;
            return this;
        }

        public FormGroup WithCheckbox(bool value = true)
        {
            withCheckbox = value;
            return this;
        }

        public FormGroup WithRadio(bool value = true)
        {
            withRadio = value;
            return this;
        }

        #endregion

        public AnyContent BeginControls()
        {
            if (label == null && !withCheckbox && !withRadio)
            {
                label = new FormGroupLabel(Context);
                label.Content(string.Empty);
            }
            var end = this.WriteSelfStart(Context.Writer);
            var area = new FormGroupControls(Context).WithCheckbox(withCheckbox).WithRadio(withRadio).WithoutLabel(label == null).BeginContent();
            area.Append(end);
            return area;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("form-group");
            if (controlContext != null)
            {
                if (controlContext.HasErrors)
                {
                    tb.AddCssClass("has-error");
                }
                else if (controlContext.HasWarning)
                {
                    tb.AddCssClass("has-warning");
                }
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.PushValue(ControlContextContextKey, controlContext);

            if (label != null)
            {
                label.WriteTo(writer);
            }

            if (control != null)
            {
                var fgc = new FormGroupControls(Context);
                fgc.WithCheckbox(control is Checkbox).WithRadio(control is Radio);
                using (var area = fgc.BeginContent())
                {
                    control.WriteTo(writer);
                }
            }

            return tb.GetEndTag(); 
        }

        protected override void AfterWrite()
        {
            Context.PopValue(ControlContextContextKey);
            base.AfterWrite();
        }
    }
}
