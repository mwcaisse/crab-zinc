using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markdig;
using Markdig.SyntaxHighlighting;

namespace CrabZinc.Web.Util
{
    public class MarkdownRenderer
    {

        private readonly MarkdownPipeline _pipeline;

        public MarkdownRenderer()
        {
            this._pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();
        }

        public string ToHtml(string markdown)
        {
            return Markdown.ToHtml(markdown, this._pipeline);
        }

    }
}
