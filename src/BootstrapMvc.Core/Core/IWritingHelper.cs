namespace BootstrapMvc.Core
{
    using System;
    using System.Collections.Generic;

    public interface IWritingHelper
    {
        IItemWriter<T> CreateWriter<T>(IWritableItem parent) where T : IWritableItem, new();

        IItemWriter<T, TContent> CreateWriter<T, TContent>(IWritableItem parent)
            where T : ContentElement<TContent>, IWritableItem, new()
            where TContent : DisposableContent;

        ITagBuilder CreateTagBuilder(string tagName);

        string CreateUrl(IDictionary<string, object> routeValues);

        string CreateUrl(IDictionary<string, object> routeValues, string protocol, string hostName);

        string HtmlEncode(string value);

        void WriteValue(System.IO.TextWriter writer, object value);
    }
}
