using BootstrapMvc.Core;

namespace BootstrapMvc.Panels
{
    public class PanelContent : DisposableContext
    {
        public PanelContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public PanelHeader Header(object value)
        {
            var obj = new PanelHeader(Context);
            obj.Content(value);
            return obj;
        }

        public PanelHeader Header(params object[] values)
        {
            var obj = new PanelHeader(Context);
            obj.Content(values);
            return obj;
        }

        public PanelBody Body(object value)
        {
            var obj = new PanelBody(Context);
            obj.Content(value);
            return obj;
        }

        public PanelBody Body(params object[] values)
        {
            var obj = new PanelBody(Context);
            obj.Content(values);
            return obj;
        }

        public PanelFooter Footer(object value)
        {
            var obj = new PanelFooter(Context);
            obj.Content(value);
            return obj;
        }

        public PanelFooter Footer(params object[] values)
        {
            var obj = new PanelFooter(Context);
            obj.Content(values);
            return obj;
        }

        public AnyContentContext BeginHeader()
        {
            return new PanelHeader(Context).BeginContent();
        }

        public AnyContentContext BeginBody()
        {
            return new PanelBody(Context).BeginContent();
        }

        public AnyContentContext BeginFooter()
        {
            return new PanelFooter(Context).BeginContent();
        }
    }
}
