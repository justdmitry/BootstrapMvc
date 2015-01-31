using System;
using System.Linq.Expressions;
using BootstrapMvc.Controls;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormGroup : AnyContentElement
    {
        private static readonly string ContextKey = "BootstrapMvc.FormGroupContext";

        private static readonly FormGroupContext FormGroupContextDefault = new FormGroupContext
        {
            ControlContext = null,
            WithStackedCheckbox = false,
            WithStackedRadio = false,
            WithSizedControls = false
        };

        private FormGroupLabel label = null;

        private IFormControl control = null;

        private FormGroupContext groupContext;

        public FormGroup(IBootstrapContext context)
            : base(context)
        {
            groupContext = (FormGroupContext)FormGroupContextDefault.Clone();
        }

        public static FormGroupContext GetCurrentContext(IBootstrapContext context)
        {
            FormGroupContext val;
            context.TryPeekValue<FormGroupContext>(ContextKey, out val);
            return val ?? (FormGroupContext)FormGroupContextDefault.Clone();
        }

        #region Fluent

        public FormGroup ControlContext(IControlContext context)
        {
            groupContext.ControlContext = context;
            return this;
        }

        public FormGroup Required(bool required = true)
        {
            if (groupContext.ControlContext != null)
            {
                groupContext.ControlContext.IsRequired = required;
            }
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

        public FormGroup Control(IFormControl control)
        {
            this.control = control;
            var sizable = control as ISizableControl;
            groupContext.WithSizedControls = (sizable != null && !sizable.GetSize().IsEmpty());
            return this;
        }

        public FormGroup WithStackedCheckbox(bool value = true)
        {
            groupContext.WithStackedCheckbox = value;
            return this;
        }

        public FormGroup WithStackedRadio(bool value = true)
        {
            groupContext.WithStackedRadio = value;
            return this;
        }

        public FormGroup WithSizedControls(bool value = true)
        {
            groupContext.WithSizedControls = value;
            return this;
        }

        #endregion

        public AnyContent BeginControls()
        {
            if (label == null && !groupContext.WithStackedCheckbox && !groupContext.WithStackedRadio)
            {
                label = new FormGroupLabel(Context);
                label.Content(string.Empty);
            }
            var end = this.WriteSelfStart(Context.Writer);
            var area = new FormGroupControls(Context).WithoutLabel(label == null).BeginContent();
            area.Append(end);
            return area;
        }

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("div");
            tb.AddCssClass("form-group");
            if (groupContext.ControlContext != null)
            {
                if (groupContext.ControlContext.HasErrors)
                {
                    tb.AddCssClass("has-error");
                }
                else if (groupContext.ControlContext.HasWarning)
                {
                    tb.AddCssClass("has-warning");
                }
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.PushValue(ContextKey, groupContext);

            if (label != null)
            {
                label.WriteTo(writer);
            }

            if (control != null)
            {
                using (new FormGroupControls(Context).BeginContent())
                {
                    control.WriteTo(writer);
                }
            }

            return tb.GetEndTag(); 
        }

        protected override void AfterWrite()
        {
            Context.PopValue(ContextKey);
            base.AfterWrite();
        }
    }
}
