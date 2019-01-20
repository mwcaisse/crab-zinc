using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrabZinc.Web.Configuration;
using CrabZinc.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.Controllers.View
{
    [Route("admin/post/")]
    public class PostAdminController : BaseViewController
    {
        public PostAdminController(ApplicationConfiguration applicationConfiguration) : base(applicationConfiguration)
        {
        }

        [Route("{postId:long?}")]
        public IActionResult Index(long postId = -1)
        {
            return VueView("views/Post", "Admin -- Post", new VueViewProperty()
            {
                Name = "postId",
                Value = Convert.ToString(postId)
            });
        }
    }
}
