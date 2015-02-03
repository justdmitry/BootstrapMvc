using System;
using System.Linq.Expressions;
using BootstrapMvc.Core;
using BootstrapMvc.Forms;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region Form

        public static Form Form(this IAnyContentMarker contentHelper)
        {
            return new Form(contentHelper.Context);
        }

        public static Form Form(this IAnyContentMarker contentHelper, FormType type)
        {
            return new Form(contentHelper.Context).Type(type);
        }

        public static Form Form(this IAnyContentMarker contentHelper, FormEnctype enctype)
        {
            return new Form(contentHelper.Context).Enctype(enctype);
        }

        public static Form Form(this IAnyContentMarker contentHelper, FormType type, FormEnctype enctype)
        {
            return new Form(contentHelper.Context).Type(type).Enctype(enctype);
        }

        public static FormContent BeginForm(this IAnyContentMarker contentHelper)
        {
            return Form(contentHelper).BeginContent();
        }

        public static FormContent BeginForm(this IAnyContentMarker contentHelper, FormType type)
        {
            return Form(contentHelper, type).BeginContent();
        }

        public static FormContent BeginForm(this IAnyContentMarker contentHelper, FormEnctype enctype)
        {
            return Form(contentHelper, enctype).BeginContent();
        }

        public static FormContent BeginForm(this IAnyContentMarker contentHelper, FormType type, FormEnctype enctype)
        {
            return Form(contentHelper, type, enctype).BeginContent();
        }

        #endregion

        #region Fieldset

        public static Fieldset FormFieldset(this IAnyContentMarker contentHelper)
        {
            return new Fieldset(contentHelper.Context);
        }

        public static FormContent BeginFormFieldset(this IAnyContentMarker contentHelper)
        {
            return new Fieldset(contentHelper.Context).BeginContent();
        }

        public static FormContent BeginFormFieldset(this IAnyContentMarker contentHelper, object legend)
        {
            return new Fieldset(contentHelper.Context).Legend(legend).BeginContent();
        }

        #endregion

        #region Legend

        public static Legend FormLegend(this IAnyContentMarker contentHelper)
        {
            return new Legend(contentHelper.Context);
        }

        #endregion

        #region FormGroup

        public static FormGroup FormGroup(this IAnyContentMarker contentHelper)
        {
            return new FormGroup(contentHelper.Context);
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper)
        {
            return new FormGroup(contentHelper.Context).BeginContent();
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper, object label)
        {
            return new FormGroup(contentHelper.Context).Label(label).BeginContent();
        }

        public static FormGroup FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return new FormGroup(contentHelper.Context).ControlContext(contentHelper.Context.GetControlContext(expression));
        }

        public static IControlContext For<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return contentHelper.Context.GetControlContext(expression);
        }

        #endregion

        #region HelpBlock

        public static HelpBlock HelpBlock(this IAnyContentMarker contentHelper, object content)
        {
            return new HelpBlock(contentHelper.Context).Content(content);
        }

        public static HelpBlock HelpBlock(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return new HelpBlock(contentHelper.Context).Content(contents);
        }

        public static AnyContent BeginHelpBlock(this IAnyContentMarker contentHelper)
        {
            return new HelpBlock(contentHelper.Context).BeginContent();
        }

        #endregion

        public static ValidationSummary<TModel> ValidationSummary<TModel>(this IAnyContentMarker<TModel> contentHelper)
        {
            return new ValidationSummary<TModel>(contentHelper.Context);
        }
    }
}
