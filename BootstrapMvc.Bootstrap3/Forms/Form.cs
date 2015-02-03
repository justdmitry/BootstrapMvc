using System;
using BootstrapMvc;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Form : ContentElement<FormContent>, ILink<Form>
    {
        private static readonly string ContextKey = "BootstrapMvc.Forms";

        private static readonly FormContext FormContextDefault = new FormContext
        {
            FormType = FormType.DefaultNone,
            LabelWidth = new GridSize(0, 4, 4, 4),
            ControlsWidth = new GridSize(0, 8, 8, 8)
        };

        private FormMethod method = FormMethod.Post;

        private FormEnctype enctype = FormEnctype.NoValue;

        private string href = string.Empty;

        private FormContext formContext;

        public Form(IBootstrapContext context)
            : base(context)
        {
            formContext = (FormContext)FormContextDefault.Clone();
        }

        public static FormContext GetCurrentContext(IBootstrapContext context)
        {
            FormContext val;
            context.TryPeekValue<FormContext>(ContextKey, out val);
            return val ?? (FormContext)FormContextDefault.Clone();
        }

        #region fluent

        public Form Method(FormMethod value)
        {
            method = value;
            return this;
        }

        public Form Enctype(FormEnctype value)
        {
            enctype = value;
            return this;
        }

        public Form Href(string value)
        {
            href = value;
            return this;
        }

        public Form Type(FormType value)
        {
            formContext.FormType = value;
            return this;
        }

        public Form LabelWidth(GridSize width)
        {
            formContext.LabelWidth = width;
            formContext.ControlsWidth = width.Invert();
            return this;
        }

        public Form ControlsWidth(GridSize width)
        {
            formContext.ControlsWidth = width;
            return this;
        }

        #endregion

        protected override FormContent CreateContent()
        {
            return new FormContent(Context);
        }

        protected override void AfterWrite()
        {
            Context.PopValue(ContextKey);
            base.AfterWrite();
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("form");
            if (formContext.FormType != FormType.DefaultNone)
            {
                tb.AddCssClass(formContext.FormType.ToCssClass());
            }
            if (method != FormMethod.Get)
            {
                tb.MergeAttribute("method", method.ToString().ToLowerInvariant());
            }
            if (enctype != FormEnctype.NoValue)
            {
                tb.MergeAttribute("enctype", enctype.ToEnctype());
            }
            if (!string.IsNullOrEmpty(href))
            {
                tb.MergeAttribute("href", href);
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            Context.PushValue(ContextKey, formContext);

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
