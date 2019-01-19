using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.Controllers.Api
{
    public class BaseApiController : Controller
    {

        protected IActionResult Get(object entity)
        {
            if (null == entity)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        
    }
}
