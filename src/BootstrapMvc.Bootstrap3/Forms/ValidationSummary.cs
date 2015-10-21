//using System;
//using System.Linq;
//using System.Text;
//using BootstrapMvc;
//using BootstrapMvc.Core;

//namespace BootstrapMvc.Forms
//{
//    public class ValidationSummary<TModel> : WritableBlock
//    {
//        public bool HidePropertyErrors { get; set; }

//        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
//        {
//            var contextOfT = (IBootstrapContext<TModel>)context;
//            var validationResult = contextOfT.ValidationResult;

//            if (validationResult.IsValid)
//            {
//                return;
//            }

//            var haveErrors =
//                validationResult.ModelErrors.Any(x => !x.IsWarning)
//                || (!HidePropertyErrors && validationResult.PropertyErrors.Any(x => x.Value.Any(y => !y.IsWarning)));
//            var haveWarnings =
//                validationResult.ModelErrors.Any(x => x.IsWarning)
//                || (!HidePropertyErrors && validationResult.PropertyErrors.Any(x => x.Value.Any(y => y.IsWarning)));

//            string msg;

//            if (haveErrors)
//            {
//                using (context.CreateWriter<Alert, AnyContent>().Type(AlertType.DangerRed).BeginContent(writer))
//                {
//                    msg = context.GetMessage(MessageType.ValidationResultErrorsFoundHeader);
//                    if (!string.IsNullOrEmpty(msg))
//                    {
//                        context.CreateWriter<OrdinaryElement, AnyContent>().TagName("h4").Content(msg).WriteTo(writer, context);
//                    }
//                    writer.Write("<ul>");
//                    foreach (var err in validationResult.ModelErrors.Where(x => !x.IsWarning))
//                    {
//                        writer.Write("<li>");
//                        writer.Write(context.HtmlEncode(err.Message));
//                        writer.Write("</li>");
//                    }
//                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => !y.IsWarning)))
//                    {
//                        writer.Write("<li>");
//                        writer.Write(context.HtmlEncode(err.Message));
//                        writer.Write("</li>");
//                    }
//                    writer.Write("</ul>");
//                    msg = context.GetMessage(MessageType.ValidationResultErrorsFoundFooter);
//                    if (!string.IsNullOrEmpty(msg))
//                    {
//                        context.CreateWriter<OrdinaryElement, AnyContent>().TagName("p").Content(msg).WriteTo(writer, context);
//                    }
//                }
//            }

//            if (haveWarnings)
//            {
//                using (context.CreateWriter<Alert, AnyContent>().Type(AlertType.WarningOrange).BeginContent(writer))
//                {
//                    msg = context.GetMessage(MessageType.ValidationResultWarningnsFoundHeader);
//                    if (!string.IsNullOrEmpty(msg))
//                    {
//                        context.CreateWriter<OrdinaryElement, AnyContent>().TagName("h4").Content(msg).WriteTo(writer, context);
//                    }
//                    writer.Write("<ul>");
//                    foreach (var err in validationResult.ModelErrors.Where(x => x.IsWarning))
//                    {
//                        writer.Write("<li>");
//                        writer.Write(context.HtmlEncode(err.Message));
//                        writer.Write("</li>");
//                    }
//                    foreach (var err in validationResult.PropertyErrors.SelectMany(x => x.Value.Where(y => y.IsWarning)))
//                    {
//                        writer.Write("<li>");
//                        writer.Write(context.HtmlEncode(err.Message));
//                        writer.Write("</li>");
//                    }
//                    writer.Write("</ul>");
//                    msg = context.GetMessage(MessageType.ValidationResultWarningnsFoundFooter);
//                    if (!string.IsNullOrEmpty(msg))
//                    {
//                        context.CreateWriter<OrdinaryElement, AnyContent>().TagName("p").Content(msg).WriteTo(writer, context);
//                    }
//                }
//            }
//        }
//    }
//}