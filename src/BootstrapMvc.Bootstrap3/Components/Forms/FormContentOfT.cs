namespace BootstrapMvc.Forms
{
    using System;
    using System.Linq.Expressions;
    using BootstrapMvc.Core;

    public class FormContent<T> : FormContentBase
    {
        public FormContent(IBootstrapContext<T> context, IForm parent)
            : base(context, parent)
        {
            this.Context = context;
        }

        private IBootstrapContext<T> Context { get; set; }

        public IItemWriter<FormGroup, AnyContent> GroupFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var fg = Context.Helper.CreateWriter<FormGroup, AnyContent>(Parent);
            Context.Helper.FillControlContext(fg.Item, expression);
            if (fg.Item.DataType != typeof(bool) && fg.Item.DataType != typeof(bool?))
            {
                fg.Label(fg.Item.DisplayName);
            }
            return fg;
        }

        public IItemWriter<FormGroup, AnyContent> GroupFor<TProperty>(Expression<Func<T, TProperty>> expression, object label)
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
