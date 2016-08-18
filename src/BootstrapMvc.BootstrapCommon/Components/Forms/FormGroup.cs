namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;

    public class FormGroup : AnyContentElement, IControlContext
    {
        private IFormControl control = null;

        public FormGroupLabel Label { get; set; }

        public IFormControl Control
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
                var sizable = control as IGridSizable;
                WithSizedControl = sizable != null && !sizable.GetSize().IsEmpty();
            }
        }

        public bool WithSizedControl { get; set; }

        #region IControlContext

        public string FieldName { get; set; }

        public object FieldValue { get; set; }

        public bool IsRequired { get; set; }

        public string[] Errors { get; set; }

        public bool HasErrors { get; set; }

        public bool HasWarning { get; set; }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var bootstrap4Mode = false;
#if BOOTSTRAP4 
            bootstrap4Mode = true;
#endif

            var formContext = GetNearestParent<IForm>();

            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("form-group");

            if (bootstrap4Mode && formContext != null && formContext.Type == FormType.Horizontal)
            {
                tb.AddCssClass("row");
            }

            if (HasErrors)
            {
                tb.AddCssClass(bootstrap4Mode ? "has-danger" : "has-error");
            }
            else if (HasWarning)
            {
                tb.AddCssClass("has-warning");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Label != null)
            {
                Label.Parent = this;
                Label.WriteTo(writer);
            }

            var controlsEnd = WriteControlsStart(writer, formContext, Label == null);

            if (Control != null)
            {
                Control.Parent = this;
                Control.WriteTo(writer);
            }

            if (formContext != null && formContext.Type == FormType.Inline)
            {
                return controlsEnd + "</div> "; // trailing space is important for inline forms! Bootstrap does not provide spacing between groups in css!
            }
            return controlsEnd + "</div>";
        }

        private string WriteControlsStart(System.IO.TextWriter writer, IForm formContext, bool noLabel)
        {
            if (formContext != null && formContext.Type == FormType.Inline)
            {
                return string.Empty;
            }

            ITagBuilder tb = null;
            ITagBuilder tb2 = null;

            if (formContext != null && formContext.Type == FormType.Horizontal)
            {
                tb = Helper.CreateTagBuilder("div");
                tb.AddCssClass(formContext.ControlsWidth.ToCssClass());
                if (noLabel)
                {
                    tb.AddCssClass(formContext.ControlsWidth.Invert().ToOffsetCssClass());
                }

                ApplyCss(tb);
                ApplyAttributes(tb);

                tb.WriteStartTag(writer);
            }

            if (WithSizedControl)
            {
                tb2 = Helper.CreateTagBuilder("div");
                tb2.AddCssClass("row");
                tb2.WriteStartTag(writer);
            }

            if (tb != null && tb2 != null)
            {
                return tb2.GetEndTag() + tb.GetEndTag();
            }
            if (tb2 != null)
            {
                return tb2.GetEndTag();
            }
            if (tb != null)
            {
                return tb.GetEndTag();
            }
            return string.Empty;
        }
    }
}
