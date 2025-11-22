using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Sprint1.TagHelpers
{
    [HtmlTargetElement("category-tag")]
    public class CategoryTagHelper : TagHelper
    { 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            output.AddClass("badge", HtmlEncoder.Default);
            output.AddClass("bg-primary", HtmlEncoder.Default); 


            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}