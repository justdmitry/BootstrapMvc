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

        #region FormT

        public static Form<T> Form<T>(this IAnyContentMarker<T> contentHelper)
        {
            return new Form<T>(contentHelper.Context);
        }

        public static Form<T> Form<T>(this IAnyContentMarker<T> contentHelper, FormType type)
        {
            return new Form<T>(contentHelper.Context).Type(type);
        }

        public static Form<T> Form<T>(this IAnyContentMarker<T> contentHelper, FormEnctype enctype)
        {
            return new Form<T>(contentHelper.Context).Enctype(enctype);
        }

        public static Form<T> Form<T>(this IAnyContentMarker<T> contentHelper, FormType type, FormEnctype enctype)
        {
            return new Form<T>(contentHelper.Context).Type(type).Enctype(enctype);
        }

        public static FormContent<T> BeginForm<T>(this IAnyContentMarker<T> contentHelper)
        {
            return Form(contentHelper).BeginContent();
        }

        public static FormContent<T> BeginForm<T>(this IAnyContentMarker<T> contentHelper, FormType type)
        {
            return Form(contentHelper, type).BeginContent();
        }

        public static FormContent<T> BeginForm<T>(this IAnyContentMarker<T> contentHelper, FormEnctype enctype)
        {
            return Form(contentHelper, enctype).BeginContent();
        }

        public static FormContent<T> BeginForm<T>(this IAnyContentMarker<T> contentHelper, FormType type, FormEnctype enctype)
        {
            return Form(contentHelper, type, enctype).BeginContent();
        }

        #endregion

        #region Fieldset

        public static Fieldset FormFieldset(this IAnyContentMarker contentHelper)
        {
            return new Fieldset(contentHelper.Context);
        }

        public static AnyContent BeginFormFieldset(this IAnyContentMarker contentHelper)
        {
            return new Fieldset(contentHelper.Context).BeginContent();
        }

        public static AnyContent BeginFormFieldset(this IAnyContentMarker contentHelper, object legend)
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

        public static FormGroup FormGroup(this IAnyContentMarker contentHelper, object label)
        {
            return new FormGroup(contentHelper.Context).Label(label);
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper)
        {
            return FormGroup(contentHelper).BeginContent();
        }

        public static AnyContent BeginFormGroup(this IAnyContentMarker contentHelper, object label)
        {
            return FormGroup(contentHelper, label).BeginContent();
        }

        public static FormGroup FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return ControlContextHolderExtensions.ControlContext(new FormGroup(contentHelper.Context), contentHelper.Context.GetControlContext(expression));
        }

        public static FormGroup FormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, object label)
        {
            return FormGroupFor(contentHelper, expression).Label(label);
        }

        public static AnyContent BeginFormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return FormGroupFor(contentHelper, expression).BeginContent();
        }

        public static AnyContent BeginFormGroupFor<TModel, TProperty>(this IAnyContentMarker<TModel> contentHelper, Expression<Func<TModel, TProperty>> expression, object label)
        {
            return FormGroupFor(contentHelper, expression, label).BeginContent();
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
