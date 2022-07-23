using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalhaninYeri.Northwind.Web.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-category-paging")]
        public int CurrentCategoryPaging { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder str = new StringBuilder();
            str.Append("<ul class='pagination'>");

            str.AppendFormat("<li class='page-item {0}'>",CurrentPage==1?"disabled": "");
            str.AppendFormat("<a class='page-link' href='/Product/Index?page={0}&category={1}'>Geri</a>",CurrentPage-1,CurrentCategoryPaging);
            str.Append("</li>");

            for(int i=1; i <= PageCount; i++)
            {
                str.AppendFormat("<li class='page-item {0}'>", i == CurrentPage?"active" : "");
                str.AppendFormat("<a class='page-link' href='/Product/Index?page={0}&category={1}'>{2}</a>",i,CurrentCategoryPaging,i);
                str.Append("</li>");
            }

            str.AppendFormat("<li class='page-item {0}'>", CurrentPage == PageCount ? "disabled" : "");
            str.AppendFormat("<a class='page-link' href='/Product/Index?page={0}&category={1}'>İleri</a>", CurrentPage + 1, CurrentCategoryPaging);
            str.Append("</li>");

            str.Append("</ul>");
            output.Content.SetHtmlContent(str.ToString());
            base.Process(context, output);
        }
    }
}
