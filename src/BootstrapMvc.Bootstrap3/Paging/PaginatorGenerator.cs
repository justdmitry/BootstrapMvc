using System;
using BootstrapMvc.Core;
using System.Collections.Generic;

namespace BootstrapMvc.Paging
{
    public class PaginatorGenerator : Element
    {
        public PaginatorGenerator()
        {
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

        public Paginator Paginator { get; set; }

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

        protected override void WriteSelf(System.IO.TextWriter writer, IBootstrapContext context)
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

            using (Paginator.BeginContent(writer, context))
            {
                if (!HidePreviousNextButtonsValue)
                {
                    var p = Math.Max(1, CurrentPageValue - 1);
                    var pi = new PaginatorItem()
                    {
                        DisabledValue = (p == CurrentPageValue),
                        HrefValue = string.Format(HrefTemplateValue, p)
                    };
                    pi.AddContent(ButtonPreviousTextValue);
                    pi.WriteTo(writer, context);
                }
                for (var i = pageStart; i <= pageEnd; i++)
                {
                    var pi = new PaginatorItem()
                    {
                        ActiveValue = (i == CurrentPageValue),
                        HrefValue = string.Format(HrefTemplateValue, i)
                    };
                    pi.AddContent(string.Format(ButtonPageTextTemplateValue, i));
                    pi.WriteTo(writer, context);
                }
                if (!HidePreviousNextButtonsValue)
                {
                    var p = Math.Min(TotalPagesValue, CurrentPageValue + 1);
                    var pi = new PaginatorItem()
                    {
                        DisabledValue = (p == CurrentPageValue),
                        HrefValue = string.Format(HrefTemplateValue, p)
                    };
                    pi.AddContent(ButtonNextTextValue);
                    pi.WriteTo(writer, context);
                }
            }
        }
    }
}
