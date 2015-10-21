namespace BootstrapMvc.Mvc5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using BootstrapMvc.Core;

    public class BootstrapHelper<TModel> : BootstrapHelper, IAnyContentMarker<TModel>, IWritingHelper<TModel>, IBootstrapContext<TModel>
    {
        private static readonly string WarningSpecialField = "BootstrapContext_WarningField";

        public BootstrapHelper(ViewContext viewContext, UrlHelper urlHelper, ViewDataDictionary<TModel> viewData, Func<int, string> messageSource)
            : base(viewContext, urlHelper, messageSource)
        {
            this.ViewData = viewData;
            this.ValidationResult = GetModelValidationResult(viewData.ModelState);
        }

        public IModelValidationResult ValidationResult { get; private set; }

        protected ViewDataDictionary<TModel> ViewData { get; set; }

        IWritingHelper<TModel> IBootstrapContext<TModel>.Helper
        {
            get
            {
                return this;
            }
        }

        IBootstrapContext<TModel> IAnyContentMarker<TModel>.Context
        {
            get
            {
                return this;
            }
        }

        public void FillControlContext<TProperty>(IControlContext target, Expression<Func<TModel, TProperty>> expression)
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

            target.FieldName = fullHtmlFieldName;
            target.IsRequired = modelMetadata.IsRequired;
            target.FieldValue = value;
            target.Errors = errors;
            target.HasErrors = errors != null && errors.Length > 0;
            target.HasWarning = false;
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
