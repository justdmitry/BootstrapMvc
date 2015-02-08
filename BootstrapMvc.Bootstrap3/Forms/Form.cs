using System;
using BootstrapMvc;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Form : ContentElement<FormContent>, ILink
    {
        private GridSize labelWidth;

        public Form(IBootstrapContext context)
            : base(context)
        {
            LabelWidthValue = new GridSize(0, 4, 4, 4);
            TypeValue = DefaultType;
        }

        public static FormType DefaultType = FormType.DefaultNone; 

        public FormMethod MethodValue { get; set; }

        public FormEnctype EnctypeValue { get; set; }

        public FormType TypeValue { get; set; }

        public string HrefValue { get; set; }

        public GridSize LabelWidthValue
        {
            get
            {
                return labelWidth;
            }

            set
            {
                labelWidth = value;
                ControlsWidthValue = labelWidth.Invert();
            }
        }

        public GridSize ControlsWidthValue { get; set; }

        protected override FormContent CreateContentContext()
        {
            return new FormContent(Context);
        }

        protected void FormContent_Disposing(object sender, EventArgs e)
        {
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("form");
            if (TypeValue != FormType.DefaultNone)
            {
                tb.AddCssClass(TypeValue.ToCssClass());
            }
            if (MethodValue != FormMethod.Get)
            {
                tb.MergeAttribute("method", MethodValue.ToString().ToLowerInvariant());
            }
            if (EnctypeValue != FormEnctype.NoValue)
            {
                tb.MergeAttribute("enctype", EnctypeValue.ToEnctype());
            }
            if (!string.IsNullOrEmpty(HrefValue))
            {
                tb.MergeAttribute("href", HrefValue);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.Push(this);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write("</form>");
            Context.PopIfEqual(this);
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
