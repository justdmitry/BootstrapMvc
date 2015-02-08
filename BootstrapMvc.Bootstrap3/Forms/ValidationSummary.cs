using System;
using System.Linq;
using System.Text;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class ValidationSummary<TModel> : WritableBlock
    {
        public ValidationSummary(IBootstrapContext<TModel> context)
            : base(context)
        {
            this.Context = context;
        }

        public new IBootstrapContext<TModel> Context { get; private set; }

        public bool HidePropertyErrorsValue { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var validationResult = Context.ValidationResult;

            if (validationResult.IsValid)
            {
                return;
            }

            var haveErrors =
                validationResult.ModelErrors.Any(x => !x.IsWarning)
                || (!HidePropertyErrorsValue && validationResult.PropertyErrors.Any(x => x.Value.Any(y => !y.IsWarning)));
            var haveWarnings =
                validationResult.ModelErrors.Any(x => x.IsWarning)
                || (!HidePropertyErrorsValue && validationResult.PropertyErrors.Any(x => x.Value.Any(y => y.IsWarning)));

            string msg;

            if (haveErrors)
            {
                using (new Alert(Context).Type(AlertType.DangerRed).BeginContent())
                {
                    msg = Context.GetMessage(MessageType.ValidationResultErrorsFoundHeader);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        new OrdinaryElement(Context, "h4").Content(msg).WriteTo(writer);
                    }
                    writer.Write("<ul>");
                    foreach (var err in validationResult.ModelErrors.Where(x => !x.IsWarning))
                    {
                        writer.Write("<li>");
                        writer.Write(Context.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => !y.IsWarning)))
                    {
                        writer.Write("<li>");
                        writer.Write(Context.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    writer.Write("</ul>");
                    msg = Context.GetMessage(MessageType.ValidationResultErrorsFoundFooter);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        new OrdinaryElement(Context, "p").Content(msg).WriteTo(writer);
                    }
                }
            }

            if (haveWarnings)
            {
                using (new Alert(Context).Type(AlertType.WarningOrange).BeginContent())
                {
                    msg = Context.GetMessage(MessageType.ValidationResultWarningnsFoundHeader);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        new OrdinaryElement(Context, "h4").Content(msg).WriteTo(writer);
                    }
                    writer.Write("<ul>");
                    foreach (var err in validationResult.ModelErrors.Where(x => x.IsWarning))
                    {
                        writer.Write("<li>");
                        writer.Write(Context.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => y.IsWarning)))
                    {
                        writer.Write("<li>");
                        writer.Write(Context.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    writer.Write("</ul>");
                    msg = Context.GetMessage(MessageType.ValidationResultWarningnsFoundFooter);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        new OrdinaryElement(Context, "p").Content(msg).WriteTo(writer);
                    }
                }
            }
        }
    }
}