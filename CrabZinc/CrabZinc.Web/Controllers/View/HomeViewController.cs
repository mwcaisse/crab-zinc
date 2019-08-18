using CrabZinc.Web.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CrabZinc.Web.Controllers.View
{
    [Route("/")]
    public class HomeViewController : BaseViewController
    {

        public HomeViewController(ApplicationConfiguration applicationConfiguration) : base(applicationConfiguration)
        {
        }
        
        // GET
        [Route("")]
        public IActionResult Index()
        {
            return VueView("views/Home");
        }
    }
}