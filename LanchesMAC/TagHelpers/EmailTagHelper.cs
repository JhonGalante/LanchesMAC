﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LanchesMAC.TagHelpers
{
    [HtmlTargetElement("email" , TagStructure = TagStructure.NormalOrSelfClosing)]
    public class EmailTagHelper : TagHelper
    {
        [HtmlAttributeName("endereco")]
        public string Endereco { get; set; }

        [HtmlAttributeName("conteudo")]
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
