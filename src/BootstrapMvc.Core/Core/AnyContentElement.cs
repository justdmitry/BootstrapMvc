namespace BootstrapMvc.Core
{
    using System;
    using System.Collections.Generic;

    public abstract class AnyContentElement : ContentElement<AnyContent>
    {
        private List<IWritableItem> contents;

        protected string endTag = null;

        public void AddContent(IWritableItem value)
        {
            if (value == null)
            {
                return;
            }

            value.Parent = this;

            if (contents == null)
            {
                contents = new List<IWritableItem>();
            }

            contents.Add(value);
        }

        protected abstract string WriteSelfStartTag(System.IO.TextWriter writer);

        protected override AnyContent CreateContentContext(IBootstrapContext context)
        {
            return new AnyContent(context);
        }

        protected override void WriteSelfStart(System.IO.TextWriter writer)
        {
            endTag = WriteSelfStartTag(writer);
            if (contents != null)
            {
                foreach (var content in contents)
                {
                    content.WriteTo(writer);
                }
            }
        }

        protected override void WriteSelfEnd(System.IO.TextWriter writer)
        {
            writer.Write(endTag);
        }
    }
}
