using System;
using System.Collections.Generic;
using System.IO;

namespace BootstrapMvc.Core
{
    public interface IBootstrapContext
    {
        IWriter<T> CreateWriter<T>() where T : IWritable, new();

        IWriter2<T, TContent> CreateWriter<T, TContent>()
            where T : ContentElement<TContent>, new()
            where TContent : DisposableContent;

        TextWriter Writer { get; }

        ITagBuilder CreateTagBuilder(string tagName);

        string CreateUrl(IDictionary<string, object> routeValues);

        string CreateUrl(IDictionary<string, object> routeValues, string protocol, string hostName);

        string HtmlEncode(string value);

        string GetMessage(int id);

        void Push(object value);

        T PeekNearest<T>() where T : class;

        void PopIfEqual(object value);
    }
}
