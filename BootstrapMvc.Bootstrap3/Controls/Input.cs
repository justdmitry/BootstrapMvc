using System;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Input : Element, IFormControl, IPlaceholderTarget, ISizableControl
    {
        private IControlContext controlContext;

        private GridSize size;

        private InputType type = InputType.Default;

        public Input(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }
        
        public void SetControlContext(IControlContext context)
        {
            controlContext = context;
        }

        public void SetSize(GridSize size)
        {
            this.size = size;
        }

        public GridSize GetSize()
        {
            return size;
        }

        #region Fluent

        public Input Type(InputType type)
        {
            this.type = type;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var groupContext = FormGroup.GetCurrentContext(Context);
            if (controlContext == null)
            {
                controlContext = groupContext.ControlContext;
            }

            ITagBuilder div = null;

            if (!size.IsEmpty())
            {
                if (groupContext.WithSizedControls)
                {
                    div = Context.CreateTagBuilder("div");
                    div.AddCssClass(size.ToCssClass());
                    writer.Write(div.GetStartTag());
                }
                else
                {
                    throw new InvalidOperationException("Size not allowed - call WithSizedControls() on FormGroup.");
                }
            }

            var input = Context.CreateTagBuilder("input");
            input.AddCssClass("form-control");
            if (type != InputType.Text)
            {
                input.MergeAttribute("type", type.ToType());
            }
            if (controlContext != null)
            {
                input.MergeAttribute("id", controlContext.Name);
                input.MergeAttribute("name", controlContext.Name);
                var value = controlContext.Value;
                if (value != null)
                {
                    input.MergeAttribute("value", value.ToString());
                }
            }

            ApplyCss(input);
            ApplyAttributes(input);

            ////input.MergeAttributes(helper.HtmlHelper.GetUnobtrusiveValidationAttributes(context.ExpressionText, context.Metadata));

            writer.Write(input.GetFullTag());

            if (div != null)
            {
                writer.Write(div.GetEndTag());
            }
        }
    }
}
