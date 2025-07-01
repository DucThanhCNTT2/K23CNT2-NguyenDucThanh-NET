using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenDucThanh_2310900098.Models;

namespace NguyenDucThanh_2310900098.Controllers
{
    public class NdtHomeController : Controller
    {
        private readonly ILogger<NdtHomeController> _logger;

        public NdtHomeController(ILogger<NdtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NdtIndex()
        {
            return View();
        }

        public IActionResult NdtAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
