namespace BootstrapMvc.Core
{
    using System;

    public interface IControlContext : IWritableItem
    {
        string FieldName { get; set; }

        object FieldValue { get; set; }

        bool IsRequired { get; set; }

        string[] Errors { get; set; }

        bool HasErrors { get; set; }

        bool HasWarning { get; set; }
    }
}
