using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;
//http://netcoders.com.br/mvc-6-novidades-do-taghelpers/
//https://blogs.msdn.microsoft.com/msgulfcommunity/2015/06/17/developing-custom-tag-helpers-in-asp-net-5/
namespace Components
{
    [HtmlTargetElement("submit")]
    public class SubmitTagHelper : TagHelper
    {
        #region const

        protected const string Submit_Label = "submit-label";
        protected const string Submit_Disabled = "submit-disabled";
        protected const string Submit_ClassCss = "submit-class"; 
        #endregion

        [HtmlAttributeName(Submit_Label)]
        public string Label { get; set; } = "Submeter";

        [HtmlAttributeName(Submit_Disabled)]
        public Boolean Disabled { get; set; } = false;

        [HtmlAttributeName(Submit_ClassCss)]
        public string ClassCss { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Render(context, output);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contextAsync = await output.GetChildContentAsync();
            if (contextAsync.IsEmptyOrWhiteSpace)
            {
                Render(context, output);
            }
        }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("type", "submit");

            if (Disabled)
            {
                output.Attributes.Add("disabled", "disabled");
            }

            if (string.IsNullOrEmpty(Label))
            {
                Label = "Submeter";
            }

            if (!string.IsNullOrEmpty(ClassCss))
            {
                output.Attributes.Add("class", ClassCss);
            }

            output.Content.SetContent(Label);
        }
    }
}
