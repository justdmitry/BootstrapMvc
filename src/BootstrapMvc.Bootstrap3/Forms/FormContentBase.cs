using System;
using System.Linq.Expressions;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public abstract class FormContentBase : DisposableContent
    {
        public FormContentBase(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        #region Fieldset

        public IWriter2<Fieldset, AnyContent> Fieldset()
        {
            return Context.CreateWriter<Fieldset, AnyContent>();
        }

        public AnyContent BeginFieldset()
        {
            return Fieldset().BeginContent();
        }

        public AnyContent BeginFieldset(object legend)
        {
            return Fieldset().Legend(legend).BeginContent();
        }

        #endregion

        #region Legend

        public IWriter2<Legend, AnyContent> Legend()
        {
            return Context.CreateWriter<Legend, AnyContent>();
        }

        #endregion

        #region FormGroup

        public IWriter2<FormGroup, AnyContent> Group()
        {
            return Context.CreateWriter<FormGroup, AnyContent>();
        }

        public IWriter2<FormGroup, AnyContent> Group(object label)
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

        public IWriter2<HelpBlock, AnyContent> HelpBlock(object content)
        {
            return Context.CreateWriter<HelpBlock, AnyContent>().Content(content);
        }

        public IWriter2<HelpBlock, AnyContent> HelpBlock(params object[] contents)
        {
            return Context.CreateWriter<HelpBlock, AnyContent>().Content(contents);
        }

        public AnyContent BeginHelpBlock()
        {
            return HelpBlock().BeginContent();
        }

        #endregion
    }
}
