using System;
using BootstrapMvc.Core;
using System.Collections.Generic;

namespace BootstrapMvc.Paging
{
    public class PaginatorGenerator : Element
    {
        public PaginatorGenerator(Paginator paginator)
            : base(paginator.Context)
        {
            Paginator = paginator;

            TotalPagesValue = 1;
            CurrentPageValue = 1;
            PageButtonsCountBackValue = -1;
            PageButtonsCountForwardValue = -1;
            HidePreviousNextButtonsValue = false;
            ButtonPreviousTextValue = "«";
            ButtonNextTextValue = "»";
            ButtonPageTextTemplateValue = "{0}";
            HrefTemplateValue = "page={0}";
        }

        public Paginator Paginator { get; private set; }

        public int TotalPagesValue { get; set; }

        public int CurrentPageValue { get; set; }

        public int PageButtonsCountBackValue { get; set; }

        public int PageButtonsCountForwardValue { get; set; }

        public bool HidePreviousNextButtonsValue { get; set; }

        /// <summary>
        /// Pattern string for generating page button text. Default <value>{0}</value>
        /// </summary>
        public string ButtonPageTextTemplateValue { get; set; }

        public string ButtonPreviousTextValue { get; set; }

        public string ButtonNextTextValue { get; set; }

        public string HrefTemplateValue { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (CurrentPageValue < 1)
            {
                throw new ArgumentOutOfRangeException("CurrentPage must be 1 or greater");
            }
            if (TotalPagesValue < 1)
            {
                throw new ArgumentOutOfRangeException("TotalPages must be 1 or greater");
            }
            if (CurrentPageValue > TotalPagesValue)
            {
                throw new ArgumentOutOfRangeException(string.Format("CurrentPage ({0}) must be less or equal to TotalPages ({1})", CurrentPageValue, TotalPagesValue));
            }

            var pageStart = (PageButtonsCountBackValue == -1) ? 1 : Math.Max(1, CurrentPageValue - PageButtonsCountBackValue);
            var pageEnd = (PageButtonsCountForwardValue == -1) ? TotalPagesValue : Math.Min(TotalPagesValue, CurrentPageValue + PageButtonsCountForwardValue);

            var generateButton = new Func<int, PaginatorItem>((page) => {
                return new PaginatorItem(Context)
                    .Disabled(page == CurrentPageValue)
                    .Href(string.Format(HrefTemplateValue, page));
            });

            using (Paginator.BeginContent())
            {
                if (!HidePreviousNextButtonsValue)
                {
                    var p = Math.Max(1, CurrentPageValue - 1);
                    new PaginatorItem(Context).Content(ButtonPreviousTextValue).Disabled(p == CurrentPageValue).Href(string.Format(HrefTemplateValue, p)).WriteTo(writer);
                }
                for (var i = pageStart; i <= pageEnd; i++)
                {
                    new PaginatorItem(Context).Content(string.Format(ButtonPageTextTemplateValue, i)).Active(i == CurrentPageValue).Href(string.Format(HrefTemplateValue, i)).WriteTo(writer);
                }
                if (!HidePreviousNextButtonsValue)
                {
                    var p = Math.Min(TotalPagesValue, CurrentPageValue + 1);
                    new PaginatorItem(Context).Content(ButtonNextTextValue).Disabled(p == CurrentPageValue).Href(string.Format(HrefTemplateValue, p)).WriteTo(writer);
                }
            }
        }
    }
}
