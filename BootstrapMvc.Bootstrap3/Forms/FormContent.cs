using System;
using System.Linq.Expressions;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormContent : DisposableContent
    {
        public FormContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fieldset

        public Fieldset Fieldset()
        {
            return new Fieldset(Context);
        }

        public FormContent BeginFieldset()
        {
            return new Fieldset(Context).BeginContent();
        }

        public FormContent BeginFieldset(object legend)
        {
            return new Fieldset(Context).Legend(legend).BeginContent();
        }

        #endregion

        #region Lenend

        public Legend Legend()
        {
            return new Legend(Context);
        }

        #endregion

        #region FormGroup

        public FormGroup Group()
        {
            return new FormGroup(Context);
        }

        public FormGroup Group(object label)
        {
            return new FormGroup(Context).Label(label);
        }

        public AnyContent BeginGroup()
        {
            return new FormGroup(Context).BeginContent();
        }

        public AnyContent BeginGroup(object label)
        {
            return new FormGroup(Context).Label(label).BeginContent();
        }

        #endregion

        #region HelpBlock

        public HelpBlock HelpBlock(object content)
        {
            return (HelpBlock)new HelpBlock(Context).Content(content);
        }

        public HelpBlock HelpBlock(params object[] contents)
        {
            return (HelpBlock)new HelpBlock(Context).Content(contents);
        }

        public AnyContent BeginHelpBlock()
        {
            return new HelpBlock(Context).BeginContent();
        }

        #endregion
    }
}
