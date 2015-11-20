namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public class DefinitionListContent : DisposableContent
    {
        public DefinitionListContent(IBootstrapContext context, DefinitionList parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private DefinitionList Parent { get; set; }

        public IItemWriter<OrdinaryElement, AnyContent> Name(object content)
        {
            var res = Context.Helper.CreateWriter<OrdinaryElement, AnyContent>(Parent).Content(content);
            res.Item.TagName = "dt";
            return res;
        }

        public IItemWriter<OrdinaryElement, AnyContent> Value(object content)
        {
            var res = Context.Helper.CreateWriter<OrdinaryElement, AnyContent>(Parent).Content(content);
            res.Item.TagName = "dd";
            return res;
        }

        public IItemWriter<OrdinaryElement, AnyContent> Value(params object[] contents)
        {
            var res = Context.Helper.CreateWriter<OrdinaryElement, AnyContent>(Parent).Content(contents);
            res.Item.TagName = "dd";
            return res;
        }        
    }
}
