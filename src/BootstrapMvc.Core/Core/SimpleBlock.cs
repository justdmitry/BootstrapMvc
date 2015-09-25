using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public class SimpleBlock : WritableBlock
    {
        private object value = null;

        private bool writeWithoutEncoding = false;

        public SimpleBlock(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public SimpleBlock Value(string value, bool writeWithoutEncoding = false)
        {
            this.value = value;
            this.writeWithoutEncoding = writeWithoutEncoding;
            return this;
        }

        public SimpleBlock Value(object value)
        {
            this.value = value;
            this.writeWithoutEncoding = false;
            return this;
        }

        public SimpleBlock Value(IEnumerable<object> values)
        {
            var enumerator = values.GetEnumerator();
            if (enumerator.MoveNext())
            {
                this.value = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    AppendNextBlock(new SimpleBlock(Context).Value(enumerator.Current));
                }
            }
            else
            {
                this.value = null;
            }
            return this;
        }

        #endregion

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (value == null)
            {
                return;
            }
            var block = value as WritableBlock;
            if (block != null)
            {
                block.WriteTo(writer);
                return;
            }
            var str = value as string;
            if (str != null)
            {
                if (writeWithoutEncoding)
                {
                    writer.Write(str);
                }
                else
                {
                    writer.Write(Context.HtmlEncode(str));
                }
                return;
            }
            Context.Write(value);
        }
    }
}
