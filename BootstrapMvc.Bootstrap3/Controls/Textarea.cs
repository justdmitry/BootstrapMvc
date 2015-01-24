using System;
using System.Globalization;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc.Controls
{
    public class Textarea : ControlBase
    {
        private static readonly byte RowsDefault = 3;

        private IControlContext controlContext;

        private byte rows = RowsDefault;

        public Textarea(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent
        
        public Textarea ControlContext(IControlContext context)
        {
            controlContext = context;
            return this;
        }
        
        public Textarea Rows(byte rows)
        {
            this.rows = rows;
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (controlContext == null)
            {
                controlContext = FormGroup.TryGetCurrentControlContext(Context);
            }
            
            var tb = Context.CreateTagBuilder("textarea");
            tb.AddCssClass("form-control");
            if (rows != 0)
            {
                tb.MergeAttribute("rows", rows.ToString(CultureInfo.InvariantCulture));
            }
            if (controlContext != null)
            {
                tb.MergeAttribute("id", controlContext.Name);
                tb.MergeAttribute("name", controlContext.Name);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            if (controlContext != null && controlContext.Value != null)
            {
                writer.Write(Context.HtmlEncode(controlContext.Value.ToString()));
            }

            writer.Write(tb.GetEndTag());
        }
    }
}
