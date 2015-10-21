namespace BootstrapMvc.Paging
{
    using System;
    using BootstrapMvc.Core;
    using System.Collections.Generic;

    public class PaginatorGenerator : Element
    {
        public PaginatorGenerator()
        {
            TotalPages = 1;
            CurrentPage = 1;
            PageButtonsCountBack = -1;
            PageButtonsCountForward = -1;
            HidePreviousNextButtons = false;
            ButtonPreviousText = "«";
            ButtonNextText = "»";
            ButtonPageTextTemplate = "{0}";
            HrefTemplate = "page={0}";
        }

        public Paginator Paginator { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PageButtonsCountBack { get; set; }

        public int PageButtonsCountForward { get; set; }

        public bool HidePreviousNextButtons { get; set; }

        /// <summary>
        /// Pattern string for generating page button text. Default <value>{0}</value>
        /// </summary>
        public string ButtonPageTextTemplate { get; set; }

        public string ButtonPreviousText { get; set; }

        public string ButtonNextText { get; set; }

        public string HrefTemplate { get; set; }

        protected override void WriteSelf(System.IO.TextWriter writer)
        {
            if (CurrentPage < 1)
            {
                throw new ArgumentOutOfRangeException("CurrentPage must be 1 or greater");
            }
            if (TotalPages < 1)
            {
                throw new ArgumentOutOfRangeException("TotalPages must be 1 or greater");
            }
            if (CurrentPage > TotalPages)
            {
                throw new ArgumentOutOfRangeException(string.Format("CurrentPage ({0}) must be less or equal to TotalPages ({1})", CurrentPage, TotalPages));
            }

            var pageStart = (PageButtonsCountBack == -1) ? 1 : Math.Max(1, CurrentPage - PageButtonsCountBack);
            var pageEnd = (PageButtonsCountForward == -1) ? TotalPages : Math.Min(TotalPages, CurrentPage + PageButtonsCountForward);

            using (Paginator.BeginContent(writer, null))
            {
                if (!HidePreviousNextButtons)
                {
                    var p = Math.Max(1, CurrentPage - 1);
                    var pi = Helper.CreateWriter<PaginatorItem, AnyContent>(this)
                        .Disabled(p == CurrentPage)
                        .Href(string.Format(HrefTemplate, p))
                        .Content(ButtonPreviousText);
                    pi.Item.WriteTo(writer);
                }
                for (var i = pageStart; i <= pageEnd; i++)
                {
                    var pi = Helper.CreateWriter<PaginatorItem, AnyContent>(this)
                        .Active(i == CurrentPage)
                        .Href(string.Format(HrefTemplate, i))
                        .Content(string.Format(ButtonPageTextTemplate, i));
                    pi.Item.WriteTo(writer);
                }
                if (!HidePreviousNextButtons)
                {
                    var p = Math.Min(TotalPages, CurrentPage + 1);
                    var pi = Helper.CreateWriter<PaginatorItem, AnyContent>(this)
                        .Disabled(p == CurrentPage)
                        .Href(string.Format(HrefTemplate, p))
                        .Content(ButtonNextText);
                    pi.Item.WriteTo(writer);
                }
            }
        }
    }
}
