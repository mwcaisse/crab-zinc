using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrabZinc.Common.ViewModels;
using CrabZinc.Logic.Services;
using CrabZinc.Web.Configuration;
using CrabZinc.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.Controllers.View
{
    [Route("post/")]
    public class PostViewController : BaseViewController
    {

        private readonly PostService _postService;
        private readonly MarkdownRenderer _markdownRenderer;

        public PostViewController(ApplicationConfiguration applicationConfiguration, PostService postService, 
            MarkdownRenderer markdownRenderer) : base(applicationConfiguration)
        {
            this._postService = postService;
            this._markdownRenderer = markdownRenderer;
        }

        [Route("{slug}")]
        public IActionResult Index(string slug)
        {
            var post = _postService.GetBySlug(slug);

            if (null == post)
            {
                return NotFound();
            }

            var model = new RenderedPostViewModel()
            {
                Title = post.Title,
                Slug = post.Slug,
                PostId = post.PostId,
                PublishedDate = post.PublishedDate,
                RenderedContent = this._markdownRenderer.ToHtml(post.Content)
            };
            return View(model);
        }
    }
}