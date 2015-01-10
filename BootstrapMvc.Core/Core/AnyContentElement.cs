using System;
using System.Collections.Generic;

namespace BootstrapMvc.Core
{
    public abstract class AnyContentElement : ContentElement<AnyContent>
    {
        private WritableBlock content;

        public AnyContentElement(IBootstrapContext context)
            : base(context)
        {
            // nothing
        }

        #region Fluent

        public AnyContentElement Content(object value)
        {
            this.content = new Content(Context).Value(value).WriteWhitespaceSuffix(false);
            return this;
        }

        public AnyContentElement Content(params object[] values)
        {
            this.content = new Content(Context).Value(values);
            return this;
        }

        public AnyContentElement AddContent(object value)
        {
            var newContent = new Content(Context).Value(value).WriteWhitespaceSuffix(false);
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

        #endregion

        protected abstract string WriteSelfStartTag(System.IO.TextWriter writer);

        protected override AnyContent CreateContent()
        {
            return new AnyContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var endTag = WriteSelfStartTag(writer);
            if (content != null)
            {
                content.WriteTo(writer);
            }
            return new Content(Context).Value(endTag, true);
        }
    }
}
