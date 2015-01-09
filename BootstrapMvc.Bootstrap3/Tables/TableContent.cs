using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Tables
{
    public class TableContent : DisposableContent
    {
        public TableContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public TableCaption Caption(object value)
        {
            var obj = new TableCaption(Context);
            obj.Content(value);
            return obj;
        }

        public TableCaption Caption(params object[] values)
        {
            var obj = new TableCaption(Context);
            obj.Content(values);
            return obj;
        }

        public AnyContent BeginCaption()
        {
            return new TableCaption(Context).BeginContent();
        }

        public TableHeader Header()
        {
            return new TableHeader(Context);
        }

        public TableSectionContent BeginHeader()
        {
            return new TableHeader(Context).BeginContent();
        }

        public TableBody Body()
        {
            return new TableBody(Context);
        }
        
        public TableSectionContent BeginBody()
        {
            return new TableBody(Context).BeginContent();
        }
        
        public TableFooter Footer()
        {
            return new TableFooter(Context);
        }

        public TableSectionContent BeginFooter()
        {
            return new TableFooter(Context).BeginContent();
        }
    }
}
