namespace BootstrapMvc.Mvc6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.ModelBinding;
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Mvc.ViewFeatures;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.WebEncoders;
    using BootstrapMvc.Core;

    public class BootstrapHelper<TModel> : BootstrapHelper, IAnyContentMarker<TModel>, IWritingHelper<TModel>, IBootstrapContext<TModel>
    {
        private static readonly string WarningSpecialField = "BootstrapContext_WarningField";

        public BootstrapHelper(IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
            : base(urlHelper, htmlEncoder)
        {
            // Nothing
        }

        public IModelValidationResult ValidationResult { get; private set; }

        protected ViewDataDictionary<TModel> ViewData { get; set; }

        protected IModelMetadataProvider MetadataProvider { get; set; }

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

        public override void Contextualize(ViewContext viewContext)
        {
            this.ViewData = (ViewDataDictionary<TModel>)viewContext.ViewData;
            this.ValidationResult = GetModelValidationResult(ViewData.ModelState);
            this.MetadataProvider = viewContext.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();
            base.Contextualize(viewContext);
        }

        public void FillControlContext<TProperty>(IControlContext target, Expression<Func<TModel, TProperty>> expression)
        {
            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, ViewData, MetadataProvider);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            ModelState modelState;
            ViewContext.ViewData.ModelState.TryGetValue(fullName, out modelState);

            object value = null;
            if (modelState != null && modelState.RawValue != null)
            {
                value = modelState.RawValue;
            }
            else if (modelExplorer.Model != null)
            {
                value = modelExplorer.Model;
            }

            var errors = modelState == null || modelState.Errors == null
                ? null
                : modelState.Errors.Select(e => e.ErrorMessage).ToArray();

            target.FieldName = fullName;
            target.IsRequired = modelExplorer.Metadata.IsRequired;
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
