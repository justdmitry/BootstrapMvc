using System;
using BootstrapMvc.Core;
using BootstrapMvc.Paging;

namespace BootstrapMvc
{
    public static class PaginatorGeneratorExtensions
    {
        #region Fluent
        
        public static IItemWriter<PaginatorGenerator> CurrentPage(this IItemWriter<PaginatorGenerator> target, int value)
        {
            target.Item.CurrentPage = value;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> TotalPages(this IItemWriter<PaginatorGenerator> target, int value)
        {
            target.Item.TotalPages = value;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> PageButtonsCount(this IItemWriter<PaginatorGenerator> target, int countBack, int countForward)
        {
            target.Item.PageButtonsCountBack = countBack;
            target.Item.PageButtonsCountForward = countForward;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> HidePreviousNextButtons(this IItemWriter<PaginatorGenerator> target, bool hide = true)
        {
            target.Item.HidePreviousNextButtons = hide;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> ButtonsText(this IItemWriter<PaginatorGenerator> target, string currentPageButtonTemplate)
        {
            target.Item.ButtonPageTextTemplate = currentPageButtonTemplate;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> ButtonsText(this IItemWriter<PaginatorGenerator> target, string currentPageTemplate, string previousPageText, string nextPageText)
        {
            target.Item.ButtonPageTextTemplate = currentPageTemplate;
            target.Item.ButtonPreviousText = previousPageText;
            target.Item.ButtonNextText = nextPageText;
            return target;
        }

        public static IItemWriter<PaginatorGenerator> HrefTemplate(this IItemWriter<PaginatorGenerator> target, string value)
        {
            target.Item.HrefTemplate = value;
            return target;
        } 
        
        #endregion
    }
}
