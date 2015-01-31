using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Select : ContentElement<SelectContent>, IFormControl, IPlaceholderTarget, ISizableControl
    {
        private IControlContext controlContext;

        private GridSize size;

        private IEnumerable<ISelectItem> items;

        public Select(IBootstrapContext context)
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

        public Select Items(IEnumerable<ISelectItem> items)
        {
            this.items = items.ToArray();
            return this;
        }

        public Select Items(params ISelectItem[] items)
        {
            this.items = items;
            return this;
        }

        #endregion

        protected override SelectContent CreateContent()
        {
            return new SelectContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
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

            object value = null;

            var tb = Context.CreateTagBuilder("select");
            tb.AddCssClass("form-control");

            if (controlContext != null)
            {
                tb.MergeAttribute("id", controlContext.Name);
                tb.MergeAttribute("name", controlContext.Name);
                value = controlContext.Value;
            }
            
            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (items != null)
            {
                foreach (var item in items)
                {
                    item.WriteTo(writer);
                }
            }

            return new Content(Context).Value(tb.GetEndTag() + (div == null ? string.Empty : div.GetEndTag()), true);
        }
    }
}
