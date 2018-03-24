namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public abstract class FormContentBase : DisposableContent
    {
        public FormContentBase(IBootstrapContext context, IForm parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        protected IForm Parent { get; set; }

        #region Fieldset

        public IItemWriter<Fieldset, AnyContent> Fieldset()
        {
            return Context.Helper.CreateWriter<Fieldset, AnyContent>(Parent);
        }

        public AnyContent BeginFieldset()
        {
            return Fieldset().BeginContent();
        }

        public AnyContent BeginFieldset(params object[] legend)
        {
            return Fieldset().Legend(legend).BeginContent();
        }

        #endregion

        #region Legend

        public IItemWriter<Legend, AnyContent> Legend()
        {
            return Context.Helper.CreateWriter<Legend, AnyContent>(Parent);
        }

        #endregion

        #region FormGroup

        public IItemWriter<FormGroup, AnyContent> Group()
        {
            return Context.Helper.CreateWriter<FormGroup, AnyContent>(Parent);
        }

        public IItemWriter<FormGroup, AnyContent> Group(object label)
        {
            return Group().Label(label);
        }

        public AnyContent BeginGroup()
        {
            return Group().BeginContent();
        }

        public AnyContent BeginGroup(object label)
        {
            return Group(label).BeginContent();
        }

        #endregion

        #region HelpBlock

        public IItemWriter<HelpText, AnyContent> HelpText(params object[] contents)
        {
            return Context.Helper.CreateWriter<HelpText, AnyContent>(Parent).Content(contents);
        }

        public AnyContent BeginHelpText()
        {
            return HelpText().BeginContent();
        }

        #endregion
    }
}
