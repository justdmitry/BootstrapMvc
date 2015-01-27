using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Select : ContentElement<SelectContent>, IFormControl, IPlaceholderTarget
    {
        private IControlContext controlContext;

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
            if (controlContext == null)
            {
                controlContext = FormGroup.TryGetCurrentControlContext(Context);
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

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
