namespace BootstrapMvc.Forms
{
    using System;
    using System.Linq;
    using BootstrapMvc;
    using BootstrapMvc.Core;

    public class ValidationSummary<TModel> : ValidationSummary
    {
        public bool HidePropertyErrors { get; set; }

        public string ErrorHeader { get; set; } = ErrorHeaderDefault;

        public string ErrorFooter { get; set; } = ErrorFooterDefault;

        public string WarningHeader { get; set; } = WarningHeaderDefault;

        public string WarningFooter { get; set; } = WarningFooterDefault;

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            var validationResult = ((IWritingHelper<TModel>)Helper).ValidationResult;

            if (validationResult.IsValid)
            {
                return;
            }

            var haveErrors =
                validationResult.ModelErrors.Any(x => !x.IsWarning)
                || (!HidePropertyErrors && validationResult.PropertyErrors.Any(x => x.Value.Any(y => !y.IsWarning)));
            var haveWarnings =
                validationResult.ModelErrors.Any(x => x.IsWarning)
                || (!HidePropertyErrors && validationResult.PropertyErrors.Any(x => x.Value.Any(y => y.IsWarning)));

            if (haveErrors)
            {
                using (Helper.CreateWriter<Alert, AnyContent>(this).Type(AlertType.DangerRed).BeginContent(writer))
                {
                    if (!string.IsNullOrEmpty(ErrorHeader))
                    {
                        writer.Write("<h4>");
                        writer.Write(Helper.HtmlEncode(ErrorHeader));
                        writer.Write("</h4>");
                    }
                    writer.Write("<ul>");
                    foreach (var err in validationResult.ModelErrors.Where(x => !x.IsWarning))
                    {
                        writer.Write("<li>");
                        writer.Write(Helper.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => !y.IsWarning)))
                    {
                        writer.Write("<li>");
                        writer.Write(Helper.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    writer.Write("</ul>");
                    if (!string.IsNullOrEmpty(ErrorFooter))
                    {
                        writer.Write("<p>");
                        writer.Write(Helper.HtmlEncode(ErrorFooter));
                        writer.Write("</p>");
                    }
                }
            }

            if (haveWarnings)
            {
                using (Helper.CreateWriter<Alert, AnyContent>(this).Type(AlertType.WarningOrange).BeginContent(writer))
                {
                    if (!string.IsNullOrEmpty(WarningHeader))
                    {
                        writer.Write("<h4>");
                        writer.Write(Helper.HtmlEncode(WarningHeader));
                        writer.Write("</h4>");
                    }
                    writer.Write("<ul>");
                    foreach (var err in validationResult.ModelErrors.Where(x => x.IsWarning))
                    {
                        writer.Write("<li>");
                        writer.Write(Helper.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => y.IsWarning)))
                    {
                        writer.Write("<li>");
                        writer.Write(Helper.HtmlEncode(err.Message));
                        writer.Write("</li>");
                    }
                    writer.Write("</ul>");
                    if (!string.IsNullOrEmpty(WarningFooter))
                    {
                        writer.Write("<p>");
                        writer.Write(Helper.HtmlEncode(WarningFooter));
                        writer.Write("</p>");
                    }
                }
            }
        }
    }
}