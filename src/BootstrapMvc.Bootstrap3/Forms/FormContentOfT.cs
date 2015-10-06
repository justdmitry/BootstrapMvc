using System;
using System.Linq.Expressions;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class FormContent<T> : FormContentBase
    {
        public FormContent(IBootstrapContext<T> context)
            : base(context)
        {
            this.Context = context;
        }

        public new IBootstrapContext<T> Context { get; private set; }

        public IWriter2<FormGroup, AnyContent> GroupFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var fg = Context.CreateWriter<FormGroup, AnyContent>();
            return ControlContextHolderExtensions.ControlContext(fg, Context.GetControlContext(expression));
        }

        public IWriter2<FormGroup, AnyContent> GroupFor<TProperty>(Expression<Func<T, TProperty>> expression, object label)
        {
            return GroupFor(expression).Label(label);
        }

        public AnyContent BeginGroupFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            return GroupFor(expression).BeginContent();
        }

        public AnyContent BeginGroupFor<TProperty>(Expression<Func<T, TProperty>> expression, object label)
        {
            return GroupFor(expression, label).BeginContent();
        }
    }
}
