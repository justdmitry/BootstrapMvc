using System;
using BootstrapMvc.Core;
using BootstrapMvc.Paging;

namespace BootstrapMvc
{
    public static class PaginatorGeneratorExtensions
    {
        #region Fluent
        
        public static IWriter<PaginatorGenerator> CurrentPage(this IWriter<PaginatorGenerator> target, int value)
        {
            target.Item.CurrentPageValue = value;
            return target;
        }

        public static IWriter<PaginatorGenerator> TotalPages(this IWriter<PaginatorGenerator> target, int value)
        {
            target.Item.TotalPagesValue = value;
            return target;
        }

        public static IWriter<PaginatorGenerator> PageButtonsCount(this IWriter<PaginatorGenerator> target, int countBack, int countForward)
        {
            target.Item.PageButtonsCountBackValue = countBack;
            target.Item.PageButtonsCountForwardValue = countForward;
            return target;
        }

        public static IWriter<PaginatorGenerator> HidePreviousNextButtons(this IWriter<PaginatorGenerator> target, bool hide = true)
        {
            target.Item.HidePreviousNextButtonsValue = hide;
            return target;
        }

        public static IWriter<PaginatorGenerator> ButtonsText(this IWriter<PaginatorGenerator> target, string currentPageButtonTemplate)
        {
            target.Item.ButtonPageTextTemplateValue = currentPageButtonTemplate;
            return target;
        }

        public static IWriter<PaginatorGenerator> ButtonsText(this IWriter<PaginatorGenerator> target, string currentPageTemplate, string previousPageText, string nextPageText)
        {
            target.Item.ButtonPageTextTemplateValue = currentPageTemplate;
            target.Item.ButtonPreviousTextValue = previousPageText;
            target.Item.ButtonNextTextValue = nextPageText;
            return target;
        }

        public static IWriter<PaginatorGenerator> HrefTemplate(this IWriter<PaginatorGenerator> target, string value)
        {
            target.Item.HrefTemplateValue = value;
            return target;
        } 
        
        #endregion
    }
}
