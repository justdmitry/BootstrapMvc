namespace BootstrapMvc.Controls
{
    using System;
    using BootstrapMvc.Core;

    public class SelectOptGroupContent : DisposableContent
    {
        public SelectOptGroupContent(IBootstrapContext context, IWritableItem parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        protected IBootstrapContext Context { get; set; }

        protected IWritableItem Parent { get; set; }

        public IItemWriter<SelectOption, AnyContent> Option(object value)
        {
            return Option(value, value.ToString());
        }

        public IItemWriter<SelectOption, AnyContent> Option(object value, string text)
        {
            return Context.Helper.CreateWriter<SelectOption, AnyContent>(Parent).Value(value.ToString()).Content(text);
        }
    }
}
