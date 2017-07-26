namespace BootstrapMvc.Forms
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    public class HiddenValue : Element, IControlContext
    {
        #region IControlContext

        public string FieldName { get; set; }

        public string DisplayName { get; set; }

        public object FieldValue { get; set; }

        public Type DataType { get; set; }

        public bool IsRequired { get; set; }

        public string[] Errors { get; set; }

        public bool HasErrors { get; set; }

        public bool HasWarning { get; set; }

        #endregion

        protected override void WriteSelf(TextWriter writer)
        {
            var input = Helper.CreateTagBuilder("input");
            input.MergeAttribute("type", "hidden", true);

            input.MergeAttribute("id", FieldName, true);
            input.MergeAttribute("name", FieldName, true);
            if (IsRequired)
            {
                input.MergeAttribute("required", "required", true);
            }

            input.MergeAttribute("value", FieldValue?.ToString(), true);

            ApplyCss(input);
            ApplyAttributes(input);

            input.WriteFullTag(writer);
        }
    }
}
