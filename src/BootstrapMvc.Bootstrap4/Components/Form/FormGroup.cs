namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Controls;
    using BootstrapMvc.Core;

    public class FormGroup : AnyContentElement, IControlContext, IGridSizable, IControlSizable
    {
        private IFormControl control = null;

        public FormGroupLabel Label { get; set; }

        GridSize IGridSizable.Size { get; set; }

        ControlSize IControlSizable.Size { get; set; }

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
                WithSizedControl = sizable != null && !sizable.Size.IsEmpty();
            }
        }

        public bool WithSizedControl { get; set; }

        public bool WithCheckboxOrRadio { get; set; }

        #region IControlContext

        public string FieldName { get; set; }

        public string DisplayName { get; set; }

        public object FieldValue { get; set; }

        public Type DataType { get; set; }

        public bool IsRequired { get; set; }

        public string[] Errors { get; set; }

        public bool HasErrors { get; set; }

        public bool HasWarning { get; set; }

        #endregion

        protected override string WriteSelfStartTag(System.IO.TextWriter writer)
        {
            var formContext = GetNearestParent<IForm>();
            var inFormRow = GetNearestParent<Grid.FormRow, IForm>();

            var gridSize = (this as IGridSizable).Size;

            if (inFormRow == null && !gridSize.IsEmpty())
            {
                throw new InvalidOperationException("Size allowed only inside FormRows!");
            }

            var tb = Helper.CreateTagBuilder("div");
            tb.AddCssClass("form-group");

            if (formContext?.Type == FormType.Horizontal)
            {
                tb.AddCssClass("row");
            }

            if (inFormRow != null && !gridSize.IsEmpty())
            {
                tb.AddCssClass(gridSize.ToCssClass());
            }

            if (HasErrors)
            {
                tb.AddCssClass("has-danger");
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
                if (WithCheckboxOrRadio && formContext?.Type == FormType.Horizontal)
                {
                    Label.AddCssClass("pt-0");
                }

                Label.Parent = this;
                Label.WriteTo(writer);
            }

            var controlsEnd = WriteControlsStart(writer, formContext, Label == null);

            if (Control != null)
            {
                Control.Parent = this;
                Control.WriteTo(writer);
            }

            if (formContext?.Type == FormType.Inline)
            {
                return controlsEnd + "</div> "; // trailing space is important for inline forms! Bootstrap does not provide spacing between groups in css!
            }

            return controlsEnd + "</div>";
        }

        private string WriteControlsStart(System.IO.TextWriter writer, IForm formContext, bool noLabel)
        {
            if (formContext?.Type == FormType.Inline)
            {
                return string.Empty;
            }

            ITagBuilder tb = null;
            ITagBuilder tb2 = null;

            if (formContext?.Type == FormType.Horizontal)
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
