namespace BootstrapMvc.Controls
{
    using System;
    using System.Collections.Generic;
    using BootstrapMvc.Core;
    using BootstrapMvc.Forms;

    public class Select : ContentElement<SelectContent>, IFormControl, IPlaceholderTarget, IGridSizable
    {
        private string endTag;

        public IEnumerable<ISelectItem> Items { get; set; }

        public GridSize Size { get; set; }

        public bool Disabled { get; set; }

        protected override SelectContent CreateContentContext(IBootstrapContext context)
        {
            return new SelectContent(context, this);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var formContext = GetNearestParent<IForm>();
            var formGroupContext = GetNearestParent<FormGroup>();
            var controlContext = GetNearestParent<IControlContext>();

            ITagBuilder div = null;

            if (!Size.IsEmpty())
            {
                // Inline forms does not support sized controls (we need 'some other' sizing rules?)
                if (formContext != null && formContext.Type != FormType.Inline)
                {
                    if (formGroupContext != null && formGroupContext.WithSizedControl)
                    {
                        div = Helper.CreateTagBuilder("div");
                        div.AddCssClass(Size.ToCssClass());
                        div.WriteStartTag(writer);
                    }
                    else
                    {
                        throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                    }

                }
            }

            object value = null;

            var tb = Helper.CreateTagBuilder("select");
            tb.AddCssClass("form-control");

            var controlSize = ((IControlSizable)formGroupContext)?.Size ?? ControlSize.Default;
            if (controlSize != ControlSize.Default)
            {
                tb.AddCssClass(controlSize.ToFormControlCssClass());
            }

            if (controlContext != null)
            {
                tb.MergeAttribute("id", controlContext.FieldName, true);
                tb.MergeAttribute("name", controlContext.FieldName, true);
                if (controlContext.IsRequired)
                {
                    tb.MergeAttribute("required", "required", true);
                }
                value = controlContext.FieldValue;
            }

            if (Disabled)
            {
                tb.MergeAttribute("disabled", "disabled", true);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    item.Parent = this;
                    item.WriteTo(writer);
                }
            }

            endTag = tb.GetEndTag() + (div == null ? string.Empty : div.GetEndTag());
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
