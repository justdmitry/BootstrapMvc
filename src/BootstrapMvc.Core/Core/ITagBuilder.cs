namespace BootstrapMvc.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface ITagBuilder
    {
        string InnerHtml { get; set; }

        /// <summary>
        /// Adds a CSS class to the list of CSS classes in the tag.
        /// </summary>
        /// <param name="value">The CSS class to add.</param>
        void AddCssClass(string value);

        /// <summary>
        /// Adds a new attribute to the tag or (optionally) replaces existing one
        /// </summary>
        /// <param name="key">The key for the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <param name="replaceExisting"><b>true</b> to replace an existing attribute if an attribute exists that has the specified key value, or <b>false</b> to leave the original attribute unchanged.</param>
        void MergeAttribute(string key, string value, bool replaceExisting);

        /// <summary>
        /// Adds new attributes or optionally replaces existing attributes in the tag.
        /// </summary>
        /// <typeparam name="TKey">The type of the key object.</typeparam>
        /// <typeparam name="TValue">The type of the value object.</typeparam>
        /// <param name="attributes">The collection of attributes to add or replace.</param>
        /// <param name="replaceExisting">For each attribute in attributes, <b>true</b> to replace the attribute if an attribute already exists that has the same key, or <b>false</b> to leave the original attribute unchanged.</param>
        void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting);

        [Obsolete("Use WriteStartTag(TextWriter)")]
        string GetStartTag();

        string GetEndTag();

        [Obsolete("Use WriteFullTag(TextWriter)")]
        string GetFullTag();

        void WriteStartTag(TextWriter writer);

        void WriteEndTag(TextWriter writer);

        void WriteFullTag(TextWriter writer);
    }
}
