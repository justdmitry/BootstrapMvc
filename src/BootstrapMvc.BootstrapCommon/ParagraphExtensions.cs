namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ParagraphExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Lead<T>(this IItemWriter<T, AnyContent> target, bool lead = true) 
            where T : Paragraph
        {
            target.Item.Lead = lead;
            return target;
        }

        #endregion

        #region Generation

        public static IItemWriter<Paragraph, AnyContent> Paragraph(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.CreateWriter<Paragraph, AnyContent>().Content(contents);
        }

        /// <summary>
        /// Synonym for <see cref="Paragraph(IAnyContentMarker, object[])">Paragraph</see>
        /// </summary>
        public static IItemWriter<Paragraph, AnyContent> P(this IAnyContentMarker contentHelper, params object[] contents)
        {
            return contentHelper.CreateWriter<Paragraph, AnyContent>().Content(contents);
        }

        public static AnyContent BeginParagraph(this IAnyContentMarker contentHelper)
        {
            return Paragraph(contentHelper).BeginContent();
        }

        #endregion
    }
}
