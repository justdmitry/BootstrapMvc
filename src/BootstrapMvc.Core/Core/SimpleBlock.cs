namespace BootstrapMvc.Core
{
    using System;

    public class SimpleBlock : WritableItem
    {
        public object Value { get; set; }

        public bool DisableEncoding { get; set; } = false;

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (Value == null)
            {
                return;
            }
            var str = Value as string;
            if (str != null)
            {
                if (DisableEncoding)
                {
                    writer.Write(str);
                }
                else
                {
                    writer.Write(Helper.HtmlEncode(str));
                }
                return;
            }
            Helper.WriteValue(writer, Value);
        }
    }
}
