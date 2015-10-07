using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public abstract class AnyContentElement : ContentElement<AnyContent>
    {
        private WritableBlock content;

        protected string endTag = null;

        public AnyContentElement AddContent(object value)
        {
            var newContent = new SimpleBlock().Value(value);
            if (content == null)
            {
                content = newContent;
            }
            else
            {
                content.Append(newContent);
            }
            return this;
        }

        protected abstract string WriteSelfStartTag(System.IO.TextWriter writer, IBootstrapContext context);

        protected override AnyContent CreateContentContext(IBootstrapContext context)
        {
            return new AnyContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer, IBootstrapContext context)
        {
            endTag = WriteSelfStartTag(writer, context);
            if (content != null)
            {
                content.WriteTo(writer, context);
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer, IBootstrapContext context)
        {
            writer.Write(endTag);
        }
    }
}
