using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrabZinc.Common.ViewModels;
using CrabZinc.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/post/")]
    public class PostApiController : BaseApiController
    {

        private readonly PostService _postService;

        public PostApiController(PostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult Get(long id)
        {
            return Get(_postService.Get(id));
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetAll());
        }

        [HttpGet]
        [Route("newest")]
        public IActionResult GetNewest()
        {
            return Ok(_postService.GetNewest());
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] PostViewModel post)
        {
            return Ok(_postService.Create(post));
        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult Update([FromBody] PostViewModel post)
        {
            return Ok(_postService.Update(post));
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult Delete(long id)
        {
            var post = _postService.Get(id);

            if (null == post)
            {
                return NotFound();
            }

            return Ok(_postService.Delete(id));
        }

    }
}
