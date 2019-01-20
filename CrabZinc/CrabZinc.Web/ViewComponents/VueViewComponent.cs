using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.ViewComponents
{
    public class VueViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(string viewName)
        {
            var elm = new VueElement()
            {
                ViewName = viewName,
                VmElementId = GetRandomViewElementId()
            };
            return View(elm);
        }

        protected string GetRandomViewElementId()
        {
            var guid = Guid.NewGuid();
            return $"pageVm_{guid}";
        }

        public class VueElement
        {
            public string ViewName { get; set; }
            public string VmElementId { get; set; }
        }
    }
}
