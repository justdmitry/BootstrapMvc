using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class DefinitionListContent : DisposableContent
    {
        public DefinitionListContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; set; }

        public IWriter2<OrdinaryElement, AnyContent> Name(object content)
        {
            var res = Context.CreateWriter<OrdinaryElement, AnyContent>().Content(content);
            res.Item.TagName = "dt";
            return res;
        }

        public IWriter2<OrdinaryElement, AnyContent> Value(object content)
        {
            var res = Context.CreateWriter<OrdinaryElement, AnyContent>().Content(content);
            res.Item.TagName = "dd";
            return res;
        }

        public IWriter2<OrdinaryElement, AnyContent> Value(params object[] contents)
        {
            var res = Context.CreateWriter<OrdinaryElement, AnyContent>().Content(contents);
            res.Item.TagName = "dd";
            return res;
        }        
    }
}
