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

        public IItemWriter<DefinitionListTerm, AnyContent> Term(object content)
        {
            return Context.Helper.CreateWriter<DefinitionListTerm, AnyContent>(Parent).Content(content);
        }

        [Obsolete("Use Term()")]
        public IItemWriter<DefinitionListTerm, AnyContent> Name(object content)
        {
            return Term(content);
        }

        public IItemWriter<DefinitionListDescription, AnyContent> Description(params object[] contents)
        {
            return Context.Helper.CreateWriter<DefinitionListDescription, AnyContent>(Parent).Content(contents);
        }

        [Obsolete("Use Description()")]
        public IItemWriter<DefinitionListDescription, AnyContent> Value(params object[] contents)
        {
            return Description(contents);
        }
    }
}
