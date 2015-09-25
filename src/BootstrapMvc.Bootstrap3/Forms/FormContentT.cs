using BootstrapMvc.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BootstrapMvc.Forms
{
    public class FormContent<T> : FormContent
    {
        public new IBootstrapContext<T> Context { get; private set; }

        public FormContent(IBootstrapContext<T> context)
            : base(context)
        {
            this.Context = context;
        }

        public FormGroup GroupFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            return ControlContextHolderExtensions.ControlContext(new FormGroup(Context), Context.GetControlContext(expression));
        }

        public FormGroup GroupFor<TProperty>(Expression<Func<T, TProperty>> expression, object label)
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
