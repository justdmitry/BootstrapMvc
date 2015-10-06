using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public class SelectOptGroupContent : DisposableContent
    {
        public SelectOptGroupContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; set; }

        public IWriter2<SelectOption, AnyContent> Option(object value)
        {
            return Option(value, value.ToString());
        }

        public IWriter2<SelectOption, AnyContent> Option(object value, string text)
        {
            return Context.CreateWriter<SelectOption, AnyContent>().Value(value.ToString()).Content(text);
        }
    }
}
