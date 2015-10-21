namespace BootstrapMvc.Panels
{
    using BootstrapMvc.Core;

    public class PanelContent : DisposableContent
    {
        public PanelContent(IBootstrapContext context, Panel parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private Panel Parent { get; set; }

        public IItemWriter<PanelHeader, AnyContent> Header(object value)
        {
            return Context.Helper.CreateWriter<PanelHeader, AnyContent>(Parent).Content(value);
        }

        public IItemWriter<PanelHeader, AnyContent> Header(params object[] values)
        {
            return Context.Helper.CreateWriter<PanelHeader, AnyContent>(Parent).Content(values);
        }

        public IItemWriter<PanelBody, AnyContent> Body(object value)
        {
            return Context.Helper.CreateWriter<PanelBody, AnyContent>(Parent).Content(value);
        }

        public IItemWriter<PanelBody, AnyContent> Body(params object[] values)
        {
            return Context.Helper.CreateWriter<PanelBody, AnyContent>(Parent).Content(values);
        }

        public IItemWriter<PanelFooter, AnyContent> Footer(object value)
        {
            return Context.Helper.CreateWriter<PanelFooter, AnyContent>(Parent).Content(value);
        }

        public IItemWriter<PanelFooter, AnyContent> Footer(params object[] values)
        {
            return Context.Helper.CreateWriter<PanelFooter, AnyContent>(Parent).Content(values);
        }

        public AnyContent BeginHeader()
        {
            return Header().BeginContent();
        }

        public AnyContent BeginBody()
        {
            return Body().BeginContent();
        }

        public AnyContent BeginFooter()
        {
            return Footer().BeginContent();
        }
    }
}
