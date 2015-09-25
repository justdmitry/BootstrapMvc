using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class BootstrapContext<TModel> : BootstrapContext, IBootstrapContext<TModel>
    {
        public BootstrapContext(ViewContext viewContext, UrlHelper urlHelper, ViewDataDictionary<TModel> viewData, Func<int, string> messageSource)
            : base(viewContext, urlHelper, viewData, messageSource)
        {
            this.ViewData = viewData;
            this.ValidationResult = GetModelValidationResult(viewData.ModelState);
        }

        public IModelValidationResult ValidationResult { get; set; }

        protected new ViewDataDictionary<TModel> ViewData { get; set; }

        public IControlContext GetControlContext<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName = ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState modelState;
            ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState);
            var value = modelState == null || modelState.Value == null
                ? (modelMetadata.Model == null ? null : modelMetadata.Model)
                : modelState.Value.AttemptedValue;
            var errors = modelState == null || modelState.Errors == null
                ? null
                : modelState.Errors.Select(e => e.ErrorMessage).ToArray();

            return new ControlContext()
            {
                Name = fullHtmlFieldName,
                IsRequired = modelMetadata.IsRequired,
                Value = value,
                Errors = errors,
                HasErrors = errors != null && errors.Length > 0,
                HasWarning = false
            };
        }

        protected ModelValidationResult GetModelValidationResult(ModelStateDictionary modelState)
        {
            if (modelState.Count == 0)
            {
                return new ModelValidationResult() { IsValid = true };
            }

            var modelErrors = new List<IModelValidationError>();

            if (modelState.ContainsKey(string.Empty))
            {
                modelErrors.AddRange(modelState[string.Empty].Errors.Select(x => new ModelValidationError(x.ErrorMessage)));
            }
            if (modelState.ContainsKey(WarningSpecialField))
            {
                modelErrors.AddRange(modelState[WarningSpecialField].Errors.Select(x => new ModelValidationError(x.ErrorMessage, true)));
            }

            var propertyErrors = new Dictionary<string, IEnumerable<IModelValidationError>>();
            foreach (var modelError in modelState)
            {
                if (string.IsNullOrEmpty(modelError.Key) || WarningSpecialField == modelError.Key)
                {
                    continue;
                }
                var list = new List<IModelValidationError>();
                list.AddRange(modelError.Value.Errors.Select(x => new ModelValidationError(x.ErrorMessage)));
                propertyErrors[modelError.Key] = list;
            }

            return new ModelValidationResult()
            {
                IsValid = false,
                ModelErrors = modelErrors,
                PropertyErrors = propertyErrors
            };
        }
    }
}
