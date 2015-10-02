//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using Microsoft.AspNet.Mvc;
//using Microsoft.AspNet.Mvc.Rendering;
//using Microsoft.Framework.WebEncoders;
//using Microsoft.AspNet.Mvc.ModelBinding;
//using Microsoft.AspNet.Mvc.Rendering.Expressions;
//using Microsoft.Framework.DependencyInjection;

//namespace BootstrapMvc.Mvc6
//{
//    public class BootstrapContext<TModel> : BootstrapContext, IBootstrapContext<TModel>
//    {
//        public BootstrapContext(IActionContextAccessor actionContext, IUrlHelper urlHelper, IHtmlEncoder htmlEncoder, ViewDataDictionary<TModel> viewData)
//            : base(actionContext, urlHelper, htmlEncoder)
//        {
//            this.ViewData = viewData;
//            this.ValidationResult = GetModelValidationResult(viewData.ModelState);
//            this.MetadataProvider = actionContext.ActionContext.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();
//        }

//        public IModelValidationResult ValidationResult { get; set; }

//        public ViewDataDictionary<TModel> ViewData { get; set; }

//        public IModelMetadataProvider MetadataProvider { get; set; }

//        public IControlContext GetControlContext<TProperty>(Expression<Func<TModel, TProperty>> expression)
//        {
//            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, ViewData, MetadataProvider);
//            var name = ExpressionHelper.GetExpressionText(expression);
//            var fullName = ViewData.TemplateInfo.GetFullHtmlFieldName(name);

//            ModelState modelState;
//            ViewContext.ViewData.ModelState.TryGetValue(fullName, out modelState);

//            var value = string.Empty;
//            if (modelState != null && modelState.Value.AttemptedValue != null)
//            {
//                value = modelState.Value.AttemptedValue;
//            }
//            else if (modelExplorer.Model != null)
//            {
//                value = modelExplorer.Model.ToString();
//            }

//            var errors = modelState == null || modelState.Errors == null
//                ? null
//                : modelState.Errors.Select(e => e.ErrorMessage).ToArray();

//            return new ControlContext()
//            {
//                Name = fullName,
//                IsRequired = modelExplorer.Metadata.IsRequired,
//                Value = value,
//                Errors = errors,
//                HasErrors = errors != null && errors.Length > 0,
//                HasWarning = false
//            };
//        }

//        protected ModelValidationResult GetModelValidationResult(ModelStateDictionary modelState)
//        {
//            if (modelState.Count == 0)
//            {
//                return new ModelValidationResult() { IsValid = true };
//            }

//            var modelErrors = new List<IModelValidationError>();

//            if (modelState.ContainsKey(string.Empty))
//            {
//                modelErrors.AddRange(modelState[string.Empty].Errors.Select(x => new ModelValidationError(x.ErrorMessage)));
//            }
//            if (modelState.ContainsKey(WarningSpecialField))
//            {
//                modelErrors.AddRange(modelState[WarningSpecialField].Errors.Select(x => new ModelValidationError(x.ErrorMessage, true)));
//            }

//            var propertyErrors = new Dictionary<string, IEnumerable<IModelValidationError>>();
//            foreach (var modelError in modelState)
//            {
//                if (string.IsNullOrEmpty(modelError.Key) || WarningSpecialField == modelError.Key)
//                {
//                    continue;
//                }
//                var list = new List<IModelValidationError>();
//                list.AddRange(modelError.Value.Errors.Select(x => new ModelValidationError(x.ErrorMessage)));
//                propertyErrors[modelError.Key] = list;
//            }

//            return new ModelValidationResult()
//            {
//                IsValid = false,
//                ModelErrors = modelErrors,
//                PropertyErrors = propertyErrors
//            };
//        }
//    }
//}
