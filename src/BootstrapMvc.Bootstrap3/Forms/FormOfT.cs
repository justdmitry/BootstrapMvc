using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Form<TModel>: ContentElement<FormContent<TModel>>, ILink
    {
        private GridSize labelWidth;

        public Form()
        {
            LabelWidthValue = new GridSize(0, 4, 4, 4);
            TypeValue = DefaultType;
        }

        public static FormType DefaultType = FormType.DefaultNone;

        public SubmitMethod MethodValue { get; set; } = SubmitMethod.Post;

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

        protected override FormContent<TModel> CreateContentContext(IBootstrapContext context)
        {
            return new FormContent<TModel>((IBootstrapContext<TModel>)context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            var tb = context.CreateTagBuilder("form");
            if (TypeValue != FormType.DefaultNone)
            {
                tb.AddCssClass(TypeValue.ToCssClass());
            }
            if (MethodValue != SubmitMethod.Get)
            {
                tb.MergeAttribute("method", MethodValue.ToString().ToLowerInvariant());
            }
            if (EnctypeValue != FormEnctype.NoValue)
            {
                tb.MergeAttribute("enctype", EnctypeValue.ToEnctype());
            }
            if (!string.IsNullOrEmpty(HrefValue))
            {
                tb.MergeAttribute("action", HrefValue);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            tb.WriteStartTag(writer);

            context.Push(this);
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write("</form>");
            context.PopIfEqual(this);
        }

        void ILink.SetHref(string value)
        {
            HrefValue = value;
        }
    }
}
