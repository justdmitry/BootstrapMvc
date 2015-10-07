using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelContent : DisposableContent
    {
        public PanelContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<PanelHeader, AnyContent> Header(object value)
        {
            return Context.CreateWriter<PanelHeader, AnyContent>().Content(value);
        }

        public IWriter2<PanelHeader, AnyContent> Header(params object[] values)
        {
            return Context.CreateWriter<PanelHeader, AnyContent>().Content(values);
        }

        public IWriter2<PanelBody, AnyContent> Body(object value)
        {
            return Context.CreateWriter<PanelBody, AnyContent>().Content(value);
        }

        public IWriter2<PanelBody, AnyContent> Body(params object[] values)
        {
            return Context.CreateWriter<PanelBody, AnyContent>().Content(values);
        }

        public IWriter2<PanelFooter, AnyContent> Footer(object value)
        {
            return Context.CreateWriter<PanelFooter, AnyContent>().Content(value);
        }

        public IWriter2<PanelFooter, AnyContent> Footer(params object[] values)
        {
            return Context.CreateWriter<PanelFooter, AnyContent>().Content(values);
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
