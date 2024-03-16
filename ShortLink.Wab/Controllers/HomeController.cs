using Microsoft.AspNetCore.Mvc;
using ShortLink.Wab.Models;
using System.Diagnostics;

namespace ShortLink.Wab.Controllers
{
    public class HomeController : SiteBaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
