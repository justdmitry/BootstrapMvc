namespace BootstrapMvc.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface ITagBuilder
    {
        string InnerHtml { get; set; }

        // Summary:
        //     Adds a CSS class to the list of CSS classes in the tag.
        //
        // Parameters:
        //   value:
        //     The CSS class to add.
        void AddCssClass(string value);

        // Summary:
        //     Adds a new attribute to the tag.
        //
        // Parameters:
        //   key:
        //     The key for the attribute.
        //
        //   value:
        //     The value of the attribute.
        void MergeAttribute(string key, string value);

        // Summary:
        //     Adds new attributes or optionally replaces existing attributes in the tag.
        //
        // Parameters:
        //   attributes:
        //     The collection of attributes to add or replace.
        //
        //   replaceExisting:
        //     For each attribute in attributes, true to replace the attribute if an attribute
        //     already exists that has the same key, or false to leave the original attribute
        //     unchanged.
        //
        // Type parameters:
        //   TKey:
        //     The type of the key object.
        //
        //   TValue:
        //     The type of the value object.
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
