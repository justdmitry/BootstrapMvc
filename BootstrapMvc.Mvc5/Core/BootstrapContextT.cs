using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BootstrapMvc.Core
{
    public class BootstrapContext<TModel> : BootstrapContext, IBootstrapContext<TModel>
    {
        public BootstrapContext(ViewContext viewContext, UrlHelper urlHelper, ViewDataDictionary<TModel> viewData)
            : base(viewContext, urlHelper, viewData)
        {
            this.ViewData = viewData;
        }

        protected new ViewDataDictionary<TModel> ViewData { get; set; }

        public IControlContext GetControlContext<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName = ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState modelState;
            ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState);
            string value = modelState == null || modelState.Value == null
                ? (modelMetadata.Model == null ? string.Empty : modelMetadata.Model.ToString())
                : modelState.Value.AttemptedValue;
            var errors = modelState == null || modelState.Errors == null
                ? null
                : modelState.Errors.Select(e => e.ErrorMessage).ToArray();

            return new ControlContext()
            {
                Name = fullHtmlFieldName,
                IsRequired = !modelMetadata.IsNullableValueType,
                Value = value,
                Errors = errors,
                HasErrors = errors != null && errors.Length > 0,
                HasWarning = false
            };
        }
    }
}
