using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Lists
{
    public class DefinitionList : ContentElement<DefinitionListContent>
    {
        private bool horizontal;

        public DefinitionList(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region Fluent

        public DefinitionList Horizontal(bool horizontal = true)
        {
            this.horizontal = horizontal;
            return this;
        }

        #endregion

        protected override DefinitionListContent CreateContent()
        {
            return new DefinitionListContent(Context);
        }

        protected override WritableBlock WriteSelfStart(System.IO.TextWriter writer)
        {
            var tb = Context.CreateTagBuilder("dl");
            if (horizontal)
            {
                tb.AddCssClass("dl-horizontal");
            }

            ApplyCss(tb);
            ApplyAttributes(tb);

            writer.Write(tb.GetStartTag());

            return new Content(Context).Value(tb.GetEndTag(), true);
        }
    }
}
